using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update

    public static float score;
    private static float towerSellValue;
    private static float moneyValue;
    private static float scoreMultiplier;
    private static int currLevel;
    public static float highScore;
    public static bool gameEnded;
    public Text text;
    public Text HS;

    [Header("Level Complete")]
    public Text scoreLC;
    public Text moneyLC;
    public Text hsLC;
    public Text livesLC;

    // Update is called once per frame
    void Start()
    {
        Debug.Log("Score Start");
        //PlayerPrefs.SetFloat("highScore" + currLevel, 0);

        currLevel = SceneManager.GetActiveScene().buildIndex;
        highScore = PlayerPrefs.GetFloat("highScore" + currLevel, 0);
    }
    void Update()
    {
        Debug.Log(scoreMultiplier);
        if(text != null)
        {
            text.text = "Score: " + (int)score;
        }
        if (HS != null)
        {
            HS.text = "High Score: " + (int)highScore;
        }
        if(scoreLC != null)
        {
            scoreLC.text = "Score: " + (int)score;
        }
        if(moneyLC != null)
        {
            moneyLC.text = "Money Remaining: " + PlayerStats.money;
        }
        if(livesLC != null)
        {
            livesLC.text = "Lives Remaining: " + WaveSpawner.lives;
        }
        if(hsLC != null)
        {
            hsLC.text = "Highscore: " + (int)highScore;
        }
    }

    public static void scoreKill(Enemy enemy)
    {
        int baseScore = 0;
        if (enemy.name == "Enemy(Clone)")
        {
            baseScore += 50;
        }
        else if (enemy.name == "EnemyFast(Clone)")
        {
            baseScore += 70;
        }
        else if (enemy.name == "EnemyBig(Clone)")
        {
            baseScore += 125;
        }
        else if (enemy.name == "EnemySmall")
        {
            baseScore += 15;
        }
        else if(enemy.name == "EnemySmall2")
        {
            baseScore += 20;
        }
        else if(enemy.name == "EnemyFast2(Clone)")
        {
            baseScore += 90;
        }
        else if(enemy.name == "EnemySplitterSmall")
        {
            baseScore += 80;
        }
        else if(enemy.name == "EnemySplitter")
        {
            baseScore += 110;
        }

        calcScore(baseScore);

    }

    private static void calcScore(int baseScore)
    {
        scoreMultiplier = 1;
        moneyValue = PlayerStats.money;
        scoreMultiplier += WaveSpawner.lives * .65f;
        scoreMultiplier += (towerSellValue + (moneyValue * 1.2f)) * 0.00065f;

        score += baseScore * scoreMultiplier;
    }

    public static void addTowerValue(int sellValue)
    {
        towerSellValue += sellValue;
    }

    public static void resetValues()
    {
        towerSellValue = 0;
        moneyValue = 0;
        
        //if (score > 0)
        //{
        //    gameEnded = true;
        //}
        //Debug.Log(highScore);
        scoreMultiplier = 0;
        score = 0;

    }

    public static void checkScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore" + currLevel, highScore);
        }
    }


}
