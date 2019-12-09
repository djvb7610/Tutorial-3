using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private PlayerScript playerScript;
    // Start is called before the first frame update
   void Start ()
	{
		GameObject playerScriptObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerScriptObject != null)
       {
			playerScript = playerScriptObject.GetComponent  <PlayerScript>();
        }
        if (playerScript == null)
		{
			Debug.Log ("Cannot find 'PlayerScript' script");
		}
	}
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
        playerScript.fireRate = .1f;
        Destroy (gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
