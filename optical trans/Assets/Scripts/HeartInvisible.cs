using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartInvisible : MonoBehaviour {
    
    void OnFinishedInvincibleMode()
    {
        gameObject.SetActive(false);
    }
}
