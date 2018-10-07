using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}
	
	public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start conversation of " + dialogue.name);
        //StartCoroutine(WaitAnimation());

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Invoke("DisplayeNextSentence", 0.3f);
        //DisplayeNextSentence();
    }

    public bool DisplayeNextSentence()
    {
        if(sentences.Count == 0){
            EndDialogue();
            return true;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);

        return false;
    }

    IEnumerator WaitAnimation()
    {
        Debug.Log("5 seconds wait");
        yield return new WaitForSeconds(5);
        Debug.Log("5 seconds passed");
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }


    void EndDialogue()
    { 
        Debug.Log("End of conversation");
    }
}
