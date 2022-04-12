using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLockOnTarget : MonoBehaviour
{
    [HideInInspector] public PlayerStats PlayerStatsScript;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float maximumLockOnDistance = 10;
    [SerializeField] private Transform nearestLockOnTarget;
    [SerializeField] private Transform currentLockOnTarget;

    //Lerp Stuff
    private bool doLockLerp = false;
    private float lockOnTime;
    private Transform playerStartRotation;

    private Quaternion lockOnRotation;

    private List<EnemyStats> availableTargets = new List<EnemyStats>();

    
    // IMPORTANT: Enemy must have a collider and the EnemyStats script in order to make this work
    private void Awake()
    {
        PlayerStatsScript = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if(!doLockLerp) return;
        
        lockOnTime += Time.deltaTime;
        UpdateTargetPosition();
        
        transform.rotation= Quaternion.Slerp(playerStartRotation.rotation, lockOnRotation, lockOnTime);
        
    }

    public void BeginLockOnState()
    {
        PlayerStatsScript.IsOnTargetLockOn = true;
        PlayerStatsScript.CanRotate = false;
        PlayerStatsScript.CanRun = false;
        CheckForEnemies();

        if (nearestLockOnTarget != null)
        {
            currentLockOnTarget = nearestLockOnTarget;
            LockOnTarget();
        }
        
    }

   

    private void CheckForEnemies()
    {
        var shortestDistance = Mathf.Infinity;

        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, maximumLockOnDistance, enemyLayer);
        
        

        for (int i = 0; i < enemyColliders.Length; i++)
        {
            EnemyStats enemy = enemyColliders[i].GetComponent<EnemyStats>();

            if (enemy != null)
            {
                Vector3 lockTargetDirection = enemy.transform.position - transform.position;
                float distanceFromTarget = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceFromTarget <= maximumLockOnDistance && !enemy.IsBeingTargetedByPlayer)
                {
                    enemy.IsBeingTargetedByPlayer = true;
                    availableTargets.Add(enemy);
                }
            }
        }

        for (int k = 0; k < availableTargets.Count; k++)
        {
            float distanceFromTarget = Vector3.Distance(transform.position, availableTargets[k].transform.position);

            if (distanceFromTarget < shortestDistance)
            {
                shortestDistance = distanceFromTarget;
                nearestLockOnTarget = availableTargets[k].transform;
            }
        }

    }

    private void LockOnTarget()
    {
        
        Vector3 lockOnVector = currentLockOnTarget.position - transform.position;
        lockOnRotation = Quaternion.LookRotation(lockOnVector);
        lockOnRotation = ClampQuaternionValues(lockOnRotation);
        lockOnTime = 0;
        playerStartRotation = transform;
        doLockLerp = true;
    }

    private void UpdateTargetPosition()
    {
        Vector3 lockOnVector = currentLockOnTarget.position - transform.position;
        lockOnRotation = Quaternion.LookRotation(lockOnVector);
        lockOnRotation = ClampQuaternionValues(lockOnRotation);

        if (!GameSettings.IsUsingTankControls)
        {
            PlayerStatsScript.LockOnVector = lockOnVector;
        }
    }

    private void ClearLockOnTarget()
    {
        for (int i = 0; i < availableTargets.Count; i++)
        {
            availableTargets[i].IsBeingTargetedByPlayer = false;
        }
        availableTargets.Clear();
        currentLockOnTarget = null;
        nearestLockOnTarget = null;
    }
    
     

    public void EndLockOnState()
    {
        doLockLerp = false;
        PlayerStatsScript.IsOnTargetLockOn = false;
        PlayerStatsScript.CanRotate = true;
        PlayerStatsScript.CanRun = true;
        ClearLockOnTarget();
    }



    Quaternion ClampQuaternionValues(Quaternion q) //Look mom I'm a wizard I made quaternion math
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
  
        //Clamp X
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);
        angleX = Mathf.Clamp (angleX, 0, 0);
        q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);
        
        //Clamp Z
        float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.z);
        angleZ = Mathf.Clamp (angleZ, 0, 0);
        q.z = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleZ);

        return q;
    }
    
}
