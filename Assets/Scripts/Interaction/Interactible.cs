using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider))]

public class Interactible : MonoBehaviour
{
    
    [SerializeField] private string description;

    [HideInInspector] public PlayerActions PlayerActionsScript;
    
    public PlayerStats PlayerStatsScript;

    [SerializeField] private Text descriptionUI;
    [Header("Interaction Events")]
    [SerializeField] protected InteractionEvent interactionEvent; //OnBegin change name
    [SerializeField] protected InteractionEvent onEndEvent;
    protected virtual void Awake()
    {
        PlayerActionsScript = FindObjectOfType<PlayerActions>();
        PlayerStatsScript = FindObjectOfType<PlayerStats>();
    }

    public virtual void Interact() //UI must be turned on by child script
    {
        PlayerActionsScript.PlayerToUI();
        descriptionUI.text = description;
        if (interactionEvent != null)
        {
            interactionEvent.Trigger();
        }
        Time.timeScale = 0;
    }

    public virtual void FinishInteract() //UI must be turned on by child script
    {
        PlayerActionsScript.UIToPlayer(); 
        Time.timeScale = 1;
        if (onEndEvent != null)
        {
            onEndEvent.Trigger();
        }
        Destroy(this.gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
            PlayerStatsScript.CurrentInteractionGameObject = this.gameObject;
        PlayerStatsScript.IsInInteractionZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        PlayerStatsScript.CurrentInteractionGameObject = null;
        PlayerStatsScript.IsInInteractionZone = false;
    }
}
