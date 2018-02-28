using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject listener;
    public GameObject light;
    public Sprite idle, push;
    public bool pushed;

    IsGround Check;
    // Use this for initialization
    void Start () {
        Check = listener.GetComponent<IsGround>();

    }
	
	// Update is called once per frame
	void Update () {
        pushed = Check.Ground;
        if (pushed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = push;
            if (light != null) {
                light.GetComponent<Light>().enabled = true;
            }
        }

        else {
            gameObject.GetComponent<SpriteRenderer>().sprite = idle;
            if (light != null)
            {
                light.GetComponent<Light>().enabled = false;
            }
        }
    }
    
}
