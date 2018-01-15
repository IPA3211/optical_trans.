using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCannon : MonoBehaviour {
    public float BulletSpeed = 0;
    float angle = 0;
    BoxCollider2D box;
    
    public float DestroyTime;
    
    // Use this for initialization
    void Start () {
        Destroy(gameObject, DestroyTime);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(BulletSpeed * Time.deltaTime, 0, 0);
    }
}