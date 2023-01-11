using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class DeathZone : MonoBehaviour
{
    public static event Action onFailEvent = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            onFailEvent.Invoke();
        }
    }
}
