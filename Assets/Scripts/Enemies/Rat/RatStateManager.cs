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
    public PlayerStats CurrentTarget;

    [HideInInspector]public NavMeshAgent RatNavMeshAgent;
    [HideInInspector] public Rigidbody RatRB;
    [Header("Locomotion")]
    public float RatSpeed = .5f;

    public float RotationSpeed = 1;

    private void Awake()
    {
        currentState = startingState;
        RatNavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        RatRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleStateMachine();
    }

    private void Update()
    {
       //RatNavMeshAgent.transform.localPosition = Vector3.zero;
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
