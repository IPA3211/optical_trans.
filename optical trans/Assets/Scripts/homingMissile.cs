using UnityEngine;
using System.Collections;

public class homingMissile : MonoBehaviour
{
    public float speed = 5f;
    public float rotatingSpeed = 200f;
    GameObject target;
    Rigidbody2D rb;
	Vector2 point2Target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
            {;
                Destroy(other.gameObject);
            }
            if (other.GetComponent<ObjectOption>().canHit)
            {
				gameObject.transform.rotation = new Quaternion (0f, 0f, 0f, 0f); 
				gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
				speed = 0f;
				rotatingSpeed = 0f;
				gameObject.GetComponent<Animator> ().Play ("explosion");
            }
        }
    }

	void Exploded()
	{
		Destroy (gameObject);
	}
		
}

