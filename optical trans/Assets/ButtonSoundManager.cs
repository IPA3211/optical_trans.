using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManager : MonoBehaviour {

    public AudioClip button_clicked;

    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
    public static ButtonSoundManager instance;  //자기자신을 변수로 담습니다.

    void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
    {
        if (ButtonSoundManager.instance == null) //instance가 비어있는지 검사합니다.
        {
            ButtonSoundManager.instance = this; //자기자신을 담습니다.
        }
    }

    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
    }

    void Update()
    {

    }

    public void PlayButtonSound()
    {
        myAudio.PlayOneShot(button_clicked);
    }
}
