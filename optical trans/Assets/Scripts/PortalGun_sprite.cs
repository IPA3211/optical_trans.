using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun_sprite : MonoBehaviour {

	public GameObject no_portalgun;
	public GameObject playergun;

	void OnTriggerStay2D(Collider2D other) {
		

		this.GetComponent<SpriteRenderer>().enabled = false;
		no_portalgun.GetComponent<SpriteRenderer>().enabled = true;
		playergun.SetActive (true);

	}
		
}

	