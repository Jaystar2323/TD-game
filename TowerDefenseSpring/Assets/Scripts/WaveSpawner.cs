using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform enemyFastPrefab;
    public Transform enemyBigPrefab;
    public Transform enemySmallPrefab;
    public Transform enemySmall2Prefab;
    public Transform enemyFast2Prefab;
    public Transform enemySplitterPrefab;

    public GameObject gameOverScreen;
    public GameObject levelComplete;

    public Transform spawnPoint;

    public float timeBetweenWaves = 35f;


    private float countDown = 10f;

    private int waveNumber = 0;
    public static int lives = 10;
    public Text waveCountdownText;
    public Text waveNumberText;
    public Text livesText;
    public int totalWaveCount = 15;


    [Header("Waves")]
    public WaveList wave1;
    public WaveList wave2;
    public WaveList wave3;
    public WaveList wave4;
    public WaveList wave5;
    public WaveList wave6;
    public WaveList wave7;
    public WaveList wave8;
    public WaveList wave9;
    public WaveList wave10;
    public WaveList wave11;
    public WaveList wave12;
    public WaveList wave13;
    public WaveList wave14;
    public WaveList wave15;

    private List<WaveList> waves = new List<WaveList>();

    private void Start()
    {
        Debug.Log("START");
        waves.Add(wave1);
        waves.Add(wave2);
        waves.Add(wave3);
        waves.Add(wave4);
        waves.Add(wave5);
        waves.Add(wave6);
        waves.Add(wave7);
        waves.Add(wave8);
        waves.Add(wave9);
        waves.Add(wave10);
        waves.Add(wave11);
        waves.Add(wave12);
        waves.Add(wave13);
        waves.Add(wave14);
        waves.Add(wave15);
        lives = 10;
        gameOverScreen.SetActive(false);
        levelComplete.SetActive(false);
    }

    void Update()
    {
        if(waveNumber == 0)
        {
            Scoring.resetValues();
            
        }
        if(countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            
        }
        if(lives <= 0)
        {
            gameOverScreen.SetActive(true);
        }
        if(waveNumber >= totalWaveCount)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length == 0)
            {
                this.levelComplete.SetActive(true);
                PlayerStats.levelEnd();
            }
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveNumberText.text = "Wave " + waveNumber;
        livesText.text = "Lives " + lives;
        waveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        waveNumber += 1;
        timeBetweenWaves += 1f;

        if (waveNumber % 3 == 0 && waveNumber != 0)
        {
            PlayerStats.money += (300 * waveNumber/3);
        }
        // if (wavenumber - 1 >= waves.count)
        //  {
        //for (int i = 0; i < waveNumber * 2; i++)
        //{
        //    Debug.Log("HI!");
        //    SpawnEnemy();
        //    if (waveNumber >= 7 && i % 4 == 0)
        //    {
        //        Instantiate(enemyFastPrefab, spawnPoint.position, spawnPoint.rotation);
        //    }
        //    if (waveNumber >= 10 && i % 9 == 0)
        //    {
        //        Instantiate(enemyBigPrefab, spawnPoint.position, spawnPoint.rotation);
        //    } 
        //    if (waveNumber >= 4 && i % 3 == 0)
        //    {
        //        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        //    }
        //    if (waveNumber >= 20 && i % 20 == 0)
        //    {
        //        Instantiate(enemyFast2Prefab, spawnPoint.position, spawnPoint.rotation);

        //    }


        //    yield return new WaitForSeconds(0.7f);
        //}
        //  }
        if ((waveNumber - 1) >= totalWaveCount || lives <= 0)
        {
            yield break;
        }
        //Debug.Log(waveNumber + " " + waves.Count);
        //if(waveNumber-1 >= waves.Count)
        //{
        //Debug.Log(waves[waveNumber].highestCount());
        //Debug.Log("Run");
        for (int i = 0; i < waves[waveNumber-1].highestCount(); i++)
        {

            //SpawnEnemy();'
            //Debug.Log("Loop");
            if (waves[waveNumber - 1].numBig > 0 && i%2 == 0)
            {
                waves[waveNumber - 1].numBig -= 1;
                Instantiate(enemyBigPrefab, spawnPoint.position, spawnPoint.rotation);

            }
            if (waves[waveNumber - 1].numFast > 0)
            {
                waves[waveNumber - 1].numFast -= 1;
                Instantiate(enemyFastPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            if (waves[waveNumber - 1].numFast2 > 0)
            {
                waves[waveNumber - 1].numFast2 -= 1;
                Instantiate(enemyFast2Prefab, spawnPoint.position, spawnPoint.rotation);
            }
            if (waves[waveNumber - 1].numNormal > 0)
            {
                waves[waveNumber - 1].numNormal -= 1;

                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            if (waves[waveNumber - 1].numCluster > 0)
            {
                waves[waveNumber - 1].numCluster -= 1;
                Instantiate(enemySmallPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            if (waves[waveNumber - 1].numCluster2 > 0)
            {
                waves[waveNumber - 1].numCluster2 -= 1;
                Instantiate(enemySmall2Prefab, spawnPoint.position, spawnPoint.rotation);
            }
            if(waves[waveNumber - 1].numSplitter > 0 && i%2 ==0)
            {
                waves[waveNumber - 1].numSplitter -= 1;
                Instantiate(enemySplitterPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            //Debug.Log(waves[waveNumber - 1].timeBetweenSpawns);
            yield return new WaitForSeconds(waves[waveNumber-1].timeBetweenSpawns);

        }
        //}    

    }

    void SpawnEnemy()
    {
        if (waveNumber <= 13)
        {
            Instantiate(enemySmallPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(enemySmall2Prefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
    public static void loseLives(int num)
    {
        lives -= num;
    }
    
    public int getWaveNumber()
    {
        return waveNumber;
    }

    public void resetLives()
    {
        lives = 10;
        gameOverScreen.SetActive(false);
    }

}
