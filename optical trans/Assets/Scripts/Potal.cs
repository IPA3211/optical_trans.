using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour {

    public float wapeTime;

    bool trigger = true;
    float flowTime;
    float defaultGravity;
    Animator ani;
    Vector3 defaultSize;

    void Start()
    {
        ani = GetComponentInParent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other) {
        ani.speed = 2;
        if (other.tag.Equals("player"))
        flowTime += Time.deltaTime;
        if (wapeTime < flowTime) {
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        flowTime = 0;
        ani.speed = 0.5f;
    }
}
