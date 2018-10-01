using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuStartButton : MonoBehaviour {
	public Sprite start_origin;
	public Sprite start_highlight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextScene () {
		SceneManager.LoadScene("office_1", LoadSceneMode.Single);
	}

	public void PointerEnter() {
		gameObject.GetComponent<Image> ().sprite = start_highlight;
	}

	public void PointerExit() {
		gameObject.GetComponent<Image> ().sprite = start_origin;
	}
}
