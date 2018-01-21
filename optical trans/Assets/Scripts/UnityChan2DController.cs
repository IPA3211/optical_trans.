using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class UnityChan2DController : MonoBehaviour
{
    public int health = 3;
    public float maxSpeed = 10f;
    public float minYVelocity = -100f;
    public float jumpDelay = 0.1f;
    public float jumpPower = 1000f;
    public float dieYVal = -100f;
    public Vector2 backwardForce = new Vector2(-4.5f, 5.4f);
    public bool DoubleJump;
    public bool Flip;
    
    public LayerMask whatIsGround;
	AudioSource reloadSound;
    float otherObjSpeed;

    private Animator m_animator;
    private BoxCollider2D m_boxcollier2D;
    private Rigidbody2D m_rigidbody2D;
    private bool m_isGround;
    private bool canDoubleJump; //allow to double jump
    private bool canJump = true;
    private bool paused;
    private float jumpTime;
    private const float m_centerY = 1.5f;

    private State m_state = State.Normal;

    void Reset()
    {
        Awake();

        // UnityChan2DController
        maxSpeed = 10f;
        jumpPower = 1000;
        backwardForce = new Vector2(-4.5f, 5.4f);
        whatIsGround = 1 << LayerMask.NameToLayer("Ground");

        // Transform
        transform.localScale = new Vector3(1, 1, 1);

        // Rigidbody2D
        m_rigidbody2D.gravityScale = 3.5f;
        //m_rigidbody2D.fixedAngle = true;

        // BoxCollider2D
        m_boxcollier2D.size = new Vector2(1, 2.5f);
        m_boxcollier2D.offset = new Vector2(0, -0.25f);

        // Animator
        m_animator.applyRootMotion = false;
    }

    void Awake()
    {
        m_isGround = gameObject.GetComponent<OnGround>().onGround;
        m_animator = GetComponent<Animator>();
        m_boxcollier2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        if (DoubleJump)
            canDoubleJump = true;
        paused = GameObject.Find("Script").GetComponent<Menu>().paused;
    }

    void Update()
    {
        m_isGround = gameObject.GetComponent<OnGround>().onGround;
        paused = GameObject.Find("Script").GetComponent<Menu>().paused;
        if (!paused)
        {
            if (m_state != State.Damaged)
            {
                float x = Input.GetAxis("Horizontal");
                bool jump = Input.GetButtonDown("Jump");
                Move(x, jump);
            }
        }

        if (transform.position.y < dieYVal) {
            GameObject.Find("Script").GetComponent<Menu>().Restart();
        }

        if (minYVelocity > gameObject.GetComponent<Rigidbody2D>().velocity.y) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, minYVelocity);
        }
    }

    void Move(float move, bool jump)
    {
        if (Mathf.Abs(move) > 0)
        {
            Quaternion rot = transform.rotation;
            Flip =Mathf.Sign(move) == 1 ? false : true;
            //transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);
        }

        m_rigidbody2D.velocity = new Vector2(move * maxSpeed, m_rigidbody2D.velocity.y);

        m_animator.SetFloat("Horizontal", move);
        m_animator.SetFloat("Vertical", m_rigidbody2D.velocity.y);
        m_animator.SetBool("isGround", m_isGround);

        if (jump)
        {
            if (m_isGround && canJump)
            {
                m_animator.SetTrigger("Jump");
                SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
                m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, jumpPower);
                //canDoubleJump = true;
                canJump = false;
                Debug.Log("jump");
            }
            else
            {
                if (!m_isGround && canDoubleJump && DoubleJump)
                {
                    canDoubleJump = false;
                    SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
                    m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, jumpPower / 1.1f);
                    Debug.Log("Djump");
                    //m_rigidbody2D.AddForce(Vector2.up * jumpPower);
                }
            }
        }
        if (m_isGround)
        {
            if (!canJump)
            {
                jumpTime += Time.deltaTime;
                if (jumpTime > jumpDelay)
                {
                    jumpTime = 0;
                    canJump = true;
                    canDoubleJump = true;
                }
            }
            else {
                canDoubleJump = true;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        //Vector2 groundCheck = new Vector2(pos.x, pos.y - (m_centerY * transform.localScale.y));
        //Vector2 groundArea = new Vector2(m_boxcollier2D.size.x * 0.49f, 0.05f);

        //m_isGround = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsGround);
        m_animator.SetBool("isGround", m_isGround);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "DamageObject" && m_state == State.Normal)
        {
            otherObjSpeed = other.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            Debug.Log(otherObjSpeed);
            m_state = State.Damaged;
            StartCoroutine(INTERNAL_OnDamage());
        }
    }

    IEnumerator INTERNAL_OnDamage()
    {
        health--;
        
        m_animator.Play(m_isGround ? "Damage" : "AirDamage");
        m_animator.Play("Idle");
            
        GetComponent<HealthView>().Onoff();

        SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);

        if (m_rigidbody2D.velocity.x - otherObjSpeed > 0)
        {
            m_rigidbody2D.velocity = new Vector2(1 * backwardForce.x, transform.up.y * backwardForce.y);
            if (transform.eulerAngles.z > -1 && transform.eulerAngles.z > 1)
            {
            }
        }
        else if (m_rigidbody2D.velocity.x - otherObjSpeed < 0)
            m_rigidbody2D.velocity = new Vector2(-1 * backwardForce.x, transform.up.y * backwardForce.y);
        else
        {
            m_rigidbody2D.velocity = new Vector2(transform.right.x * backwardForce.x, transform.up.y * backwardForce.y);
        }

        yield return new WaitForSeconds(.5f);

        //while (m_isGround == false)
        //{
        //    yield return new WaitForFixedUpdate();
        //}
        if (health == 0)
        {
            GameObject.Find("Script").GetComponent<Menu>().Restart();
            m_animator.Play("Dead");
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            m_animator.SetTrigger("Invincible Mode");
            m_state = State.Invincible;
        }
            
        yield return new WaitForSeconds(1.1f);
        GetComponent<HealthView>().Onoff();
    }

    void OnFinishedInvincibleMode()
    {
        m_state = State.Normal;
    }

    enum State
    {
        Normal,
        Damaged,
        Invincible,
    }
}
