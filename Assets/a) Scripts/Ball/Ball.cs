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
    int currentCopyCount;
    int currentCubeCopyCount;

    SphereCollider spherCollider;
    MeshRenderer meshRenderer;

    [SerializeField]
    private List<Material> materials;

    public BallColor ballColor;
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ClickPanel.onSwitichingEvent += ChangeColor;
        meshRenderer = GetComponent<MeshRenderer>();
        spherCollider = GetComponent<SphereCollider>();
    }

    public void CopyBall(GameObject obj)
    {
        ++currentCopyCount;

        if (currentCopyCount >= currentCubeCopyCount)
        {
            currentCopyCount = 0;
            return;
        }

        GameObject newBall = Instantiate(obj, obj.transform.position, Quaternion.identity);
        Ball ball = newBall.GetComponent<Ball>();
        ball.ResizeCollider(false);
        ++GameManager.Instance.CurrentBallCount;
        CopyBall(newBall);
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
            ballColor = BallColor.Orange;
        }
        else
        {
            meshRenderer.material = materials[(int)BallColor.Blue];
            ballColor = BallColor.Blue;
        }
    }

    public void ResizeCollider(bool onBigger)
    {
        if (onBigger)
        {
            StartCoroutine(Bigger());
        }
        else
        {
            Smaller();
        }
    }

    private IEnumerator Bigger()
    {
        yield return new WaitForSeconds(0.05f);
        spherCollider.radius = 0.5f;
    }

    private void Smaller()
    {
        spherCollider.radius = 0.03f;
    }

    private void OnDestroy()
    {
        ClickPanel.onSwitichingEvent -= ChangeColor;
    }
}
