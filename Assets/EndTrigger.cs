using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// ###############################################
//             NAME : ARTSUNG                      
//             MAIL : artsung410@gmail.com         
// ###############################################

public class EndTrigger : MonoBehaviour
{
    public int Count = 0;
    float elapsedTime;
    bool isReadyToCheck = false;
    bool isGameWin = false;

    public static event Action onGameClearEvent = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isReadyToCheck = true;
            elapsedTime = 0f;
        }
    }

    private void Update()
    {
        if (!isReadyToCheck)
        {
            return;
        }

        if (isGameWin)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 2f)
        {
            Debug.Log("°ÔÀÓ½Â¸®1!!");
            isGameWin = true;
            onGameClearEvent.Invoke();
        }
    }
}
