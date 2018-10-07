using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eButton : MonoBehaviour {
    internal readonly object onClick;
    public GameObject listener;
    public GameObject light;
    public Sprite idle, push;
    public bool pushed;
    bool push_sounded;
    public float delay;
    private float sumTime;
    IsGround Check;

    // Use this for initialization
    void Start () {
        Check = listener.GetComponent<IsGround>();
        push_sounded = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        sumTime += Time.deltaTime;
        if (sumTime > delay)
        {
            pushed = Check.Ground;
            sumTime = 0;
        }
       
        if (pushed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = push;
            if (push_sounded == false)
            {
                ButtonSoundManager.instance.PlayButtonSound();
                push_sounded = true;
            }
            if (light != null)
            {
                light.GetComponent<Light>().enabled = true;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = idle;
            push_sounded = false;
            if (light != null)
            {
                light.GetComponent<Light>().enabled = false;
            }
        }

    }
    
}
