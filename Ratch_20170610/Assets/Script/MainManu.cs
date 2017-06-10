using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManu : MonoBehaviour
{
    public Transform canvas;

    public Transform MainMenu;
    public Transform OptionMenu;

    public Slider volumeSlider;
    public AudioSource Music;

    // Update is called once per frame
    void Update()
    {

    }


    public void Option()
    {
        MainMenu.gameObject.SetActive(false);
        OptionMenu.gameObject.SetActive(true);
    }

    public void OptionExit()
    {
        OptionMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }


    public void Volume()
    {
        Music.volume = volumeSlider.value;
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
