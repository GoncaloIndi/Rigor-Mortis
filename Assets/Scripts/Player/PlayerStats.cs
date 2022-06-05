using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerStats : MonoBehaviour
{
    //Stores all the stats so they are easy to use in the scripts
    [Header("Movement")]
    public bool CanMove = true;
    public bool CanRotate = true;
    public bool CanRun = true;
    public bool IsRunning = false;
    [HideInInspector]public bool IsOnTargetLockOn = false;
    
    [Header("Combat")]
    public float PlayerFowardMovementSpeed = 9.1f;
    public int PlayerHp = 100;
    public bool HasWeaponEquipped = false;
    [SerializeField] private GameObject sword; //Temp if game gets more weapons

    [Header("Interaction")]
    public bool IsInInteractionZone = false;
    public bool CanTransitionTroughtScenes = true;

    private PlayerActions playerActionsScript;
    private PlayerAnimations playerAnimationsScript;

    [HideInInspector] public GameObject CurrentInteractionGameObject; //Used for items
    [HideInInspector] public Vector3 LockOnVector; //Used on the alternate controls
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    private void Awake()
    {
        playerActionsScript = GetComponent<PlayerActions>();
        playerAnimationsScript = GetComponent<PlayerAnimations>();
    }

    //Combat
    public void DamagePlayer(int dmg, bool vibrateController)
    {
        PlayerHp -= dmg;
        playerAnimationsScript.DisplayDamageAnimation();
        if (vibrateController)
        {
            StartCoroutine(VibrateController());
        }
        
        if (PlayerHp <= 0)
        {
            Debug.Log("Death");
        }
    }

    public void EquipSword()
    {
        HasWeaponEquipped = true;
        sword.SetActive(true);
    }

    //Interaction
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

    private IEnumerator VibrateController()
    {
        var shockTime = .5f;

        playerActionsScript.PlayerToNoInput();
        GamePad.SetVibration(playerIndex, 1f, 1f);
            
            
        yield return new WaitForSeconds(shockTime);
        playerActionsScript.PlayerToNoInput();
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
