using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip DoorSqueak;
    public AudioClip GameOver;
    public AudioClip GameClear;
    public AudioClip GetKey;
    public AudioClip Button;
    public AudioClip GetItem;

    private AudioSource myAudio;

    public static SoundManager instance; //static으로 선언하면 동적할당 말고 정적할당으로 선언됨

    void Awake() //start 함수보다 더 먼저 호출됨
    {
        if (SoundManager.instance == null)//거기에 아무 값이 없다면
            SoundManager.instance = this; //SoundManager.instance에 나 자신을 집어넣음
    }
	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
	}

    public void PlayDoorSound()
    {
        myAudio.PlayOneShot(DoorSqueak); //myAudio의 PlayOneShot함수를 쓰면 안에 있는 사운드가 재생됨
    }

    public void PlayGameOverSound()
    {
        myAudio.PlayOneShot(GameOver);
    }
	
    public void PlayGameClearSound()
    {
        myAudio.PlayOneShot(GameClear);
    }

    public void PlayButtonSound()
    {
        myAudio.PlayOneShot(Button);
    }

    public void PlayKeySound()
    {
        myAudio.PlayOneShot(GetKey);
    }

    public void PlayItemSound()
    {
        myAudio.PlayOneShot(GetItem);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
