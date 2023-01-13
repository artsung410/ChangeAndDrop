using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class Plate : MonoBehaviour
{
    [SerializeField]
    private GameObject SupportCollider;

    [SerializeField]
    private TextMeshProUGUI TMpro_Info;

    Vector3 detectionRange;
    float detectionHeight;

    public float detectionCount = 40;

    private void Start()
    {
        TMpro_Info.text = detectionCount.ToString();
        detectionHeight = (detectionCount * 3) / 26;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        detectionRange = new Vector3(16f, detectionHeight, 1);
        Gizmos.DrawWireCube
            (
                transform.position,
                detectionRange
            );
    }
}
