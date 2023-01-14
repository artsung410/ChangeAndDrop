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

    private Coroutine Coroutine_DelayDropball;
    private Coroutine Coroutine_RotateCup;

    [SerializeField] 
    private float DelayDropTime;

    [SerializeField]
    private float RotateCycleTime;

    private WaitForSeconds CoCycle_Drop;
    private WaitForSeconds CoCycle_Rotate;

    private void OnEnable()
    {
        ClickPanel.onDropEvent += InitBall;
    }

    private void Start()
    {
        CoCycle_Drop = new WaitForSeconds(DelayDropTime);
        CoCycle_Rotate = new WaitForSeconds(RotateCycleTime);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isMoveAble)
            {
                return;
            }

            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, -Camera.main.transform.position.z));
            Debug.Log(point.x);

            transform.position = new Vector3(-5 + point.x / 2, transform.position.y, transform.position.z);
        }

    }
    private bool isMoveAble = true;

    private void InitBall()
    {
        isMoveAble = false;
        Coroutine_RotateCup = StartCoroutine(RotateCup());
    }

    private Ball myBall;

    private IEnumerator RotateCup()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return CoCycle_Rotate;
            transform.Rotate(-180f / 30, 0f, 0f);
        }

        Coroutine_DelayDropball = StartCoroutine(DelayDopBall());
    }

    private IEnumerator DelayDopBall()
    {
        yield return CoCycle_Drop;

        for (int i = 0; i < InitBallCount; i++)
        {
            Vector3 newPos = new Vector3(SpawnPoint.position.x + i * 0.5f, SpawnPoint.position.y, SpawnPoint.position.z);
            myBall = BallPool.GetObject(newPos);
            myBall.SetRadius(0.1f);
        }

        GameObject mBall = Instantiate(MasterBall, SpawnPoint.position, Quaternion.identity);
        onCreateMasterBallEvent.Invoke(mBall.transform);
    }

    private void OnDisable()
    {
        ClickPanel.onDropEvent -= InitBall;
    }

}
