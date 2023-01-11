using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_End : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimatorController PlayerAnimatorController = other.GetComponent<AnimatorController>();
            PlayerAnimatorController.SetWin();
        }
    }
}
