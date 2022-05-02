using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    [SerializeField] private string description;

    [HideInInspector] public PlayerActions PlayerActionsScript;
    
    public PlayerStats PlayerStatsScript;

    [SerializeField] private Text descriptionUI;
    
    
    protected InteractionType Interaction;
    protected enum InteractionType
    {
        Item,
        Puzzle
    }

    protected virtual void Awake()
    {
        PlayerActionsScript = FindObjectOfType<PlayerActions>();
    }

    public virtual void Interact() //UI must be turned on by child script
    {
        PlayerActionsScript.PlayerToUI();
        descriptionUI.text = description;
        Time.timeScale = 0;
    }

    public virtual void FinishInteract() //UI must be turned on by child script
    {
        PlayerActionsScript.UIToPlayer(); 
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerStatsScript.CurrentInteractionGameObject = this.gameObject;
        PlayerStatsScript.IsInInteractionZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerStatsScript.CurrentInteractionGameObject = null;
        PlayerStatsScript.IsInInteractionZone = false;
    }
}
