using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    // ###############################################
    //             NAME : ARTSUNG                      
    //             MAIL : artsung410@gmail.com         
    // ###############################################

public class CameraController : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 10f);
    }
}
