using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IdleState : State
{
    //Idle until the player is in sight
    //If player is in sight go to chase state
    private ChaseState chaseState;
    public bool HasDetectedPlayer;
    [SerializeField] private RatStateManager ratStateManagerScript;

    [Header("Detection Radius")]
    [SerializeField] private float detectionRadius = 2;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float detectPlayerByNoise = 2.2f;
    
    [Header("Detection FOV")] //Rat FOV
    [SerializeField] private float minimumDetectionAngle = 145;
    [SerializeField] private float maximumDetectionAngle = 200;
    [SerializeField] private LayerMask ignoreWhenInLineOfSight;
    
    //Related to wander
    private float lookoutTime, waitingTime;


    private void Awake()
    {
        chaseState = GetComponent<ChaseState>();
    }

    private void OnEnable()
    {
        StartCoroutine(ratStateManagerScript.RatSqueak());
    }

    public override State Tick(RatStateManager ratStateManager)
    {
        if (ratStateManager.HasTarget)
        {
            ratStateManager.IsInIdleState = false;
            return chaseState;
        }
        else
        {
            FindPlayerViaLineOfSight(ratStateManager);
            Wander(ratStateManager);
            return this;
        }
    }

    
    //Related to wandering
    private void Wander(RatStateManager ratStateManager)
    {
        var position = transform.position;

        if (ratStateManager.ReturnToOrigin)
        {
            ratStateManager.ReturnToOrigin = false;
            ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.Origin);
        }

        float distanceFromDestination = Vector3.Distance(ratStateManager.RatNavMeshAgent.destination, position);

        waitingTime += Time.deltaTime;
        

        if (distanceFromDestination <= .3f)
        {
            if (waitingTime >= lookoutTime)
            {
                ratStateManager.RatNavMeshAgent.SetDestination((Random.insideUnitSphere * 4) + position);
                lookoutTime = Random.Range(1, 5);
                waitingTime = 0;
            }
        }
    }

    private void FindPlayerViaLineOfSight(RatStateManager ratStateManager)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        
        //Searching the player via Tag
        for (int i = 0; i < colliders.Length; i++)
        {
            GameObject player = colliders[i].gameObject; 
            

            if (player.CompareTag("Player"))
            {
                ratStateManager.DistanceFromCurrentTarget = Vector3.Distance(player.transform.position, transform.position);
                
                if (ratStateManager.DistanceFromCurrentTarget <= detectPlayerByNoise) //Improve to allow stealth
                {
                    TargetPlayer();   
                }
                
                if (HasDetectedPlayer)
                {
                    HasDetectedPlayer = false;
                    ratStateManager.HasTarget = true;
                    ratStateManager.CurrentTarget = player;
                }
                
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
                    Vector3 ratStartPoint = new Vector3(position.x, position.y + height, position.z);

                    if (Physics.Linecast(playerStartPoint, ratStartPoint, out hit, ignoreWhenInLineOfSight))
                    {

                    }
                    else
                    {
                        ratStateManager.HasTarget = true;
                        ratStateManager.CurrentTarget = player;
                    }
                }
            }
        }
    }

    public void TargetPlayer() //Called by enemyCombat to make the rat chase the player when he is attacked
    {
        HasDetectedPlayer = true;
    }

}
