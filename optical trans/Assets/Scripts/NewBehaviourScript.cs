using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Color red;
    LineRenderer line;
    public Vector3 wp;

    // Use this for initialization
    void Start () {
        line = GetComponent<LineRenderer> ();
        line.startColor = red;
        line.endColor = red;
        line.startWidth = (float)0.1;
        line.endWidth = (float)0.1;
	}
	
	// Update is called once per frame
	void Update () {
        
        Ray2D ray = new Ray2D(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {

            Debug.Log(hit.collider.name);
        }
//        if (Physics2D.Linecast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), hit))
        line.SetPosition(0, transform.position);
        line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        line.enabled = true;

    }
}
