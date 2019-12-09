using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timer; 
public int timeLeft = 30; //Seconds Overall
private GameController gameController;
 

  void Start () {
    StartCoroutine("LoseTime");
    Time.timeScale = 1; //Just making sure that the timeScale is right

    GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
         {
			gameController = gameControllerObject.GetComponent  <GameController>();
        }
        if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
  }
  void Update () 
  {
    timer.text = ("" + timeLeft); //Showing the Score on the Canvas

    if (gameController.score >= 200 && timeLeft == 0)
    {
    gameController.winText.text = "You win! GAME CREATED BY Daniel Vanderbrink";
    }
    if (gameController.score <= 199 && timeLeft == 0)
    {
      //gameController.gameOverText.text = "Game Over! GAME CREATED BY Daniel Vanderbrink";
      gameController.GameOver();
    //gameController.musicSource.clip = gameController.musicClipTwo;
      //gameController.musicSource.Play();
    }
  }
  //Simple Coroutine
  IEnumerator LoseTime()
  {
    while (timeLeft > 0) {
      yield return new WaitForSeconds (1);
      timeLeft--; 
    }
  }
} 