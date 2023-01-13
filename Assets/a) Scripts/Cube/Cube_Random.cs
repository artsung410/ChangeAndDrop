using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class Cube_Random : Cube
{
    [SerializeField]
    private GameObject Obstacle;
    private bool onObstacles;

    protected override void Awake()
    {
        TMPro_CopyCount.text = $"???";
        ClickPanel.onSwitichingEvent += ChangeObject;
    }

    private void Start()
    {
        onObstacles = Obstacle.activeSelf;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (!onObstacles)
            {
                return;
            }

            Destroy(other.gameObject);
        }
    }

    bool isRandNumAssign;
    protected override void ChangeObject()
    {
        if (!isRandNumAssign)
        {
            int randNum = Random.Range(2, 10);
            copyCount = randNum;
            TMPro_CopyCount.text = $"X{copyCount}";
            isRandNumAssign = true;
        }

        onObstacles = !onObstacles;
        Obstacle.SetActive(onObstacles);
    }
}
