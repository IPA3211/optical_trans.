using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoadButton : MonoBehaviour {
	public Sprite load_origin;
	public Sprite load_highlight;

	// Use this for initialization
	void Start () {
		
	}

	public void LoadScene () {
		//SceneManager.LoadScene(, LoadSceneMode.Single);
	}

	public void PointerEnter() {
		gameObject.GetComponent<Image> ().sprite = load_highlight;
	}

	public void PointerExit() {
		gameObject.GetComponent<Image> ().sprite = load_origin;
	}
}
