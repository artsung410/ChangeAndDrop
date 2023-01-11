using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    private bool isAbleToMove = false;
     
    public bool IsAbleToMove
    {
        get
        {
            return isAbleToMove;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(delayStart());
    }

    private IEnumerator delayStart()
    {
        yield return new WaitForSeconds(1f);
        isAbleToMove = true;
        animator.SetTrigger("run");
    }

    private void Update()
    {
        if (false == isAbleToMove)
        {
            return;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * 5f);
    }

    public void SetRun()
    {
        animator.SetTrigger("run");
    }

    public void SetDie()
    {
        animator.SetTrigger("die");
        isAbleToMove = false;
    }

    public void SetWin()
    {
        animator.SetTrigger("victory");
        isAbleToMove = false;
    }
}
