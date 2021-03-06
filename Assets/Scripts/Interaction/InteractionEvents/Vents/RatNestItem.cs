using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatNestItem : InteractionEvent
{
    [SerializeField] private string itemName;

    [SerializeField] private Sprite itemSprite;
    
    [SerializeField] private GameObject InteractionUI;

    [SerializeField] private GameObject SpriteUI;

    [SerializeField] private Text itemNameUI;
    
    [SerializeField] private Text descriptionUI;
    [SerializeField] private string description;

    private bool AvoidButtonSpamming = true;

    private Image imageUI;

    [SerializeField] private GameObject newInteraction;
    [SerializeField] private GameObject oldInteraction;

    private PlayerActions playerActionsScript;
    private PlayerStats playerStatsScript;
    public ItemData ItemData;
    [SerializeField] private DisplayInventoryItems displayInventoryItems;

    [Header("Room Related")]
    [SerializeField] private GameObject bear;
    [SerializeField] private ClosetDoor closetDoorScript;
    [SerializeField] private GameObject bearInteraction;
    public GameObject Bootprint; //BootprintUpdater script

    [Header("Vent Related")] 
    [SerializeField] private GameObject ratBang, killerFootsteps;

    [SerializeField] private InteractionEvent tutorialEvent;

    
    
    private void Awake()
    {
        imageUI = SpriteUI.GetComponent<Image>();
        playerActionsScript = FindObjectOfType<PlayerActions>();
        playerStatsScript = FindObjectOfType<PlayerStats>();
    }
    
    public override void Trigger()
    {
        playerStatsScript.CurrentInteractionGameObject = this.gameObject;
        RoomGasLighting();
        VentChanges();
        Interact();
    }

    private void Interact() //Called by PlayerActions
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ItemPickUp");
        playerStatsScript.ObtainNewItem(ItemData); //Get item in inventory
        displayInventoryItems.UpdateItems();
        playerActionsScript.PlayerToUI();
        InteractionUI.SetActive(true);
        SpriteUI.SetActive(true);
        imageUI.sprite = itemSprite;
        descriptionUI.text = description;
        itemNameUI.text = itemName;
        AvoidButtonSpamming = true;
        StartCoroutine(AvoidButtonSpam());
        Time.timeScale = 0;
    }

    public override void FinishInteract() //Called by PlayerActions
    {
        if(AvoidButtonSpamming) return;
        SpriteUI.SetActive(false);
        InteractionUI.SetActive(false);
        playerActionsScript.UIToPlayer(); 
        Time.timeScale = 1;
        newInteraction.SetActive(true);
        tutorialEvent.Trigger();
        playerStatsScript.CurrentInteractionGameObject = newInteraction;
        Destroy(oldInteraction);
    }

    //Avoid not seeing the item pick up due to spamming
    private IEnumerator AvoidButtonSpam()
    {
        
        float uiSeenTime = .3f;

        yield return new WaitForSecondsRealtime(uiSeenTime);
        AvoidButtonSpamming = false;

    }
    
    //Responsible for changes in room the next time the player goes there
    private void RoomGasLighting()
    {
        bear.SetActive(false);
        bearInteraction.SetActive(false);
        
        Bootprint.SetActive(true);
        closetDoorScript.IsAffectedByWind = true;
    }
    
    //Changes in vent level
    private void VentChanges()
    {
        ratBang.SetActive(false);
        killerFootsteps.SetActive(true);
    }
}
