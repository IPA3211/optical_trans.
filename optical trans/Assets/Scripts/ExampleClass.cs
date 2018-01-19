using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public GameObject cha;
    public GameObject bar;
    public bool flip;

    Vector2 wp3;

    private bool paused;

    float angle_r;

    private void Start()
    {
        paused = GameObject.Find("Script").GetComponent<Menu>().paused;
    }
    void Update()
    {
        paused = GameObject.Find("Script").GetComponent<Menu>().paused;
        if (!paused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Ray2D ray = new Ray2D(wp, Vector2.zero);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider.name);
                }
            }
            if (cha == null) {
                cha = GameObject.Find("DemoUnityChan2D");
                wp3 = cha.transform.position;
            }
            else {
                wp3 = cha.transform.position;
            }

            if (bar == null) {
                bar = GameObject.Find("P_Gun");
            }
            Vector2 wp2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 asd;

            asd.x = wp2.x - wp3.x;
            asd.y = wp2.y - wp3.y;

            Quaternion rot = cha.transform.rotation;

            float angle = Mathf.Atan2(asd.x, asd.y) * Mathf.Rad2Deg;
            if (-angle + 90 > -90 && -angle + 90 < 90)
            {
                flip = false;
                cha.transform.rotation = Quaternion.Euler(rot.x, 0, rot.z);
                bar.transform.rotation = Quaternion.Euler(0, 0, -angle + 90);
            }
            else
            {
                flip = true;
                cha.transform.rotation = Quaternion.Euler(rot.x, 180, rot.z);
                bar.transform.rotation = Quaternion.Euler(180, 0, angle - 90);
            }
        }
    }
}