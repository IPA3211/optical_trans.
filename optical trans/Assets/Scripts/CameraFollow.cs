﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		
		if(player.transform.localPosition.x > 0 && player.transform.localPosition.x < 67.4 && player.transform.localPosition.y > 0  && player.transform.localPosition.y < 38.3)	//야매 변수값 개이득 ^^
		{
			float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
			float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
			transform.position = new Vector3 (posX, posY, transform.position.z);
			Debug.Log ("x : " + posX + ", y : " + posY);
		}
		else if(player.transform.localPosition.x > 0 && player.transform.localPosition.x < 67.4)
		{
			float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
			//float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
			transform.position = new Vector3 (posX, transform.position.y, transform.position.z);
			Debug.Log ("only x");
		}
		else if(player.transform.localPosition.y > 0 && player.transform.localPosition.y < 38.3)
		{
			//float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
			float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
			transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
			Debug.Log ("only y");
		}
			
	}
}
