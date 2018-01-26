using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour {

    public float wapeTime;

    bool trigger = true;
    float flowTime;
    float defaultGravity;
    Vector3 defaultSize;

    void OnTriggerStay2D(Collider2D other) {

        if (trigger == true) {
            flowTime = 0;
            if (other.GetComponent<Rigidbody2D>() != null)
            {
                defaultGravity = other.GetComponent<Rigidbody2D>().gravityScale;
            }
            if (other.GetComponent<UnityChan2DController>() != null)
            {
                other.GetComponent<UnityChan2DController>().DoubleJump = false;
            }
            defaultSize = other.transform.localScale;

            Debug.Log(defaultGravity);
            trigger = false;
        }

        if (other.GetComponent<Rigidbody2D>() != null)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, 0);
            other.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }
        if (other.GetComponent<UnityChan2DController>() != null) {
            other.GetComponent<UnityChan2DController>().DoubleJump = false;
        }
        flowTime += Time.deltaTime;
        other.transform.localScale = new Vector3(defaultSize.x - ((defaultSize.x / wapeTime) * flowTime), defaultSize.y - ((defaultSize.x / wapeTime) * flowTime));

        if (flowTime > wapeTime)
            flowTime = wapeTime;
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() != null)
        {
            other.GetComponent<Rigidbody2D>().gravityScale = defaultGravity;
        }
        if (other.GetComponent<UnityChan2DController>() != null)
        {
            other.GetComponent<UnityChan2DController>().DoubleJump = true;
        }
        other.transform.localScale = defaultSize;

        trigger = true;
    }
}
