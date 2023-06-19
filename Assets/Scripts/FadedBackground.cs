using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadedBackground : MonoBehaviour
{
    public Animator animator;
    public void StartUnfadeAnimation()
    {
        animator.SetTrigger("GameOver");
    }
}
