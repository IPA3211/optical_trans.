using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour {

    public bool Ground;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.GetComponent<Collider2D>().isTrigger == false) Ground = true;
        }
        catch { }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        try
        {
            if (other.GetComponent<Collider2D>().isTrigger == false) Ground = true;
        }
        catch { }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Ground = false;
    }
}
