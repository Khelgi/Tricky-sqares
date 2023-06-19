using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public Animator animator;

    public void StartShowingRetryButtonAnimation()
    {
        animator.SetTrigger("GameOver");
    }
}
