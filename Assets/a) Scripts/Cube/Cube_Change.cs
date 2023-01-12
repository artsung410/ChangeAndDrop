using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class Cube_Change : Cube
{
    public static event Action<MeshRenderer> onCubeSwitichingEvent = delegate { };

    [SerializeField]
    private GameObject Obstacle;

    private bool onObstacles;

    private void Start()
    {
        onObstacles = Obstacle.activeSelf;
    }

    private void OnMouseDown()
    {
        if (!onObstacles)
        {
            return;
        }

        ChangeObject();
        onCubeSwitichingEvent.Invoke(meshRenderer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!onObstacles)
        {
            return;
        }

        Destroy(other.gameObject);
    }

    private void ChangeObject()
    {
        onObstacles = !onObstacles;
        Obstacle.SetActive(onObstacles);
    }
}
