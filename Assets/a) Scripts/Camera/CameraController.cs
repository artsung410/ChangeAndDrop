using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform MasterBallTransform;
    float Distance;
    bool IsStop;

    private void Awake()
    {
        EndCollider.onCameraStopEvent += () => { IsStop = true; };
    }

    private void Start()
    {
        Vector3 InterpolationPos = new Vector3(transform.position.x, MasterBallTransform.position.y, transform.position.z);
        Distance = Vector3.Distance(transform.position, InterpolationPos);
    }

    private void LateUpdate()
    {
        if (IsStop)
        {
            return;
        }

        Vector3 newPos = new Vector3(transform.position.x, Distance + MasterBallTransform.position.y + 15f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * 3f);
    }
}
