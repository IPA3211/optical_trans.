using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundManager : MonoBehaviour
{
    public AudioClip doorClose; //재생할 소리를 변수로 담습니다.
	public AudioClip doorOpen;

    AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
    public static DoorSoundManager instance;  //자기자신을 변수로 담습니다.

    void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
    {
        if (DoorSoundManager.instance == null) //instance가 비어있는지 검사합니다.
        {
            DoorSoundManager.instance = this; //자기자신을 담습니다.
        }
    }

    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
    }		

	public void PlayDoorCloseSound()
	{
		myAudio.PlayOneShot(doorClose); //soundRealodaing을 재생합니다.
	}
	public void PlayDoorOpenSound()
	{
		myAudio.PlayOneShot(doorOpen); //gunfire을 재생합니다.
	}
}
