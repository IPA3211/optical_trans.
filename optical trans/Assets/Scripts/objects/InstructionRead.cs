using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionRead : MonoBehaviour {

	public GameObject instruction;
	public GameObject show_instructionbox;
	public GameObject e_button;
	bool enter;
	bool e_click;
	Sprite spr;

	void Start() {
		enter = false;
		e_click = false;
		//spr = (Sprite)Resources.Load ("Sprites/object2_15");
	}

	void Update(){
		if (enter == true) {
			e_button.SetActive (true);

			if (Input.GetKeyDown (KeyCode.E) && e_click == false) {
				e_click = true;
				show_instructionbox.SetActive (true);
			} 
			else if (Input.GetKeyDown (KeyCode.E) && e_click == true) {
				show_instructionbox.SetActive (false);
				e_click = false;
			}
		}
		else {
			e_button.SetActive (false);
			show_instructionbox.SetActive (false);
		}
		
	}
		
	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag.Equals ("Player")) {
			enter = true;
			//this.GetComponent<SpriteRenderer> ().sprite = spr;
			//no_instruction.GetComponent<SpriteRenderer> ().enabled = true;
		}

	}

	void OnTriggerExit2D(Collider2D other){
		enter = false;
	}
}