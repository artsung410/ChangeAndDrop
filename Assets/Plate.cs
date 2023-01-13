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
    private GameObject Support;

    [SerializeField]
    private TextMeshProUGUI TMpro_Info;

    [SerializeField]
    private GameObject Particle_Destroy;

    Vector3 detectionRange;
    float detectionHeight;

    public float MaxCount;

    private void Start()
    {
        TMpro_Info.text = MaxCount.ToString();
        detectionHeight = (MaxCount * 3) / 13;
        InvokeRepeating(nameof(DetactionBall), 1f, 0.5f);
    }

    float elapsedTime = 0f;
    int currentBallCount = 0;

    private void DetactionBall()
    {
        if(currentBallCount >= MaxCount)
        {
            Destroy(gameObject);
            Instantiate(Particle_Destroy, transform.position, Quaternion.identity);
            return;
        }

        CalculateSupportPos(currentBallCount);

        Collider[] hitColliders = Physics.OverlapBox(transform.position, detectionRange, Quaternion.identity, 1 << 7);
        currentBallCount = hitColliders.Length;
        elapsedTime = 0f;
    }

    private void CalculateSupportPos(int ballCount)
    {
        Vector3 prevPos = Support.transform.position;
        Vector3 newPos = new Vector3(prevPos.x, prevPos.y - (ballCount)/50f, prevPos.z);
        Support.transform.position = newPos;
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
