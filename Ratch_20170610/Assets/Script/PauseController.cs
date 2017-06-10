using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {

    public Transform canvas;
    public Transform GameOverCanvas;

    public Transform MainMenu;
    public Transform InterfaceMenu;
    public Transform SoundMenu;

    public Slider volumeSlider;
    public AudioSource Music;

    // Update is called once per frame
    void Update () {
        Pause();
	}

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        SoundManager.instance.PlayButtonSound();
    }

    public void Interface()
    {
        MainMenu.gameObject.SetActive(false);
        InterfaceMenu.gameObject.SetActive(true);
        SoundManager.instance.PlayButtonSound();
    }

    public void InterfaceExit()
    {
        InterfaceMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        SoundManager.instance.PlayButtonSound();
    }

    public void Sound()
    {
        MainMenu.gameObject.SetActive(false);
        SoundMenu.gameObject.SetActive(true);
        SoundManager.instance.PlayButtonSound();
    }

    public void Volume()
    {
        Music.volume = volumeSlider.value;
    }

    public void SoundExit()
    {
        SoundMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
        SoundManager.instance.PlayButtonSound();
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        SoundManager.instance.PlayButtonSound();
    }

    public void Restart()
    {
        GameOverCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        SoundManager.instance.PlayButtonSound();
    }

}
