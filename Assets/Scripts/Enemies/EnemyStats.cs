using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int EnemyHp = 50;

    public bool IsBeingTargetedByPlayer = false;
    
    //TEMP until a better solution is found
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    private void OnDisable() // TEMP!!!!! Prevent animation resetting when the player transitions scenes
    {
        if (EnemyHp <= 0)
        {
            animator.enabled = false; 
        }
    }
}
