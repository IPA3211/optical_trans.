using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public GameObject cha;
    public GameObject bar;

    float angle_r;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
        }
        Vector2 wp3 = cha.transform.position;
        Vector2 wp2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 asd;

        asd.x = wp2.x - wp3.x;
        asd.y = wp2.y - wp3.y;

        float angle = Mathf.Atan2(asd.x, asd.y) * Mathf.Rad2Deg;

        bar.transform.rotation = Quaternion.Euler(0,0, -angle + 90);
    }
}