using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : Interactible
{
    [SerializeField] private string itemName;

    [SerializeField] private Sprite itemSprite;
    
    [SerializeField] private GameObject InteractionUI;

    [SerializeField] private GameObject SpriteUI;

    [SerializeField] private Text itemNameUI;

    private bool AvoidButtonSpamming = true;

    private Image imageUI;

    protected override void Awake()
    {
        base.Awake();
        imageUI = SpriteUI.GetComponent<Image>();
    }

    public override void Interact() //Called by PlayerActions
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ItemPickUp");
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
        PlayerStatsScript.EquipSword();
        SpriteUI.SetActive(false);
        InteractionUI.SetActive(false);
        base.FinishInteract();


    }

    //Avoid not seeing the item pick up due to spamming
    private IEnumerator AvoidButtonSpam()
    {
        
        float uiSeenTime = .4f;

        yield return new WaitForSecondsRealtime(uiSeenTime);
        AvoidButtonSpamming = false;

    }
}
