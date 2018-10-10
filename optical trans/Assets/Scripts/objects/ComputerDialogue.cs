using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDialogue : MonoBehaviour {

    public GameObject e_button;
    public DialogueTrigger trigger;
    public Animator anim;
    bool enter;
    bool e_click;


    void Start()
    {
        anim.SetBool("IsOpen", false);
        enter = false;
        e_click = false;        
    }

    void Update()
    {
        if (enter == true)
        {
            e_button.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) && e_click == false)
            {
                anim.SetBool("IsOpen", true);
                e_click = true;
                trigger.TriggerDialogue();
            }
            else if (Input.GetKeyDown(KeyCode.E) && e_click == true)
            {
                anim.SetBool("IsOpen", false);
                e_click = false;
            }
            else if (Input.GetKeyDown(KeyCode.Return) && e_click == true)
            {
                if (FindObjectOfType<DialogueManager>().DisplayeNextSentence() == false)
                {

                }
                else
                {
                    anim.SetBool("IsOpen", false);
                    e_click = false;
                }
            }
        }
        else
        {
            e_button.SetActive(false);
            anim.SetBool("IsOpen", false);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals("Player"))
        {
            enter = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        enter = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            enter = true;
        }
    }
}
