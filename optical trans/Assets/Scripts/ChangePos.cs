using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePos : MonoBehaviour {

    public GameObject Charactor;
    public GameObject Gun;
    Vector2 Trans = Vector2.zero;
    Vector2 TransR = Vector2.zero;

    GameObject Object;

    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Change(GameObject other)
    {
        Object = other;
        StartCoroutine("myYield");
    }

    public void StopSecond() {
        GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = true;
        
        
    }
    IEnumerator myYield()
    {
        Trans = Object.transform.position;
        TransR = Charactor.transform.position;
        TransR.y = (float)(TransR.y - 0.355);	//바닥에서 순간이동시켰을대 바닥에 딱붙게함 이 맞는 위가 아닐까?

        Object.SetActive(false);
        Charactor.GetComponent<SpriteRenderer>().enabled = false;
        Charactor.GetComponent<Animator>().enabled = false;
        Charactor.GetComponent<CircleCollider2D>().enabled = false;
        Charactor.GetComponent<CapsuleCollider2D>().enabled = false;
        Charactor.GetComponent<OnGround>().enabled = false;
        Gun.SetActive(false);

        GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = true;
        yield return new WaitForSeconds(0.3F);
        GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = false;
        
        Object.transform.position = TransR;
        Charactor.transform.position = Trans;

        Object.SetActive(true);
        Charactor.GetComponent<SpriteRenderer>().enabled = true;
        Charactor.GetComponent<Animator>().enabled = true;
        Charactor.GetComponent<CircleCollider2D>().enabled = true;
        Charactor.GetComponent<CapsuleCollider2D>().enabled = true;
        Charactor.GetComponent<OnGround>().enabled = true;
        Gun.SetActive(true);


        rigidbody = Charactor.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);

        Debug.Log("TransR :" + TransR.x + " " + TransR.y);
        Debug.Log("Trans :" + Trans.x + " " + Trans.y);
    }
}
