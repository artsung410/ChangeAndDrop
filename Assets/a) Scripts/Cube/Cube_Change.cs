using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class Cube_Change : Cube
{

    [SerializeField]
    private GameObject Obstacle;
    private bool onObstacles;

    protected override void Awake()
    {
        base.Awake();
        ClickPanel.onSwitichingEvent += ChangeObject;
    }

    private void Start()
    {
        onObstacles = Obstacle.activeSelf;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (!onObstacles)
            {
                return;
            }

            Ball ball = other.GetComponent<Ball>();
            ball.Init();
            BallPool.ReturnObject(ball);
            --GameManager.Instance.CurrentBallCount;
            ++GameManager.Instance.DeletedBallCount;
        }
    }

    protected override void ChangeObject()
    {
        onObstacles = !onObstacles;
        Obstacle.SetActive(onObstacles);
    }

    private void OnDestroy()
    {
        ClickPanel.onSwitichingEvent -= ChangeObject;
    }
}
