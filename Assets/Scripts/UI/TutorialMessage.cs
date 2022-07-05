using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMessage : MonoBehaviour
{
    [SerializeField] private bool displayTutorialMessages = true;
    private Animator tutorialAnim;
    private static readonly int Display1 = Animator.StringToHash("Display");
    private Image tutorialImage;
    [SerializeField] private Sprite attackMessage, inventoryMessage;
    private bool hasDisplayedInventoryMessage;

    private void Awake()
    {
        tutorialAnim = GetComponent<Animator>();
        tutorialImage = GetComponent<Image>();
    }



    public void DisplayInteractMessage() //Starting cutscene script
    {
        if (!displayTutorialMessages) return;

        tutorialAnim.SetTrigger(Display1);
    }

    public void DisplayInventoryMessage() //Interaction event of items
    {
        if (!displayTutorialMessages || hasDisplayedInventoryMessage) return;
        tutorialImage.sprite = inventoryMessage;
        tutorialAnim.SetTrigger(Display1);
        hasDisplayedInventoryMessage = true;
    }

    public void DisplayAttackMessage() //SwordPickup interaction event
    {
        if (!displayTutorialMessages) return;
        tutorialImage.sprite = attackMessage;
        tutorialAnim.SetTrigger(Display1); 
    }
}
