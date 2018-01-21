using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {


    public GameObject bullet;
    public float reloadTime;
    public int maxAmountOfBullet;
    public int AmountOfBullet;

    public GameObject reloadBar;
    public GameObject charactor;
	public Transform BulletTrailPrefab;

    private float Delayed;
    private bool reloading;
	private bool reload_sounded;
    private bool paused;




    // Use this for initialization
    void Start () {
        AmountOfBullet = maxAmountOfBullet;
        reloading = false;
		reload_sounded = false;
        reloadBar.transform.localScale = new Vector3(0, 1);
        paused = GameObject.Find("Script").GetComponent<Menu>().paused;
    }
	
	// Update is called once per frame
	void Update () {
        paused = GameObject.Find("Script").GetComponent<Menu>().paused;
        if (!paused)
        {
            if (reloading == true)
            {
				if (reload_sounded == false) {
					soundManager.instance.PlayReloadSound ();
					reload_sounded = true;
				}
				Delayed += Time.deltaTime;
                if (charactor.GetComponent<UnityChan2DController>().Flip) {
                    reloadBar.transform.position = charactor.transform.position + new Vector3(-0.44f, 1.2f);
                    reloadBar.transform.localScale = new Vector3(Delayed / reloadTime, 1);
                }

                else
                {
                    reloadBar.transform.position = charactor.transform.position + new Vector3(-0.56f, 1.2f);
                    reloadBar.transform.localScale = new Vector3(Delayed / reloadTime, 1);
                }
            }
            else
            {
                reloadBar.transform.localScale = new Vector3(0, 1);
            }

            if (Delayed >= reloadTime && reloading == true)
            {
                AmountOfBullet = maxAmountOfBullet;
                reloading = false;
				reload_sounded = false;
            }

            if (Input.GetMouseButtonDown(0) && AmountOfBullet > 0)
            {
				soundManager.instance.PlayGunFireSound ();
                if (!GameObject.Find("Script").GetComponent<ExampleClass>().flip)
                    Instantiate(bullet, transform.position, transform.parent.rotation);
                else
                    Instantiate(bullet, transform.position, Quaternion.Euler(180, 0, -transform.parent.eulerAngles.z));
				Effect ();
                AmountOfBullet--;
                if (AmountOfBullet == 0)
                {
                    Delayed = 0;
                    reloading = true;
                }
            }

			if (Input.GetKey(KeyCode.R) && reloading == false)
            {
                AmountOfBullet = 0;
                Delayed = 0;
                reloading = true;
            }
        }
    }

	void Effect()
	{
		Instantiate (BulletTrailPrefab, transform.position, transform.rotation);	
	}
}
