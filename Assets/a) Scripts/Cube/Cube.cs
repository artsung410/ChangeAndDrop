using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// ###############################################
//             NAME : ARTSUNG                      
//             MAIL : artsung410@gmail.com         
// ###############################################

public enum CubeType
{
    Normal,
    Change,
    Switiching,
}

public enum CubeColor
{
    Blue,
    Orange
}

public class Cube : MonoBehaviour
{
    public int copyCount;
    public CubeType type;

    [SerializeField]
    protected TextMeshProUGUI TMPro_CopyCount;
    protected int currentPassCount = 0;
    protected MeshRenderer meshRenderer;

    protected virtual void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        TMPro_CopyCount.text = $"X{copyCount}";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ++currentPassCount;
            ++GameManager.Instance.CurrentBallCount;

            if (currentPassCount > copyCount)
            {
                return;
            }

            Ball myBall = other.GetComponent<Ball>();
            myBall.SetCubeInfo(copyCount, meshRenderer);
            myBall.ResizeCollider(false);
            myBall.CopyBall(other.gameObject);
        }
    }

}
