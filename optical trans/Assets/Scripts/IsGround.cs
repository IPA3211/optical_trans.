using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour {

    bool Ground; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("in");
        Ground = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("out");
        Ground = false;
    }
}
