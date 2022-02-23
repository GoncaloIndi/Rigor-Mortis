using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : Interactible
{
    [SerializeField] private string itemName;

    [SerializeField] private Sprite itemSprite;
    
    [SerializeField] private GameObject InteractionUI;

    [SerializeField] private GameObject SpriteUI;

    [SerializeField] private Text itemNameUI;



    private Image imageUI;

    protected override void Awake()
    {
        base.Awake();
        imageUI = SpriteUI.GetComponent<Image>();
        
    }

    public override void Interact() //Called by PlayerActions
    {
        InteractionUI.SetActive(true);
        SpriteUI.SetActive(true);
        imageUI.sprite = itemSprite;
        itemNameUI.text = itemName;
        base.Interact();
    }

    public override void FinishInteract() //Called by PlayerActions
    {
        SpriteUI.SetActive(false);
        InteractionUI.SetActive(false);
        base.FinishInteract();
        
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
