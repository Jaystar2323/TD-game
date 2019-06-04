using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    private int selectedLevel;
    public Text scoreText;
    public GameObject background;
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button level4;
    public Button level5;
    private int score;

    private Button[] levels;

    void Start()
    {
        selectedLevel = 1;
        levels = new Button[] {Level1, Level2, Level3, level4, level5};
    }
    // Update is called once per frame
    void Update()
    {
        score = ((int)(PlayerPrefs.GetFloat("highScore" + (selectedLevel + 3), 0)));
        scoreText.text = score.ToString("n0");

        //levels[selectedLevel - 1].enabled = false;
        //for(int i = 0; i < 5; i++)
        //{
        //    if(i != selectedLevel)
        //    {
        //        levels[i].enabled = true;
        //    }
        //}
        //Debug.Log(selectedLevel);
    }

    public void switchBackground(Sprite img)
    {
        background.GetComponent<Image>().sprite = img;
       // selectedLevel = level;

    }
    public void setLevel(int level)
    {
        selectedLevel = level;
    }
    
    public void loadLevel()
    {
        SceneManager.LoadScene(selectedLevel + 3);
    }
}
