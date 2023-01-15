using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// ###############################################
//             NAME : ARTSUNG                      
//             MAIL : artsung410@gmail.com         
// ###############################################

public enum BallColor
{
    Blue,
    Orange
}

public class Ball : MonoBehaviour
{
    private int currentCopyCount;
    private int currentCubeCopyCount;

    SphereCollider sphereCollider;
    MeshRenderer meshRenderer;

    [SerializeField]
    private List<Material> materials;

    private TrailRenderer trailRenderer;

    private BallColor ballColor;
    private Rigidbody rb;

    private Coroutine Coroutine_DelayBigger;

    [SerializeField]
    private float DelayBiggerTime;

    private WaitForSeconds CoCycle_Bigger;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();

        Init();

        // 꼬리효과 설정
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.startColor = meshRenderer.material.color;

        // 마우스 클릭시 이벤트
        ClickPanel.onSwitichingEvent += ChangeColor;
    }

    private void Start()
    {
        CoCycle_Bigger = new WaitForSeconds(DelayBiggerTime);
    }

    public void Init()
    {
        rb.velocity = Vector3.zero;
    }

    public void CopyBall(GameObject obj)
    {
        ++currentCopyCount;

        if (currentCopyCount >= currentCubeCopyCount)
        {
            currentCopyCount = 0;
            return;
        }

        Ball ball = BallPool.GetObject(obj.transform.position);
        ball.CopyColor(meshRenderer.material.color);
        ball.ResizeCollider();
        ball.rb.velocity = rb.velocity;
        ++GameManager.Instance.CurrentBallCount;
        CopyBall(ball.gameObject);
    }

    public void SetCubeInfo(int cubeCopyCount)
    {
        currentCubeCopyCount = cubeCopyCount;
    }

    public void ChangeColor()
    {
        if (ballColor == BallColor.Blue)
        {
            meshRenderer.material = materials[(int)BallColor.Orange];
            trailRenderer.startColor = meshRenderer.material.color;
            ballColor = BallColor.Orange;
        }
        else
        {
            meshRenderer.material = materials[(int)BallColor.Blue];
            trailRenderer.startColor = meshRenderer.material.color;
            ballColor = BallColor.Blue;
        }
    }

    public void SetRadius(float radius)
    {
        sphereCollider.radius = radius;
    }

    public void CopyColor(Color color)
    {
        meshRenderer.material.color = color;
        trailRenderer.startColor = color;
    }

    public void ResizeCollider()
    {
        sphereCollider.radius = 0.1f;
        Coroutine_DelayBigger = StartCoroutine(DelayBigger());
    }


    private int intervalCout = 10;
    private IEnumerator DelayBigger()
    {
        for(int i = 0; i < intervalCout; i++)
        {
            yield return CoCycle_Bigger;
            sphereCollider.radius = 0.05f * i;
        }
    }


    private void OnDestroy()
    {
        ClickPanel.onSwitichingEvent -= ChangeColor;
    }
}
