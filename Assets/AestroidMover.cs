using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AestroidMover : MonoBehaviour
{ public float speed;
private AestroidMover aestroidMover;
     private Rigidbody rb;
     
    // Start is called before the first frame update
  void Start()
 {
    
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
     }
     void Update()
     { 
         // if (Input.GetKey (KeyCode.H))
          //{
           //rb.velocity = transform.forward * -10;
         // }
          
               
           
                     
          
          
     }
}