using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
    public static DontDestroyOnLoad instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(transform.gameObject);
    }
}
