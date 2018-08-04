using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour {

    public float warpTime;

    bool loading = true;
    float flowTime;
    float defaultGravity;
    Animator ani;
    Vector3 defaultSize;
    public string nextStage;
    public GameObject button;
    public Sprite idleSprite;

    void Start()
    {
        ani = GetComponentInParent<Animator>();
        GetComponentInParent<Light>().enabled = false;
        ani.enabled = false;
    }

    void Update()
    {
        OnOff(IsActive());
        GetComponentInParent<SpriteRenderer>().sprite = idleSprite;
    }

    private bool IsActive() {
        try
        {
            if (button.GetComponent<eButton>().pushed == true) {
                return true;
            }
            else
                return false;
        }
        catch {
            return true;
        }
    }

    private void OnOff(bool isActive) {
        ani.enabled = isActive;
        GetComponentInParent<Light>().enabled = isActive;

    }

    void OnTriggerStay2D(Collider2D other) {
        if (IsActive())
        {
            ani.speed = 2;
            if (other.tag.Equals("Player"))
                flowTime += Time.deltaTime;
            if (warpTime < flowTime && loading)
            {
                loading = false;
                GameObject.Find("Script").GetComponent<Menu>().NextScene(nextStage);
            }
        }
        //Debug.Log(flowTime);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        flowTime = 0;
        ani.speed = 0.5f;
    }
}
