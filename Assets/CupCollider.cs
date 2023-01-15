using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCollider : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private Cup cup;
    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        cup = GetComponentInParent<Cup>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 13)
        {
            Debug.Log("∞ËªÍ¡ﬂ...");
            float targetX = other.transform.position.x;
            float radius = sphereCollider.radius;
            cup.CalculateDistance(targetX, radius);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        cup.IsOLockOn = false;
    }
}
