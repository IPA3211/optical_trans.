using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCreditButton : MonoBehaviour {
	public Sprite credit_origin;
	public Sprite credit_highlight;

	// Use this for initialization
	void Start () {

	}

	public void CreditScene () {
		//SceneManager.LoadScene(, LoadSceneMode.Single);
	}

	public void PointerEnter() {
		gameObject.GetComponent<Image> ().sprite = credit_highlight;
	}

	public void PointerExit() {
		gameObject.GetComponent<Image> ().sprite = credit_origin;
	}
}