using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observation : Interactible
{
    [SerializeField] private GameObject InteractionUI;

    [SerializeField] private Text itemNameUI;

    [SerializeField] private Text descriptionBottomUI;
    [SerializeField] private string bottomDescription;

    private bool AvoidButtonSpamming = true;


    public override void Interact() //Called by PlayerActions
    {
        InteractionUI.SetActive(true);
        itemNameUI.text = "";
        descriptionBottomUI.text = bottomDescription;
        AvoidButtonSpamming = true;
        StartCoroutine(AvoidButtonSpam());
        base.Interact();
    }

    public override void FinishInteract() //Called by PlayerActions
    {
        if(AvoidButtonSpamming) return;
        descriptionBottomUI.text = "";
        InteractionUI.SetActive(false);
        PlayerActionsScript.UIToPlayer(); 
        Time.timeScale = 1;
    }

    //Avoid not seeing the item pick up due to spamming
    private IEnumerator AvoidButtonSpam()
    {
        
        float uiSeenTime = .4f;

        yield return new WaitForSecondsRealtime(uiSeenTime);
        AvoidButtonSpamming = false;

    }
}
