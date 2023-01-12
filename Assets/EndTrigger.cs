using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class EndTrigger : MonoBehaviour
{
    public int Count = 0;

    float elapsedTime;
    bool isReadyToCheck = false;

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

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 2f)
        {
            Debug.Log("GameWin");
        }
    }
}
