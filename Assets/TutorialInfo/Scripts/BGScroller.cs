using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    private Vector3 startPosition;
    private GameController gameController;
    private Timer timer;


    // Start is called before the first frame update
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

        GameObject timerObject = GameObject.FindGameObjectWithTag ("Timer");
		if (timerObject != null)
         {
			timer = timerObject.GetComponent  <Timer>();
        }
        if (timer == null)
		{
			Debug.Log ("Cannot find 'Timer' script");
		}
        
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
       transform.position = startPosition + Vector3.forward * newPosition;
       
       if (gameController.score >= 200 && timer.timeLeft == 0)
        scrollSpeed = 50;

    }
}
