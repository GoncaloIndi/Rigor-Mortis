using System.Collections;
using UnityEngine;

public class PlayerQuickTurn : MonoBehaviour
{
    //Stored in the beginning of the lerp
    private Transform playerStartRotation;

    private Vector3 relativePosition;

    private Quaternion targetRotation;
    
    [SerializeField]
    private Transform quickTurnTargetTransform;

    private float quickTurnTime;
    
    private bool isPerformingQuickTurn = false;

    [HideInInspector] public PlayerActions PlayerActionsScript;
    
    [HideInInspector] public PlayerStats PlayerStatsScript;

    private void Awake()
    {
        PlayerActionsScript = GetComponent<PlayerActions>();
        PlayerStatsScript = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (!isPerformingQuickTurn) return;

        quickTurnTime += Time.deltaTime;
        
        transform.rotation= Quaternion.Slerp(playerStartRotation.rotation, targetRotation, quickTurnTime);
        
        if (quickTurnTime > 1 || !PlayerStatsScript.CanRotate)
        {
            isPerformingQuickTurn = false;
        }
    }

    public IEnumerator PerformQuickTurn()
    {
        if (isPerformingQuickTurn) yield break;
        
        quickTurnTime = 0;
        isPerformingQuickTurn = true;
        PlayerStatsScript.CanMove = false;
        var transform1 = transform;
        var reenableMovementTimer = .01f ;
        playerStartRotation = transform1;
        relativePosition = quickTurnTargetTransform.position - transform1.position;
        targetRotation = Quaternion.LookRotation(relativePosition);



        yield return new WaitForSeconds(reenableMovementTimer);

        PlayerStatsScript.CanMove = true;

    }
}
