using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public Animator animator;

    public void WallsInitAnimation()
    {
        animator.SetTrigger("StartGame");
    }
}
