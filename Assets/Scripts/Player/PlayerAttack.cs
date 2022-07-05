using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerAttack : MonoBehaviour
{
    //From xinput don't know wtf it does
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    [HideInInspector] public PlayerAnimations PlayerAnimationsScript;

    [HideInInspector] public PlayerStats PlayerStatsScript;
    

    [SerializeField] private Transform swordTip;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private float attackRange = .4f;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer;

    [Header("Attack Lock On")] [SerializeField]
    private float minLockOnAngle, maxLockOnAngle;
    private PlayerLockOnTarget playerLockOnTargetScript; //Reuse the old lock on to connect attacks with rat;
    

    private void Awake()
    {
        PlayerAnimationsScript = GetComponent<PlayerAnimations>();
        PlayerStatsScript = GetComponent<PlayerStats>();
        playerLockOnTargetScript = GetComponent<PlayerLockOnTarget>();
    }

    public void Attack() //Make it so the attack is performed every swing so the sfx works (Waiting for new animations)
    {
        if (!PlayerStatsScript.IsAttackOnCooldown)
        {
            playerLockOnTargetScript.BeginLockOnState(minLockOnAngle, maxLockOnAngle); //Check for angles
            PlayerStatsScript.IsAttackOnCooldown = true;
            PlayerStatsScript.CanMove = false;
            PlayerAnimationsScript.DisplayAttackAnimation();
            //Make it animation based and remove invokes
            Invoke("PerformAttackLogic", .6f);
            Invoke("ResetAttack", attackCooldown);
            
        }
    }

    public void PerformAttackLogic()
    {
        Collider[] enemyCol = Physics.OverlapSphere(swordTip.position, attackRange, enemyLayer);
        for (int i = 0; i < enemyCol.Length; i++)
        {
            //Attack the enemy
            EnemyCombat enemyCombatScript = enemyCol[i].GetComponent<EnemyCombat>();
            if (enemyCombatScript != null)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/sfx_SwordHitFlesh");
                StartCoroutine(VibrateController());
                Vector3 bloodPos = enemyCombatScript.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
                enemyCombatScript.TakeDamage(10, bloodPos);
            }
            //Attack the vents (To break them)
            BreakableVent breakableVentScript = enemyCol[i].GetComponent<BreakableVent>();
            if (breakableVentScript != null)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/sfx_OnVentBreak");
                breakableVentScript.Hit();
            }
            //Other damageable things
            Damageable damageableScript = enemyCol[i].GetComponent<Damageable>();
            if (damageableScript != null)
            {
                damageableScript.OnDamage();
            }
        }
        
        
        playerLockOnTargetScript.EndLockOnState();
    }
    public void ResetAttack()
    {
        PlayerStatsScript.CanMove = true;
        PlayerStatsScript.IsAttackOnCooldown = false;
    }

    private IEnumerator VibrateController()
    {
        GamePad.SetVibration(playerIndex, .8f, 0);
        yield return new WaitForSeconds(.1f);
        GamePad.SetVibration(playerIndex, 0, 0);
        
        yield return new WaitForSeconds(.3f);
        GamePad.SetVibration(playerIndex, 0, .8f);
        yield return new WaitForSeconds(.1f);
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
