using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class EndCollider : MonoBehaviour
{
    public static event Action onCameraStopEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            onCameraStopEvent.Invoke();
            Debug.Log("카메라 종료");
        }
    }
}
