using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour {

    public GameObject scan1;
    public GameObject scan2;
    public GameObject scan3;
    public GameObject scan4;

    public bool onGround;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        onGround = false;
        if (scan1.GetComponent<IsGround>().Ground || scan2.GetComponent<IsGround>().Ground || scan3.GetComponent<IsGround>().Ground || scan4.GetComponent<IsGround>().Ground)
        {
            onGround = true;
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.y < -55f && onGround) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
        }
	}
}
