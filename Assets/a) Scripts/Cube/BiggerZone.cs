using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class BiggerZone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Ball myBall = other.GetComponent<Ball>();
            myBall.ResizeCollider(true);
        }
    }
}
