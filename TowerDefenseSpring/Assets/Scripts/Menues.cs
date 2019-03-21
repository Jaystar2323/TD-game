using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menues : MonoBehaviour
{
    //public WaveSpawner waveSpawner;
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
        SceneManager.LoadScene(level + 1);
    }
}
