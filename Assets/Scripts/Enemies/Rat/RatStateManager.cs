using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class RatStateManager : MonoBehaviour
{
    [SerializeField] private IdleState startingState;
    public Vector3 Origin;
    public bool HasTarget = false;
    private RatSoundManager ratSFX;
    
    [Header("Current State")]
    [SerializeField] private State currentState;
    
    [Header("Current Target")] 
    public GameObject CurrentTarget;
    public float DistanceFromCurrentTarget;
    [HideInInspector]public NavMeshAgent RatNavMeshAgent;
    [HideInInspector] public Rigidbody RatRB;
    
    [Header("Locomotion")]
    public float RatSpeed = .6f;
    public float MinRatChaseSpeed = 1.2f;
    public float MaxRatChaseSpeed = 2.2f;
    public float DelayChaseSpeed = .6f;

    [Header("Attack & Chase")]
    public float MaximumChaseDistance = 3.7f;
    public float ReturnToChaseDistance = 3;
    public float DistanceToTriggerAttackState = 1.1f;
    public float AttackSpeed = 3f;
    public bool HasPerformedAttack = false;
    public float CurrentAttackCooldown;

    [Header("Debug Values")] 
    public bool IsPerformingAction = false; //Used for stopping state machine whenever the rat gets damaged or dies
    public bool ReturnToOrigin = false;
    public bool IsInIdleState = true; //Initialized as default value
    

    private void Awake()
    {
        currentState = startingState;
        RatNavMeshAgent = GetComponent<NavMeshAgent>();
        RatRB = GetComponent<Rigidbody>();
        ratSFX = GetComponent<RatSoundManager>();
        ChangeRatSpeed();
        Origin = transform.localPosition;
    }

    private void FixedUpdate()
    {

        if (HasTarget)
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
    
    private void OnCollisionEnter(Collision other)
    {
        ReturnToOrigin = true;
    }

    public void ResetRatState() //Called by ratPositionResetter
    {
        CurrentTarget = null;
        HasTarget = false;
        HasPerformedAttack = false;
        currentState = startingState;
        
    }
    
    //Sound
    public IEnumerator RatSqueak()
    {
        while (IsInIdleState)
        {
            var rng = Random.Range(4, 10);
            yield return new WaitForSeconds(rng);
            if (!IsInIdleState)//Failsafe
            {
                yield break;
            }
            ratSFX.RatIdleSqueak();
        }
    }
}
