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

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            copyBall(other.gameObject);
        }
    }

    private void copyBall(GameObject obj)
    {
        for (int i = 0; i < copyCount - 1; i++)
        {
            GameObject newObj = Instantiate(obj);
        }
    }
}
