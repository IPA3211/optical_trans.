using UnityEngine;
using System.Collections;

public class homingMissile : MonoBehaviour
{
    public float speed = 5;
    public float rotatingSpeed = 200;
    public GameObject target;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
        point2Target.Normalize();
        float value = Vector3.Cross(point2Target, transform.right).z;
        /*
        if (value > 0) {

                rb.angularVelocity = rotatingSpeed;
        } else if (value < 0)
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
                Destroy(gameObject);
            }
        }
    }
}

