using UnityEngine;

public class ChaseState : State
{
    //Chase the player until he is no longer in sight (Retreat)
    //or start attacking when he is in range (Attack)

    private AttackState attackState;
    private IdleState idleState;
    private bool hasPlayerInSight = true;
    private Vector3 currentDestination;
    [SerializeField] private float chaseLossDelay = .4f; //Continues to follow player after a few seconds after loss of sight
    private float chaseLossTimer = 0;
    private bool hasPerformedDelayChase = false;
    [SerializeField] private RatAnimations ratAnimations;

    //Raycast to see if the player is still in line of sight
    [SerializeField] private LayerMask ignoreWhenInLineOfSight;
    

    private void Awake()
    {
        attackState = GetComponent<AttackState>();
        idleState = GetComponent<IdleState>();
    }

    public override State Tick(RatStateManager ratStateManager)
    {

        if (ratStateManager.IsPerformingAction) 
        {
            return this;
        }
        
        MoveTowardsCurrentTarget(ratStateManager);
        
        if (ratStateManager.DistanceFromCurrentTarget <= ratStateManager.DistanceToTriggerAttackState && hasPlayerInSight && !ratStateManager.HasPerformedAttack) //Transition to AttackState
        {
            ratStateManager.RatSpeed = 0;
            ratStateManager.ChangeRatSpeed();
            return attackState;
        }
        
        else if (ratStateManager.DistanceFromCurrentTarget >= ratStateManager.MaximumChaseDistance || (!hasPlayerInSight && Vector3.Distance(ratStateManager.RatNavMeshAgent.destination, transform.position) < .5)) //Transition to RetreatState
        {
            //Chase the player for a few seconds before retreating to make the AI more cohesive (DIRECTOR AI)
            ChasePlayerByDelay(ratStateManager);

            if (!hasPerformedDelayChase) return this;

            ratStateManager.CurrentTarget = null;
            ratStateManager.RatSpeed = ratStateManager.DelayChaseSpeed;
            ratStateManager.ChangeRatSpeed();
            hasPerformedDelayChase = false;
            ratStateManager.HasTarget = false;
            
            //Sound
            ratStateManager.IsInIdleState = true;            //IdleState
            if (!idleState.IsBlinded)
            {
                StartCoroutine(idleState.RatTemporaryBlindness());
            }
            StartCoroutine(ratStateManager.RatSqueak());
            ratAnimations.DisplayChaseAnimation(false);
            return idleState;
        }
        else if (ratStateManager.DistanceFromCurrentTarget <= 2) //DIRECTOR AI
        {
            ratStateManager.RatSpeed = ratStateManager.MinRatChaseSpeed; //DIRECTOR AI
            ratStateManager.ChangeRatSpeed();
        }
        else if (ratStateManager.DistanceFromCurrentTarget > 2)
        {
            ratStateManager.RatSpeed = ratStateManager.MaxRatChaseSpeed;
            ratStateManager.ChangeRatSpeed();
        }
        
        return this;
    }

    private void MoveTowardsCurrentTarget(RatStateManager ratStateManager)
    {
        RaycastHit hit;
        //raycast goes a bit up
        float height = .2f;
        var transform1 = ratStateManager.CurrentTarget.transform;
        Vector3 playerStartPoint = new Vector3(transform1.position.x, transform1.position.y + height, transform1.position.z);
        var position = transform.position;
        Vector3 ratStartPoint = new Vector3(position.x, position.y + height, position.z);

        if (Physics.Linecast(playerStartPoint, ratStartPoint, out hit, ignoreWhenInLineOfSight))
        {
            hasPlayerInSight = false;
        }
        else
        {
            hasPlayerInSight = true;
            ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
        }
    }

    private void ChasePlayerByDelay(RatStateManager ratStateManager)
    {

        while (chaseLossTimer <= chaseLossDelay && !hasPlayerInSight)
        {
            
            chaseLossTimer += Time.deltaTime;
            ratStateManager.RatNavMeshAgent.SetDestination(ratStateManager.CurrentTarget.transform.position);
        }
        hasPerformedDelayChase = true;
        chaseLossTimer = 0;
    }
    
}
