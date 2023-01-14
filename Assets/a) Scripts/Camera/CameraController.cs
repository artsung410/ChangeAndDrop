using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class CameraController : MonoBehaviour
{
    private Transform MasterTransform;
    float Distance;
    bool IsStop;

    private void OnEnable()
    {
        EndCollider.onCameraStopEvent += () => { IsStop = true; };
        Cup.onCreateMasterBallEvent += setMasterBall;
    }

    bool onDetaction = false;

    private void LateUpdate()
    {
        if (IsStop)
        {
            return;
        }

        if (!onDetaction)
        {
            return;
        }

        Vector3 newPos = new Vector3(transform.position.x, Distance + MasterTransform.position.y + 15f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * 3f);
    }

    private void setMasterBall(Transform transform)
    {
        MasterTransform = transform;
        Vector3 InterpolationPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Distance = Vector3.Distance(transform.position, InterpolationPos);
        onDetaction = true;
    }

    private void OnDisable()
    {
        Cup.onCreateMasterBallEvent -= setMasterBall;
    }
}
