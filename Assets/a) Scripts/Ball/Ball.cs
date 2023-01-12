using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private void Awake()
    {
        ClickPanel.onSwitichingEvent += ChangeColor;
        meshRenderer = GetComponent<MeshRenderer>();
        spherCollider = GetComponent<SphereCollider>();
    }

    public void CopyBall(GameObject obj)
    {
        GameObject newBall = Instantiate(obj, obj.transform.position, Quaternion.identity);
        Ball ball = newBall.GetComponent<Ball>();


        ++currentCopyCount;

        if (currentCopyCount >= currentCubeCopyCount)
        {
            currentCopyCount = 0;
            return;
        }

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
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            spherCollider.radius = spherCollider.radius + 0.5f / 100;
        }

        spherCollider.radius = 0.5f;
    }

    private void Smaller()
    {
        spherCollider.radius = 0.03f;
        ++GameManager.Instance.TempSmallerCount;
        Debug.Log(GameManager.Instance.TempSmallerCount);
    }

    private void OnDestroy()
    {
        ClickPanel.onSwitichingEvent -= ChangeColor;
    }
}
