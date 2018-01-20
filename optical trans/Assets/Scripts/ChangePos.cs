using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePos : MonoBehaviour {

    public GameObject Charactor;
    public GameObject Gun;
    public CircleCollider2D[] asd = new CircleCollider2D[2];
    Vector2 Trans = Vector2.zero;
    Vector2 TransR = Vector2.zero;

    GameObject Object;
    Menu menu;

	public float warp_delaytime = 0.5f;	//초기값은 0.2f이다

    private new Rigidbody2D rigidbody;
    // Use this for initialization
    void Start () {
        Charactor = GameObject.Find("DemoUnityChan2D");
        Gun = GameObject.Find("Gun");
    }
	
	// Update is called once per frame
	void Update () {
        if (Charactor == null)
        {
            Charactor = GameObject.Find("DemoUnityChan2D");
        }

        if (Gun == null)
        {
            Gun = GameObject.Find("P_Gun");
        }
    }

    public void Change(GameObject other)
    {
        if (Charactor == null)
        {
            Charactor = GameObject.Find("DemoUnityChan2D");
        }

        if (Gun == null)
        {
            Gun = GameObject.Find("P_Gun");
        }
		WarpSoundManager.instance.PlayWarpStartSound ();	//워프 시작사운드
        Debug.Log("asd");
        Object = other;
        StartCoroutine("myYield");
    }

    public void StopSecond() {
        GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = true;
        
        
    }
    IEnumerator myYield()
    {
        //menu = GameObject.Find("Script").GetComponent<Menu>();
        Trans = Object.transform.position;
        TransR = Charactor.transform.position;
        TransR.y = (float)(TransR.y - 0.085);	//바닥에서 순간이동시켰을대 바닥에 딱붙게함 이게 맞는 위치가 아닐까?

        //menu.OnOffWithOutCanvas();

		Object.SetActive(false);
        Charactor.GetComponent<SpriteRenderer>().enabled = false;
        Charactor.GetComponent<Animator>().enabled = false;
        Charactor.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        asd = Charactor.GetComponents<CircleCollider2D>();
        asd[0].enabled = false;
        asd[1].enabled = false;
        Charactor.GetComponent<CapsuleCollider2D>().enabled = false;
        Charactor.GetComponent<OnGround>().enabled = false;
        Gun.SetActive(false);

        //GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = true;
		float WTime = Time.realtimeSinceStartup + warp_delaytime;

        while (Time.realtimeSinceStartup < WTime)
        {
            yield return 0;
        }
        //GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = false;
        
		WarpSoundManager.instance.PlayWarpEndtSound ();	//워프 끝사운드
        Object.transform.position = TransR;
        Charactor.transform.position = Trans;

        Object.SetActive(true);
        Charactor.GetComponent<SpriteRenderer>().enabled = true;
        Charactor.GetComponent<Animator>().enabled = true;
        Charactor.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        asd[0].enabled = true;
        asd[1].enabled = true;
        Charactor.GetComponent<CapsuleCollider2D>().enabled = true;
        Charactor.GetComponent<OnGround>().enabled = true;
        Gun.SetActive(true);

        //menu.OnOffWithOutCanvas();


        rigidbody = Charactor.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);

        //Debug.Log("TransR :" + TransR.x + " " + TransR.y);
        //Debug.Log("Trans :" + Trans.x + " " + Trans.y);
    }
}
