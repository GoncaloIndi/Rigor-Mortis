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
    public bool IsAttackOnCooldown = false;
    private PlayerVFXManager playerVFXManagerScript;
    [SerializeField] private Animator damageFX;
    private DeathCutscene deathCutscene;

    [Header("Interaction")]
    public bool IsInInteractionZone = false;
    public bool CanTransitionTroughtScenes = true;

    private PlayerActions playerActionsScript;
    private PlayerAnimations playerAnimationsScript;
    [SerializeField] private PlayerSounds playerSoundsScript;

    [HideInInspector] public GameObject CurrentInteractionGameObject; //Used for items
    [HideInInspector] public Vector3 LockOnVector; //Used on the alternate controls
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    [Header("Inventory")] 
    [SerializeField] private ItemManager inventory;

    public OnItemUse CurrentItemUse;

    private static readonly int DamageFX = Animator.StringToHash("DamageFX");

    private void Awake()
    {
        playerActionsScript = GetComponent<PlayerActions>();
        playerAnimationsScript = GetComponent<PlayerAnimations>();
        playerVFXManagerScript = GetComponent<PlayerVFXManager>();
        deathCutscene = FindObjectOfType<DeathCutscene>();

        //Debug purposes
        if (HasWeaponEquipped)
        {
            sword.SetActive(true);
        }
    }

    //Combat
    public void DamagePlayer(int dmg, bool vibrateController)
    {
        if (PlayerHp <= 0) return;  

        
        PlayerHp -= dmg; 
        playerVFXManagerScript.WoodchipsVFX();  //Particles
        playerSoundsScript.DamageSound(); //Sound

        playerAnimationsScript.DisplayDamageAnimation();
        damageFX.SetTrigger(DamageFX);
        
        StartCoroutine(StopInputOnDamage());
        
        //Vibration If the player gets damaged while attacking the controller vibrates longer
        if (vibrateController && !IsAttackOnCooldown)
        {
            StartCoroutine(TriggerAttackCooldown(.5f));
            StartCoroutine(VibrateController(.5f));
        }
        else if(vibrateController && IsAttackOnCooldown)
        {
            StartCoroutine(VibrateController(1.4f));
        }
        
        if (PlayerHp <= 0)
        {
            StartCoroutine(deathCutscene.StartDeathCutscene());
        }
    }

    public void FakeDamagePlayer()
    {
        damageFX.SetTrigger(DamageFX);
        playerSoundsScript.DamageSound(); //Sound
        playerVFXManagerScript.WoodchipsVFX();  //Particles
        playerAnimationsScript.DisplayDamageAnimation();
        StartCoroutine(StopInputOnDamage());
        StartCoroutine(VibrateController(.5f));
        
    }
    
    public IEnumerator TriggerAttackCooldown(float cooldownTime) //Prevent playerFromAttacking whilst getting damaged
    {
        IsAttackOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        IsAttackOnCooldown = false;
    }

    public void EquipSword()
    {
        HasWeaponEquipped = true;
        sword.SetActive(true);
    }

    //Interaction
    private IEnumerator ResetSceneTransition() //Called by sceneTransition script in order to prevent spamming oddities
    {
        playerActionsScript.PlayerToNoInput(true);
        CanTransitionTroughtScenes = false;
        yield return new WaitForSeconds(1.5f);
        
        playerActionsScript.PlayerToNoInput(false);
        yield return new WaitForSeconds(.5f);
        CanTransitionTroughtScenes = true;
    }

    public void ResetTransition()
    {
        StartCoroutine(ResetSceneTransition());
    }

    private IEnumerator VibrateController(float rumbleTime)
    {
        GamePad.SetVibration(playerIndex, 1f, 1f);
            
            
        yield return new WaitForSeconds(rumbleTime);
        GamePad.SetVibration(playerIndex, 0, 0);
    }

    private IEnumerator StopInputOnDamage()
    {
        playerActionsScript.PlayerToNoInput(true);
        yield return new WaitForSeconds(.5f);
        playerActionsScript.PlayerToNoInput(false);
    }

    
    //Inventory
    public void ObtainNewItem(ItemData item)
    {
        inventory.AddItem(item, 1);
    }

    private void OnApplicationQuit()
    {
        inventory.inventoryItems.Clear();   
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
