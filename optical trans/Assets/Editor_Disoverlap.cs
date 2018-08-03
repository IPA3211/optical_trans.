using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_Disoverlap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log("hit");
    }
}
