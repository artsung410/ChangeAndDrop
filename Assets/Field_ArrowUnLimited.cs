using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_ArrowUnLimited : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("플레이어 충돌함");
            other.gameObject.transform.rotation = transform.rotation;
        }
    }
}
