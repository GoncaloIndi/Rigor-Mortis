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

    [HideInInspector]public NavMeshAgent RatNavMeshAgent;
    [HideInInspector] public Rigidbody RatRB;
    [Header("Locomotion")]
    public float RatSpeed = .5f;

    public float RotationSpeed = 1;

    private void Awake()
    {
        currentState = startingState;
        RatNavMeshAgent = GetComponent<NavMeshAgent>();
        RatRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
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
}
