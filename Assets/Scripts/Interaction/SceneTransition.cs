using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : Interactible
{
    [SerializeField] private Animator fadeEffect;
    private CharacterController playerController; //Controller prevents TP
    private PlayerStats playerStatsScript;
    private PlayerMovement playerMovementScript;
    [SerializeField] private bool isCameraFixed = false;
    [SerializeField] private FollowPlayer cameraScript; //Manually assigned
    [SerializeField] private float fadeTime = 1f;

    [Header("Scene Related")] 
    [SerializeField] private Vector3 playerTeleportPosition;
    [SerializeField] private Quaternion playerTeleportRotation;
    [SerializeField] private GameObject currentScene;
    [SerializeField] private GameObject sceneToTransition;
    [SerializeField] private GameObject oddObjectOff; //Both this serve to turn objects on and off that are not in the scene if need be
    [SerializeField] private GameObject oddObjectOn;
    [Header("Movement Related")]
    [SerializeField] private GameObject cameraToTransition;
    [SerializeField] private bool shouldSwitchCameraInput = false;
    private Transform playerPosition;
    
    private static readonly int DarkenAndLighten = Animator.StringToHash("DarkenAndLighten");

    protected override void Awake()
    {
        playerPosition = FindObjectOfType<PlayerStats>().GetComponent<Transform>();
        playerController = FindObjectOfType<CharacterController>();
        playerStatsScript = FindObjectOfType<PlayerStats>();
        playerMovementScript = FindObjectOfType<PlayerMovement>();
    }

    public override void Interact() //Spam prevention done in playerStats
    {
        if (!playerStatsScript.CanTransitionTroughtScenes) return;
        playerStatsScript.ResetTransition();
        PlayerStatsScript.CurrentInteractionGameObject = null;
        PlayerStatsScript.IsInInteractionZone = false;
        fadeEffect.SetTrigger(DarkenAndLighten);
        Invoke(nameof(TeleportPlayer), fadeTime);
    }

    private void TeleportPlayer()
    {
        sceneToTransition.SetActive(true);
        if (oddObjectOn != null)
        {
            oddObjectOn.SetActive(true);
        }
        if (oddObjectOff != null)
        {
            oddObjectOff.SetActive(false);
        }
        currentScene.SetActive(false);
        playerController.enabled = false;
        playerPosition.position = playerTeleportPosition;
        playerPosition.rotation = playerTeleportRotation;
        playerController.enabled = true;
        FixCameraPosition();
    }

    private void FixCameraPosition()
    {
        if (shouldSwitchCameraInput)
        {
            playerMovementScript.CurrentCamera = cameraToTransition;
        }
        if (isCameraFixed) return;
        cameraScript.transform.position = playerPosition.position + cameraScript.CameraOffset;
    }
    
    
}
