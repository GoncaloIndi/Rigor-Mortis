using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector] public PlayerAnimations PlayerAnimationsScript;

    [HideInInspector] public PlayerStats PlayerStatsScript;

    [SerializeField] private bool isAttackOnCooldown = false;

    [SerializeField] private float attackCooldown;
    private float cooldownTimer;

    private void Awake()
    {
        PlayerAnimationsScript = GetComponent<PlayerAnimations>();
        PlayerStatsScript = GetComponent<PlayerStats>();
    }

    public void Attack()
    {
        if (PlayerStatsScript.CanAttack && !isAttackOnCooldown)
        {
            isAttackOnCooldown = true;
            PlayerStatsScript.CanMove = false;
            PlayerAnimationsScript.DisplayAttackAnimation();
            Invoke("ResetAttack", 1.5f);
            
        }
    }

    public void ResetAttack()
    {
        PlayerStatsScript.CanMove = true;
        isAttackOnCooldown = false;
    }
}
