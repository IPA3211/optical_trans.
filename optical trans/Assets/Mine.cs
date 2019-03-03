using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Animator animator;
    private Light light;


    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();         
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ExplodeStarted()
    {
        MineSoundManager.instance.PlayMineBoomSound();
        light.enabled = false;
    }

    void Exploded()
    {
        Destroy(gameObject);
    }
}
