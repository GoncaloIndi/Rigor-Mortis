using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector] public PlayerAnimations PlayerAnimationsScript;

    [HideInInspector] public PlayerStats PlayerStatsScript;

    [SerializeField] private Transform swordTip;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private float attackRange = .4f;

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
            //Make it animation based and remove invokes
            Invoke("PerformAttackLogic", .7f);
            Invoke("ResetAttack", 1.5f);
            
        }
    }

    public void PerformAttackLogic()
    {
        Collider[] enemyCol = Physics.OverlapSphere(swordTip.position, attackRange, enemyLayer);
        for (int i = 0; i < enemyCol.Length; i++)
        {
            EnemyCombat enemyCombatScript = enemyCol[i].GetComponent<EnemyCombat>();
            if (enemyCombatScript != null)
            {
                enemyCombatScript.TakeDamage(10);
            }
        }
    }
    public void ResetAttack()
    {
        PlayerStatsScript.CanMove = true;
        isAttackOnCooldown = false;
    }
}
