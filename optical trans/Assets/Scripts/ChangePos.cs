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

	public float warp_delaytime = 0.1f;	//초기값은 0.2f이다
	public int i;

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

		//float WaTime = Time.realtimeSinceStartup + warp_animationtime;
		        
        Charactor.GetComponent<Animator>().enabled = false;
        Charactor.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        asd = Charactor.GetComponents<CircleCollider2D>();
        asd[0].enabled = false;
        asd[1].enabled = false;
        Charactor.GetComponent<CapsuleCollider2D>().enabled = false;
        Charactor.GetComponent<OnGround>().enabled = false;
        
		for(i = 0; i < 40; i++) {
			if (Charactor.transform.localScale.x - 0.01f > 0)
				Charactor.transform.localScale = new Vector3 (Charactor.transform.localScale.x - 0.05f, Charactor.transform.localScale.y - 0.05f, Charactor.transform.localScale.z);
			else
				break;
			yield return new WaitForSeconds (0.0005f);
		}
		Gun.SetActive(false);
		Charactor.GetComponent<SpriteRenderer>().enabled = false;

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

		for(i = 0; i < 40; i++) {
			Debug.Log (Charactor.transform.localScale.x);
			if(Charactor.transform.localScale.x + 0.01f < 0.9)
				Charactor.transform.localScale = new Vector3(Charactor.transform.localScale.x + 0.05f, Charactor.transform.localScale.y + 0.05f, Charactor.transform.localScale.z);
			else
				break;
			yield return new WaitForSeconds (0.0005f);
		}

		Charactor.transform.localScale = new Vector3(0.9f, 0.9f, Charactor.transform.localScale.z);
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
