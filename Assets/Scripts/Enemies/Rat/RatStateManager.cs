using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatStateManager : MonoBehaviour
{
    [SerializeField] private IdleState startingState;
    
    [Header("Current State")]
    [SerializeField] private State currentState;

    [Header("Current Target")] 
    public GameObject CurrentTarget;
    public float DistanceFromCurrentTarget;
    [HideInInspector]public NavMeshAgent RatNavMeshAgent;
    [HideInInspector] public Rigidbody RatRB;
    
    [Header("Locomotion")]
    public float RatSpeed = .65f;

    [Header("Attack")] 
    public float MinimumAttackDistance = 1f;
    

    private void Awake()
    {
        currentState = startingState;
        RatNavMeshAgent = GetComponent<NavMeshAgent>();
        RatRB = GetComponent<Rigidbody>();
        ChangeRatSpeed();
    }

    private void FixedUpdate()
    {
        if (CurrentTarget != null)
        {
            DistanceFromCurrentTarget = Vector3.Distance(CurrentTarget.transform.position, transform.position);
        }
        HandleStateMachine();
    }

    private void HandleStateMachine()
    {
        State nextState;
        
        if (currentState != null)
        {
            nextState = currentState.Tick(this);
            
            if (nextState != null)
            {
                currentState = nextState;
            }
        }
    }

    public void ChangeRatSpeed() //To be easily called whenever the speed has changed
    {
        RatNavMeshAgent.speed = RatSpeed;
    }
}
