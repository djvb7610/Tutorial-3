using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFieldSpeed : MonoBehaviour
{

   
    private GameController gameController;
  private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    private Timer timer;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
         {
			gameController = gameControllerObject.GetComponent  <GameController>();
        }
        if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
        ps = GetComponent<ParticleSystem>();

         GameObject timerObject = GameObject.FindGameObjectWithTag ("Timer");
		if (timerObject != null)
         {
			timer = timerObject.GetComponent  <Timer>();
        }
        if (timer == null)
		{
			Debug.Log ("Cannot find 'Timer' script");
		}
    }

    void Update()
    {
         if (gameController.score >= 200 && timer.timeLeft == 0)
         {
        var main = ps.main;
        main.simulationSpeed = 50;
    }
    }
}