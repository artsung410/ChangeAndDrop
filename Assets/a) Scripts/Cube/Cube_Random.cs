using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class Cube_Random : Cube
{
    [SerializeField]
    private GameObject Obstacle;
    private bool onObstacles;

    private void OnEnable()
    {
        TMPro_CopyCount.text = $"???";
        ClickPanel.onSwitichingEvent += ChangeObject;
    }

    Camera selectedCamera;
    private void Start()
    {
        selectedCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
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

    bool isRandNumAssign;
    protected override void ChangeObject()
    {
        if (!isRandNumAssign && CheckLookAtMe())
        {
            int randNum = Random.Range(2, 5);
            copyCount = randNum;
            TMPro_CopyCount.text = $"X{copyCount}";
            isRandNumAssign = true;
        }

        onObstacles = !onObstacles;
        Obstacle.SetActive(onObstacles);
    }

    public bool CheckLookAtMe()//카메라 뷰 안에 적이 있는지 없는지
    {
        Vector3 interpolatePos = new Vector3(transform.position.x, transform.position.y - 15f, transform.position.z);
        Vector3 viewPos = selectedCamera.WorldToViewportPoint(interpolatePos);
        bool OnLookAt = viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1;
        return OnLookAt;
    }

    private void OnDisable()
    {
        ClickPanel.onSwitichingEvent -= ChangeObject;
    }
}
