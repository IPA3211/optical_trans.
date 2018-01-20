using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSoundManager : MonoBehaviour
{
	public AudioClip warp_start;
	public AudioClip warp_end;

	AudioSource myAudio; //AudioSorce 컴포넌트를 변수로 담습니다.
	public static WarpSoundManager instance;  //자기자신을 변수로 담습니다.

	void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
	{
		if (WarpSoundManager.instance == null) //instance가 비어있는지 검사합니다.
		{
			WarpSoundManager.instance = this; //자기자신을 담습니다.
		}
	}

	void Start()
	{
		myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource 오브젝트를 변수로 담습니다.
	}		

	void Update()
	{

	}

	public void PlayWarpStartSound()
	{
		myAudio.PlayOneShot(warp_start);
	}
	public void PlayWarpEndtSound()
	{
		myAudio.PlayOneShot(warp_end);
	}
}