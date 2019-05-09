using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private float timer = 0;
    public GameObject tutorialWindow;
    public Text textBox;

    private bool msg1 = false;
    private bool msg2 = false;
    private bool msg3 = false;
    private bool msg4 = false;
    private bool msg5 = false;
    

    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 2 && !msg1)
        {
            tutorialWindow.SetActive(true);
            msg1 = true;
            textBox.text = "Available towers are displayed at the top and can be placed on the white tiles.";
        }

        if(timer >= 8 && !msg2)
        {
            tutorialWindow.SetActive(true);
            msg2 = true;
            textBox.text = "Enemies spawn at the green block and are trying to make it to the red block.";
        }
        if(timer >= 20 && !msg3)
        {
            tutorialWindow.SetActive(true);
            msg3 = true;
            textBox.text = "Level stats are displayed at the bottom. Earn money by killing enemies.";
        }
        if(timer >= 40 && !msg4)
        {
            tutorialWindow.SetActive(true);
            msg4 = true;
            textBox.text = "Click on placed towers to open the Tower Options window. Towers can be sold and upgraded here.";
        }
        if(timer >= 120 && !msg5)
        {
            tutorialWindow.SetActive(true);
            msg5 = true;
            textBox.text = "Your score is displayed in the top right. Increase your score by killing enemies and spending less money";
        }

    }

    public void closeWindow()
    {
        tutorialWindow.SetActive(false);
    }
}
