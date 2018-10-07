using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (Input.GetAxis("Fire1") > 0&& !system.paused && !overlapped && (sumTime > sensitivity) && !EventSystem.current.IsPointerOverGameObject())
        {
            drawer.GetComponent<Editor_ImageChanger>().sourceObject = system.GetFocus();
            obj = Instantiate(drawer, transform.position, Quaternion.identity);
            obj.transform.parent = collector.transform;
            sumTime = 0;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                // raycast hit this gameobject
            }
        }
        overlapped = false;
    }

    private void LateUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        overlapped = true;
    }
}
