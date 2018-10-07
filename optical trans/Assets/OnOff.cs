using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour {

    public void ChangeActive(GameObject other) {
        other.SetActive(!other.activeSelf);
    }
}
