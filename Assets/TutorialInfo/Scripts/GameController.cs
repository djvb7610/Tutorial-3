using System.Collections;
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
public int score;
public int score2;
private BGScroller bGScroller;
public AudioClip musicClipOne;

public AudioClip musicClipTwo;

public AudioSource musicSource;
private Timer timer;


    void Start()
    { 
       
          gameOver = false;
    restart =false;
    win = false;

    winText.text = "";
    restartText.text = "";
    gameOverText.text ="";
        score = 0;
        score2 = 0;

        GameObject timerObject = GameObject.FindGameObjectWithTag ("Timer");
		if (timerObject != null)
         {
			timer = timerObject.GetComponent  <Timer>();
        }
        if (timer == null)
		{
			Debug.Log ("Cannot find 'Timer' script");
		}

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
    {
        if(score2 >= 200 && timer.timeLeft == 0)
           Boo();
           void Boo()
           {
                musicSource.clip = musicClipOne;
          musicSource.PlayOneShot(musicClipOne, 0.7F);
          score2 = 0;
          gameOver = true;
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
score2+= newScoreValue;

UpdateScore();
}

void UpdateScore()
 {
        ScoreText.text = "Points: " + score;
        if (score >= 200 && timer.timeLeft == 0)
          {
            
            gameOver = true; 
            restart = true;
            
           }
           else if(score <= 199 && timer.timeLeft == 0)
           {
               gameOver = true;
               restart = true;
           }

           //if(score2 >= 100 && timer.timeLeft == 0)
           //Boo();
           //void Boo()
           //{
            //    musicSource.clip = musicClipOne;
          //musicSource.PlayOneShot(musicClipOne, 0.7F);
         // score2 = 0;
          // }

      }
 
public void GameOver ()
{
    
    gameOverText.text = "Game Over! GAME CREATED BY Daniel Vanderbrink";
    gameOver = true;
    musicSource.clip =musicClipTwo;
    musicSource.Play();
    }
}

