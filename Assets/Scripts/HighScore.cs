using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public Animator animator;

    public void StartAnimation()
    {
        animator.SetTrigger("GameOver");
    }
}
