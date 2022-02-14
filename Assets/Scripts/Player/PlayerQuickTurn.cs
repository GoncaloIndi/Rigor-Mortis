using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuickTurn : MonoBehaviour
{


    //Stored in the beginning of the lerp
    private Transform playerStartRotation;   
    private Quaternion quickTurnTargetRotation;

    [SerializeField]
    private Transform quickTurnTargetTransform;

    [SerializeField]
    private float quickTurnDuration = 1f;

    private float elapsedTime;

    private bool isPerformingQuickTurn = false;

    [HideInInspector] public PlayerActions PlayerActionsScript;

    private void Awake()
    {
        PlayerActionsScript = GetComponent<PlayerActions>();
    }

    private void Update()
    {
        
        if(isPerformingQuickTurn)
        {
            elapsedTime += Time.deltaTime;

            float percentageComplete = elapsedTime / quickTurnDuration;

            transform.rotation = Quaternion.Slerp(playerStartRotation.rotation, quickTurnTargetRotation, percentageComplete);
        }
    }

    public IEnumerator PerformQuickTurn()
    {
        if(!isPerformingQuickTurn)
        {
            isPerformingQuickTurn = true;
            PlayerActionsScript.CanMove = false;
            playerStartRotation = transform;
            //Missing End position
            
            yield return new WaitForSeconds(quickTurnDuration - .15f);

            PlayerActionsScript.CanMove = true;
            isPerformingQuickTurn = false;
        }
        
    }
}
