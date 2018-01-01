using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePos : MonoBehaviour {

    public GameObject Charactor;
    Vector2 Trans = Vector2.zero;
    Vector2 TransR = Vector2.zero;

    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Change(GameObject other)
    {
        Trans = other.transform.position;
        TransR = Charactor.transform.position;

        other.transform.position = TransR;
        Charactor.transform.position = Trans;

        rigidbody = Charactor.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);

        Debug.Log("TransR :" + TransR.x + " " + TransR.y);
        Debug.Log("Trans :" + Trans.x + " " + Trans.y);
    }
}
