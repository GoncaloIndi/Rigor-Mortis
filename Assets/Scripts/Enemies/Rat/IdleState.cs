using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    //Idle until the player is in sight
    //If player is in sight go to chase state
    private ChaseState chaseState;

    [Header("Detection Radius")]
    [SerializeField] private float detectionRadius = 2;
    [SerializeField] private LayerMask playerLayer;
    
    [Header("Detection FOV")] //Rat FOV
    [SerializeField] private float minimumDetectionAngle = -35;
    [SerializeField] private float maximumDetectionAngle = 35;
    [SerializeField] private LayerMask ignoreWhenInLineOfSight;
    

    private void Awake()
    {
        chaseState = GetComponent<ChaseState>();
    }

    public override State Tick(RatStateManager ratStateManager)
    {
        if (ratStateManager.CurrentTarget != null)
        {
            return chaseState;
        }
        else
        {
            FindPlayerViaLineOfSight(ratStateManager);
            return this;
        }
    }
    
    private void FindPlayerViaLineOfSight(RatStateManager ratStateManager)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        
        //Searching the player via PlayerStatsScript
        for (int i = 0; i < colliders.Length; i++)
        {
            PlayerStats player = colliders[i].GetComponent<PlayerStats>(); //Tutorial had transform before getcomponent

            if (player != null)
            {

                Vector3 targetDirection = transform.position - player.transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
                
                if (viewableAngle > minimumDetectionAngle && viewableAngle < maximumDetectionAngle)
                {
                    RaycastHit hit;
                    //raycast goes a bit up
                    float height = .2f;
                    var transform1 = player.transform;
                    Vector3 playerStartPoint = new Vector3(transform1.position.x, transform1.position.y + height, transform1.position.z);
                    var position = transform.position;
                    Vector3 ratStartPoint = new Vector3(position.x, position.y, position.z);;

                    
                    
                    if (Physics.Linecast(playerStartPoint, ratStartPoint, out hit, ignoreWhenInLineOfSight))
                    {

                    }
                    else
                    {
                        ratStateManager.CurrentTarget = player;
                    }
                }
            }
        }
    }
}
