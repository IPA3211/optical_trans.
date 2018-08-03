using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor_ObjectBtn : MonoBehaviour {
    public GameObject sourceObject;
    public void ChangeSourceObject(GameObject sourceObject) {
        this.sourceObject = sourceObject;
        gameObject.GetComponent<Editor_ImageChanger>().sourceObject = this.sourceObject;
    }
    public void ChageFocus()
    {
        Editor_System editor_System = GameObject.Find("System").GetComponent<Editor_System>();
        editor_System.ChangeFocus(sourceObject);
    }
}
