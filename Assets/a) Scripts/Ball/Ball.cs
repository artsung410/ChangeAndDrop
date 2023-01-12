using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class Ball : MonoBehaviour
{
    public int currentCopyCount;
    public int currentCubeCopyCount;

    SphereCollider spherCollider;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        Cube_Change.onCubeSwitichingEvent += ChangeColor;
        meshRenderer = GetComponent<MeshRenderer>();
        spherCollider = GetComponent<SphereCollider>();
    }

    public void CopyBall(GameObject obj)
    {
        GameObject newBall = Instantiate(obj, obj.transform.position, Quaternion.identity);
        Ball ball = newBall.GetComponent<Ball>();
        ball.ResizeCollider(false);

        ++currentCopyCount;

        if (currentCopyCount >= currentCubeCopyCount)
        {
            currentCopyCount = 0;
            return;
        }

        CopyBall(newBall);
    }

    public void SetCubeInfo(int cubeCopyCount, MeshRenderer meshRenderer)
    {
        currentCubeCopyCount = cubeCopyCount;
        this.meshRenderer.material.color = meshRenderer.material.color;
    }

    public void ChangeColor(MeshRenderer meshRenderer)
    {
        this.meshRenderer.material.color = meshRenderer.material.color;
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
    }

    private void Smaller()
    {
        spherCollider.radius = 0.03f;
    }
}
