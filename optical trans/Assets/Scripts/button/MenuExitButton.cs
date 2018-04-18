using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuExitButton : MonoBehaviour {
	public Sprite exit_origin;
	public Sprite exit_highlight;

	// Use this for initialization
	void Start () {

	}

	public void ExitGame () {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void PointerEnter() {
		gameObject.GetComponent<Image> ().sprite = exit_highlight;
	}

	public void PointerExit() {
		gameObject.GetComponent<Image> ().sprite = exit_origin;
	}
}