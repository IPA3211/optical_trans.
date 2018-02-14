using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmChange : MonoBehaviour {
	public Sprite currentSprite;
	public Sprite nextsprite;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = currentSprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
