using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    private int selectedLevel;
    public Text scoreText;
    public GameObject background;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerPrefs.GetFloat("highscore" + selectedLevel + 3, 0).ToString();
    }

    public void switchBackground(Image img)
    {
        background.GetComponent<Image>()
    }

}
