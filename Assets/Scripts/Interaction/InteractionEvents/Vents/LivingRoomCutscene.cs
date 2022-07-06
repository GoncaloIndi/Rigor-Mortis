using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomCutscene : InteractionEvent
{
    
    private PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = FindObjectOfType<PlayerAnimations>();
    }

    public override void Trigger()
    {
        playerAnimations.DisplayFallAnimation();
    }

}
