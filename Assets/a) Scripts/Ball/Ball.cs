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

    public BallColor ballColor;
    public Rigidbody rb;

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
        StartCoroutine(DelayBigger());
    }

    private IEnumerator DelayBigger()
    {
        yield return new WaitForSeconds(0.5f);
        sphereCollider.radius = 0.5f;
    }



    private void OnDestroy()
    {
        ClickPanel.onSwitichingEvent -= ChangeColor;
    }
}
