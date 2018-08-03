using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Editor_ImageChanger : MonoBehaviour {
    public GameObject sourceObject;
    private GameObject firstObject = null;
    // Use this for initialization
    void Awake ()
    {
        try
        {
            gameObject.GetComponent<Image>().sprite = sourceObject.GetComponent<SpriteRenderer>().sprite;
        }
        catch {
            gameObject.GetComponent<SpriteRenderer>().sprite = sourceObject.GetComponent<SpriteRenderer>().sprite;
        }
    }

    // Update is called once per frame
    void Update() {
        if (firstObject == null || !firstObject.Equals(sourceObject))
        {
            firstObject = sourceObject;
            try
            {
                gameObject.GetComponent<Image>().sprite = sourceObject.GetComponent<SpriteRenderer>().sprite;
            }
            catch {
                gameObject.GetComponent<SpriteRenderer>().sprite = sourceObject.GetComponent<SpriteRenderer>().sprite;
            }
            Debug.Log("Editor causes this Update");
        }
    }
}
