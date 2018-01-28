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
        if(other.tag.Equals("player"))
        flowTime += Time.deltaTime;
        if (wapeTime < flowTime) {
            
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        flowTime = 0;
    }
}
