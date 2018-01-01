using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asd : MonoBehaviour {

    public bool Ground; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnCollisionEnter2D(Collider2D other) {
            Ground = true;
    }
}
