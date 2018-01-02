﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {


    public GameObject bullet;
    public float reloadTime;
    public int maxAmountOfBullet;
    public int AmountOfBullet;

    public GameObject reloadBar;

    private float Delayed;
    private bool reloading;
    private bool paused;




    // Use this for initialization
    void Start () {
        AmountOfBullet = maxAmountOfBullet;
        reloading = false;
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
                Delayed += Time.deltaTime;
                reloadBar.transform.localScale = new Vector3(Delayed / reloadTime, 1);
            }
            else
            {
                reloadBar.transform.localScale = new Vector3(0, 1);
            }

            if (Delayed >= reloadTime && reloading == true)
            {
                AmountOfBullet = maxAmountOfBullet;
                reloading = false;
            }

            if (Input.GetMouseButtonDown(0) && AmountOfBullet > 0)
            {
                Instantiate(bullet, transform.position, transform.parent.rotation);
                AmountOfBullet--;
                if (AmountOfBullet == 0)
                {
                    Delayed = 0;
                    reloading = true;
                }
            }

            if (Input.GetKey(KeyCode.R))
            {
                AmountOfBullet = 0;
                Delayed = 0;
                reloading = true;
            }
        }
    }
}
