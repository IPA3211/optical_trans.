using UnityEngine;
using System.Collections;

public class homingMissile : MonoBehaviour
{
    public float speed = 5f;
    public float rotatingSpeed = 200f;
    GameObject target;
    Rigidbody2D rb;
	Vector2 point2Target;
    public Color blue, red;
    Light light;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        light = GetComponentInChildren<Light>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (light != null)
        {
            if (spriteRenderer.sprite.name.Equals("enemy_9"))
            {
                light.color = blue;
            }
            else
            {
                light.color = red;
            }
        }
		point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
		point2Target.Normalize ();
		float value = Vector3.Cross (point2Target, transform.right).z;
		/*
       	if (value > 0) {
               rb.angularVelocity = rotatingSpeed;
        } 
        else if (value < 0)
        	rb.angularVelocity = -rotatingSpeed;
        else
           	rotatingSpeed = 0;
		*/
		rb.angularVelocity = rotatingSpeed * value;
		rb.velocity = transform.right * speed;
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<ObjectOption>() != null)
        {
            if (other.GetComponent<ObjectOption>().canDestroyByBigEnemy)
            {
                Destroy(other.gameObject);
            }
            if (other.GetComponent<ObjectOption>().canHit)
            {
				gameObject.transform.rotation = new Quaternion (0f, 0f, 0f, 0f); 
				gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
				speed = 0f;
				rotatingSpeed = 0f;
                Destroy(light);
				gameObject.transform.localScale = new Vector3 (1.45f, 1.45f, 1.45f);
				gameObject.GetComponent<Animator> ().Play ("explosion");
            }
        }
    }

	void Exploded()
	{
		Destroy (gameObject);
	}
		
}

