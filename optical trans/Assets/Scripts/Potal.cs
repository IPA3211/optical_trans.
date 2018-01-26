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
        
        if (other.GetComponent<UnityChan2DController>() != null) {
            other.GetComponent<UnityChan2DController>().DoubleJump = false;
        }
        flowTime += Time.deltaTime;
        other.transform.localScale = new Vector3();

        if (flowTime > wapeTime)
            flowTime = wapeTime;
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        flowTime = 0;
    }
}
