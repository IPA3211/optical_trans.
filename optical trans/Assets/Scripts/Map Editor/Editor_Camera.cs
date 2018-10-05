using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_Camera : MonoBehaviour {

    public float cameraMoveSpeed = 5.0f;
    public float cameraZoomSpeed = 0.5f;
    public float cameraScrollratio = 5f;

    private Vector3 mousePos;
    private float sumTime = 0;
    public float dragTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        sumTime += Time.deltaTime;
        Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetKey(KeyCode.Mouse1))
        {   
            Ray ray = Camera.main.ScreenPointToRay(wp);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                
            if (hit.collider != null)
            {
                Destroy(hit.collider.gameObject);
            }
                 


        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            gameObject.GetComponent<Camera>().orthographicSize += cameraZoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            gameObject.GetComponent<Camera>().orthographicSize -= cameraZoomSpeed;
            if (gameObject.GetComponent<Camera>().orthographicSize < 0) gameObject.GetComponent<Camera>().orthographicSize = 0;
        }


        if (dragTime < sumTime)
        {
            if (Input.mousePosition.y >= Screen.height * (1 - cameraScrollratio / 100))
            {
                transform.Translate(Vector3.up * cameraMoveSpeed, Space.World);
            }
            else if (Input.mousePosition.y <= Screen.height * cameraScrollratio / 100)
            {
                transform.Translate(Vector3.down * cameraMoveSpeed, Space.World);
            }

            if (Input.mousePosition.x >= Screen.width * (1 - cameraScrollratio / 100))
            {
                transform.Translate(Vector3.right * cameraMoveSpeed, Space.World);
            }
            else if (Input.mousePosition.x <= Screen.width * cameraScrollratio / 100)
            {
                transform.Translate(Vector3.left * cameraMoveSpeed, Space.World);
            }
            sumTime = 0;
        }
    }
    
}
