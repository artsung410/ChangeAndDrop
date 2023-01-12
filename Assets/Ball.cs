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

    private void Awake()
    {
        spherCollider = GetComponent<SphereCollider>();
    }

    public void copyBall(GameObject obj)
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

        copyBall(newBall);
    }

    public void setCubeInfo(int cubeCopyCount)
    {
        currentCubeCopyCount = cubeCopyCount;
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
