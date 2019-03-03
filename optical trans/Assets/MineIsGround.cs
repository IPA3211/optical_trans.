using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineIsGround : MonoBehaviour
{
    public bool IsGround;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGround == true)
        {
			animator.Play ("MineBoom");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            if (other.GetComponent<Collider2D>().isTrigger == false) IsGround = true;
        }
        catch { }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        try
        {
            if (other.GetComponent<Collider2D>().isTrigger == false) IsGround = true;
        }
        catch { }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IsGround = false;
    }
}
