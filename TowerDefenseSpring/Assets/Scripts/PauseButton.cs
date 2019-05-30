using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    
    public GameObject pauseMenu;
    public static bool active = false;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePause);
    }

    
    void Update()
    {
        
    }

    public void TogglePause()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        pauseMenu.SetActive(!active);
        active = !active;
    }

}
