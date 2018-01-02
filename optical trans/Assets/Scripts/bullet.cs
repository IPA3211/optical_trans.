using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet: MonoBehaviour {

    public float BulletSpeed = 0;
    float angle = 0;
    float x = 0, y = 0;

    public GameObject Charactor;
    public GameObject asd;
    public float DestroyTime;
    Vector2 Trans = Vector2.zero;
    Vector2 TransR = Vector2.zero;

    ChangePos change;

    // Use this for initialization
    void Start ()
    {
        angle = transform.eulerAngles.z;
        Debug.Log(angle);
        change = GameObject.Find("Script").GetComponent<ChangePos>();
		Destroy (gameObject, DestroyTime);
    }
	
	// Update is called once per frame
	void Update () {
        y = Mathf.Sin(angle * Mathf.Deg2Rad) * BulletSpeed;
        x = Mathf.Cos(angle * Mathf.Deg2Rad) * BulletSpeed;

        transform.position += new Vector3(x * Time.deltaTime, y * Time.deltaTime, 0);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "coin") { }
        else
        {
            change.Change(other.gameObject);
            Debug.Log("asd");

            Destroy(gameObject);
        }
    }
}
