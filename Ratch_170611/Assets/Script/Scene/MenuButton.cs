using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton: MonoBehaviour {

    public Transform Option;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickStart()
    {
        SceneManager.LoadScene("Intro");
        SoundManager.instance.PlayButtonSound();
    }

    public void ClickSkip()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void ClickExit()
    {
        Application.Quit();
        SoundManager.instance.PlayButtonSound();
    }

    public void ClickOption()
    {
        Option.gameObject.SetActive(true);
        SoundManager.instance.PlayButtonSound();
    }

    public void OptionExit()
    {
        Option.gameObject.SetActive(false);
        SoundManager.instance.PlayButtonSound();
    }
}
