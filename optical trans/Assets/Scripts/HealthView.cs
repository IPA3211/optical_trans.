using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthView : MonoBehaviour {

    public GameObject Hearts;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    private Animator m_animator;

    private bool on;
    // Use this for initialization
    void Start () {
        on = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<UnityChan2DController>().Flip)
        {
            Hearts.transform.position = transform.position + new Vector3(0f, 1.3f);
        }

        else
        {
            Hearts.transform.position = transform.position + new Vector3(0f, 1.3f);
        }
    }

    public void Onoff() {
        Hearts.SetActive(on = !on);

        if (on)
        {
            if (GetComponent<UnityChan2DController>().health == 2)
            {
                m_animator = Heart3.GetComponent<Animator>();
                m_animator.Play("InvincibleModeH");
            }
            if (GetComponent<UnityChan2DController>().health == 1)
            {
                m_animator = Heart2.GetComponent<Animator>();
                m_animator.Play("InvincibleModeH");
            }
        }
    }
}
