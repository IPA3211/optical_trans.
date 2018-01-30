using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour {

    public float wapeTime;

    bool loading = true;
    float flowTime;
    float defaultGravity;
    Animator ani;
    Vector3 defaultSize;
    public string nextStage;

    void Start()
    {
        ani = GetComponentInParent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other) {
        ani.speed = 2;
        if (other.tag.Equals("Player"))
        flowTime += Time.deltaTime;
        if (wapeTime < flowTime && loading) {
            loading = false;
            GameObject.Find("Script").GetComponent<Menu>().NextScene(nextStage);
        }
        //Debug.Log(flowTime);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        flowTime = 0;
        ani.speed = 0.5f;
    }
}
