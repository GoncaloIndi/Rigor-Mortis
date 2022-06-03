using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObservationWithCamera : Interactible
{
    [SerializeField] private GameObject InteractionUI;

    [SerializeField] private Text itemNameUI;

    [SerializeField] private Text descriptionBottomUI;
    [SerializeField] private string bottomDescription;
    [SerializeField] private GameObject darkenEffect;

    private bool AvoidButtonSpamming = true;
    [Header("Cameras")] 
    [SerializeField] private GameObject uiCamera;
    [SerializeField] private GameObject cameraToDeactivate;
    private PlayerMovement playerMovementScript;

    protected override void Awake()
    {
        base.Awake();
        playerMovementScript = FindObjectOfType<PlayerMovement>();
    }


    public override void Interact() //Called by PlayerActions
    {
        //Camera related
        cameraToDeactivate = playerMovementScript.CameraToUseMovement;
        SwitchCameras();
        
        InteractionUI.SetActive(true);
        darkenEffect.SetActive(false);
        itemNameUI.text = "";
        descriptionBottomUI.text = bottomDescription;
        AvoidButtonSpamming = true;
        StartCoroutine(AvoidButtonSpam());
        base.Interact();
    }

    public override void FinishInteract() //Called by PlayerActions
    {        
        if(AvoidButtonSpamming) return;
        SwitchCameras();
        descriptionBottomUI.text = "";
        InteractionUI.SetActive(false);
        darkenEffect.SetActive(true);
        PlayerActionsScript.UIToPlayer(); 
        Time.timeScale = 1;
        if (onEndEvent != null)
        {
            onEndEvent.Trigger();
        }
    }

    //Avoid not seeing the item pick up due to spamming
    private IEnumerator AvoidButtonSpam()
    {
        
        float uiSeenTime = .4f;

        yield return new WaitForSecondsRealtime(uiSeenTime);
        AvoidButtonSpamming = false;

    }

    private void SwitchCameras()
    {
        if (uiCamera.activeSelf)
        {
            cameraToDeactivate.SetActive(true);
            uiCamera.SetActive(false);
        }
        else
        {
            uiCamera.SetActive(true);
            cameraToDeactivate.SetActive(false);
        }
    }
}
