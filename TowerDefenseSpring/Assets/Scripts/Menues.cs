﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menues : MonoBehaviour
{
    //public WaveSpawner waveSpawner;
    public GameObject background1;
    public GameObject background2;

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //waveSpawner.resetLives();
    }
    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadLevel(int level)
    {
        SceneManager.LoadScene(level + 2);
    }
    public void loadHowToPlay()
    {
        SceneManager.LoadScene(2);
    }
    public void quitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
        
    }

    public void switchToBackground1()
    {
        background1.SetActive(true);
        background2.SetActive(false);

    }
    public void switchToBackground2()
    {
        background2.SetActive(true);
        background1.SetActive(false);
    }

}
