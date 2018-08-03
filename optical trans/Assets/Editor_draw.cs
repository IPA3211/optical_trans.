using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_draw : MonoBehaviour {
    Editor_System system;
    public GameObject drawer;
    private GameObject collector;
    private GameObject obj;
    private float sumTime = 0;
    private float sensitivity = 0.05f;
    private bool overlapped = false;
    // Use this for initialization
    void Start() {
        system = GameObject.Find("System").GetComponent<Editor_System>();
        collector = GameObject.Find("Collector");
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        sumTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && !system.paused && !overlapped && (sumTime > sensitivity))
        {
            Debug.Log("asdf");
            drawer.GetComponent<Editor_ImageChanger>().sourceObject = system.GetFocus();
            obj = Instantiate(drawer, transform.position, Quaternion.identity);
            obj.transform.parent = collector.transform;
            sumTime = 0;
        }
        overlapped = false;
    }

    private void LateUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Hit");
        overlapped = true;
    }
}
