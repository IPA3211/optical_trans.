using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour {
	
	public static string scenename;
    public GameObject canvas;
    public bool paused = false;
	// Use this for initialization
	void Start () {
		scenename = SceneManager.GetActiveScene ().name;
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

    public void OnOffWithOutCanvas() {
        paused = !paused;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

	public void Restart() {
        StartCoroutine("myYield");
    }
    IEnumerator myYield()
    {
        if (paused) {
            Onoff();
        }
        GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
        Time.timeScale = 1;
        GameObject.Find("Main Camera").GetComponent<GlitchEffect>().enabled = false;

        
    }
    
}
