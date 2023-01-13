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
    Vector3 prevSupportPos;
    public float detectionHeight;

    public float MaxCount;

    private void Start()
    {
        TMpro_Info.text = MaxCount.ToString();
        detectionHeight = MaxCount * (3f / 13f);
        prevSupportPos = Support.transform.position;
        InvokeRepeating(nameof(detactionBall), 1f, 0.5f);
    }

    float elapsedTime = 0f;
    int currentBallCount = 0;

    private void detactionBall()
    {
        if(currentBallCount >= MaxCount)
        {
            Destroy(gameObject);
            Instantiate(Particle_Destroy, transform.position, Quaternion.identity);
            return;
        }

        calculateSupportPos(currentBallCount);
        measureVolume();
    }

    int prevBallCount = 0;
    private void calculateSupportPos(int ballCount)
    {
        prevBallCount = currentBallCount;

        Vector3 newPos = new Vector3(prevSupportPos.x, prevSupportPos.y - (ballCount)/10f, prevSupportPos.z);
        Support.transform.position = newPos;
    }

    private void measureVolume()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, detectionRange, Quaternion.identity, 1 << 7);
        currentBallCount = hitColliders.Length;

        if (currentBallCount - prevBallCount == 0 && currentBallCount != 0 && prevBallCount != 0)
        {
            Invoke(nameof(delayGameOverEvent), 2f);
        }
    }

    private void delayGameOverEvent()
    {
        GameManager.Instance.activeGameOver();
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
