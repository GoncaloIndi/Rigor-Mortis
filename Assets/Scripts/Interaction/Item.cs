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

    public ItemData ItemData;
    [SerializeField] private DisplayInventoryItems displayInventoryItems;
    [SerializeField] private bool addToInventory;

    private bool AvoidButtonSpamming = true;
    private PlayerStats playerStatsScript;

    private Image imageUI;

    protected override void Awake()
    {
        base.Awake();
        imageUI = SpriteUI.GetComponent<Image>();
        playerStatsScript = FindObjectOfType<PlayerStats>();
    }

    public override void Interact() //Called by PlayerActions
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ItemPickUp");
        if (addToInventory)
        {
            playerStatsScript.ObtainNewItem(ItemData); //Get item in inventory
            displayInventoryItems.UpdateItems();
        }
        PlayerStatsScript.IsInInteractionZone = false;
        InteractionUI.SetActive(true);
        SpriteUI.SetActive(true);
        imageUI.sprite = itemSprite;
        itemNameUI.text = itemName;
        AvoidButtonSpamming = true;
        StartCoroutine(AvoidButtonSpam());
        base.Interact();
    }

    public override void FinishInteract() //Called by PlayerActions
    {
        if(AvoidButtonSpamming) return;
        SpriteUI.SetActive(false);
        InteractionUI.SetActive(false);
        base.FinishInteract();
    }

    //Avoid not seeing the item pick up due to spamming
    private IEnumerator AvoidButtonSpam()
    {
        
        float uiSeenTime = .3f;

        yield return new WaitForSecondsRealtime(uiSeenTime);
        AvoidButtonSpamming = false;

    }
}
