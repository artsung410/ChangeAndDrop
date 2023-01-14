using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class Cup : MonoBehaviour
{
    public static event Action<Transform> onCreateMasterBallEvent = delegate { };

    [SerializeField]
    private int InitBallCount;

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    private GameObject MasterBall;

    private void OnEnable()
    {
        ClickPanel.onDropEvent += InitBall;
    }

    private void InitBall()
    {
        StartCoroutine(RotateCup());
    }

    Ball myBall;
    private IEnumerator DelayDopBall()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < InitBallCount; i++)
        {
            Vector3 newPos = new Vector3(SpawnPoint.position.x + i * 0.5f, SpawnPoint.position.y, SpawnPoint.position.z);
            myBall = BallPool.GetObject(newPos);
            myBall.SetRadius(0.1f);
        }

        GameObject mBall = Instantiate(MasterBall, SpawnPoint.position, Quaternion.identity);
        onCreateMasterBallEvent.Invoke(mBall.transform);
    }


    private IEnumerator RotateCup()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(-180f / 30, 0f, 0f);
        }

        StartCoroutine(DelayDopBall());
    }

    private void OnDisable()
    {
        ClickPanel.onDropEvent -= InitBall;
    }
}
