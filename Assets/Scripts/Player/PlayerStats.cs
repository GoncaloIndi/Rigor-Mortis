using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Stores all the stats so they are easy to use in the scripts
    public bool CanMove = true;

    public bool CanRotate = true;
    
    public bool CanRun = true;

    public bool IsRunning = false;

    public bool IsOnTargetLockOn = false;
    
    public float PlayerFowardMovementSpeed = 9.1f;

    public int PlayerHp = 100;

    public bool IsInInteractionZone = false;

    public bool CanTransitionTroughtScenes = true;

    private PlayerActions playerActionsScript;

    [HideInInspector] public GameObject CurrentInteractionGameObject; //Used for items
    [HideInInspector] public Vector3 LockOnVector; //Used on the alternate controls

    private void Awake()
    {
        playerActionsScript = GetComponent<PlayerActions>();
    }

    public void DamagePlayer(int dmg)
    {
        PlayerHp -= dmg;
        if (PlayerHp <= 0)
        {
            Debug.Log("Death");
        }
    }

    private IEnumerator ResetSceneTransition() //Called by sceneTransition script in order to prevent spamming oddities
    {
        playerActionsScript.PlayerToNoInput();
        CanTransitionTroughtScenes = false;
        yield return new WaitForSeconds(1.5f);
        
        playerActionsScript.PlayerToNoInput();
        yield return new WaitForSeconds(.5f);
        CanTransitionTroughtScenes = true;
    }

    public void ResetTransition()
    {
        StartCoroutine(ResetSceneTransition());
    }
}
