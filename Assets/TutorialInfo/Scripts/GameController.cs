﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public GameObject [] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    private bool win;
    private bool gameOver;
    private bool restart;
private int score;
    void Start()
    {   gameOver = false;
    restart =false;
    win = false;

    winText.text = "";
    restartText.text = "";
    gameOverText.text ="";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }
    void Update ()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.P))
            {
                Application.LoadLevel (Application.loadedLevel);

            }
        }
    }
    IEnumerator SpawnWaves ()
    {   
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i< hazardCount; i++)
            {
            GameObject hazard = hazards [Random.Range (0,hazards.Length)];    
            Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds (spawnWait);
            }   
            yield return new WaitForSeconds (waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'P' for Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
{
score += newScoreValue;
UpdateScore();
}

void UpdateScore()
 {
        ScoreText.text = "Score: " + score;
        if (score >= 100)
          {
            winText.text = "You win! GAME CREATED BY Daniel Vanderbrink";
            gameOver = true;
            restart = true;
           }
      }

public void GameOver ()
{
    gameOverText.text = "Game Over! GAME CREATED BY Daniel Vanderbrink";
    gameOver = true;
    }
}
