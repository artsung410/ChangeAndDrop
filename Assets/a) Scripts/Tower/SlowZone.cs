using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class SlowZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Debug.Log("ball ¥Í¿Ω");
            Rigidbody rb = other.GetComponent<Ball>().rb;
            rb.velocity = Vector3.zero;
        }
    }
}
