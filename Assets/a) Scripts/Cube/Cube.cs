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

public class Cube : MonoBehaviour
{
    public int copyCount;
    public CubeType type;

    [SerializeField]
    protected TextMeshProUGUI TMPro_CopyCount;
    protected MeshRenderer meshRenderer;

    protected virtual void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        TMPro_CopyCount.text = $"X{copyCount}";
    }

    public int currentPassCount = 0;
    public int maxPassCount = 0;
    bool isAssign = false;
    
    private void OnTriggerExit(Collider other)
    {
        if (!isAssign)
        {
            maxPassCount = GameManager.Instance.CurrentBallCount;
            isAssign = true;
        }

        if (other.CompareTag("Ball"))
        {
            ++currentPassCount;

            if (currentPassCount > maxPassCount)
            {
                return;
            }

            Ball myBall = other.GetComponent<Ball>();
            myBall.SetCubeInfo(copyCount);
            myBall.CopyBall(other.gameObject);
        }
    }

}
