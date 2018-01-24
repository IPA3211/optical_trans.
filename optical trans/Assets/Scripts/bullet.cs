using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet: MonoBehaviour {
    public enum BulletType { trans, turret }
    public BulletType bulletType;
    public float BulletSpeed = 0;

    public GameObject Charactor;
    public GameObject line;
    public float DestroyTime;

    float angle = 0;
    float x = 0, y = 0;

    private bool trigger = true;
    //Vector2 Trans = Vector2.zero;
    //Vector2 TransR = Vector2.zero;

    ChangePos change;

    // Use this for initialization
    void Start ()
    {
        angle = transform.eulerAngles.z;
        //Debug.Log(angle);
        change = GameObject.Find("Script").GetComponent<ChangePos>();
		Destroy (gameObject, DestroyTime);
        trigger = true;

        if (bulletType == BulletType.turret) {
            gameObject.tag = "DamageObject";
        }
    }
	
	// Update is called once per frame
	void Update () {
        y = Mathf.Sin(angle * Mathf.Deg2Rad) * BulletSpeed;
        x = Mathf.Cos(angle * Mathf.Deg2Rad) * BulletSpeed;

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
        //transform.position += new Vector3(x * Time.deltaTime, y * Time.deltaTime, 0);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (trigger)
        {
            if (bulletType == BulletType.trans)
            {
                Debug.Log(trigger);
                trigger = false;
                if (!other.GetComponent<ObjectOption>().canTrans)
                {
                    if (other.GetComponent<ObjectOption>().canHit)
                    {
                        Destroy(line);
                        Destroy(gameObject);
                    }
                    else
                    {
                        trigger = true;
                    }
                }
                else
                {
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
                    change.Change(other.gameObject);
                    //Debug.Log("asd");
                    Destroy(line);
                    Destroy(gameObject);
                }
            }
            else if (bulletType == BulletType.turret)
            {
                if (other.GetComponent<ObjectOption>().canHit)
                    Destroy(gameObject);
            }
        }
    }

    
}
