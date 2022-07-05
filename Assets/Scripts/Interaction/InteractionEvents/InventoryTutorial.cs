using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTutorial : InteractionEvent
{
    [SerializeField] private TutorialMessage tutorial;
    public override void Trigger()
    {
        tutorial.DisplayInventoryMessage();
    }
}
