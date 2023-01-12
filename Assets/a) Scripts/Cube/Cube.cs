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
    Swap,
}

public class Cube : MonoBehaviour
{
    public int copyCount;
    public CubeType type;

    [SerializeField]
    private TextMeshProUGUI TMPro_CopyCount;


    private void Awake()
    {
        TMPro_CopyCount.text = $"X{copyCount}";
    }

    private int currentPassCount = 0;
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
            myBall.setCubeInfo(copyCount);
            myBall.ResizeCollider(false);
            myBall.copyBall(other.gameObject);
        }
    }
}
