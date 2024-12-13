using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        animator.SetBool("State", true);
    }

    public void Hide()
    {
        animator.SetBool("State", false);
    }

    public void OnShowed()
    {

    }

    public void OnHided()
    {

    }
}
