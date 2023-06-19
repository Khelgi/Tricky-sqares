using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public Animator animator;

    public void MenuButtonAnimation()
    {
        animator.SetTrigger("GameOver");
    }
}
