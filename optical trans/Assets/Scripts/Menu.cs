using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject canvas;
    public bool paused = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Onoff();
        }
    }

    public void Onoff() {
        paused = !paused;
        canvas.SetActive(paused);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
