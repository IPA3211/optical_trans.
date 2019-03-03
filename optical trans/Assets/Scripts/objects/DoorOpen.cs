using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    public GameObject w_button;
    public string nextScene;
    public Vector2 movePosition;
    private Animator animator;
    bool enter;
	bool e_click;

    // Start is called before the first frame update
    void Start()
    {
        enter = false;
		e_click = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enter == true) {

			if (Input.GetKeyDown (KeyCode.E) && e_click == false) 
            {
				e_click = true;
                w_button.SetActive (true);
                DoorSoundManager.instance.PlayDoorOpenSound();
                animator.SetBool("eButtonClicked", true);

			} 
			else if (Input.GetKeyDown (KeyCode.E) && e_click == true) 
            {
				e_click = false;
			    w_button.SetActive (false);
                DoorSoundManager.instance.PlayDoorCloseSound();
                animator.SetBool("eButtonClicked", false);                
			}
            else if(Input.GetKeyDown(KeyCode.W) && e_click == true)
            {
                SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
            }
		}
		else 
        {
			w_button.SetActive (false);
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {

		if (other.tag.Equals ("Player"))
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

    void OnLevelWasLoaded(int level)
    {
        DoorSoundManager.instance.PlayDoorCloseSound();
        GameObject.FindGameObjectWithTag ("Player").transform.position = movePosition;
    }
}
