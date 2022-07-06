using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public bool DisplayRunningAnimation = false;
    [Range(0, 2)] public int AnimationState = 0;
    
    [SerializeField]
    private Animator playerAnim;
    private static readonly int Movement = Animator.StringToHash("Movement");
    [HideInInspector] public PlayerActions PlayerActionsScript;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Damage = Animator.StringToHash("Damage");
    private static readonly int StartCutscene = Animator.StringToHash("StartCutscene");

    private void Awake()
    {
        PlayerActionsScript = GetComponent<PlayerActions>();

    }

    private void FixedUpdate()
    {
        
        if (PlayerActionsScript.PlayerMovementVector != Vector2.zero)
        {
            if (DisplayRunningAnimation)
            {
                playerAnim.SetFloat(Movement, 1f, .1f, Time.deltaTime);
                AnimationState = 2;
            }
            else
            {
                playerAnim.SetFloat(Movement, .5f,.1f, Time.deltaTime);
                AnimationState = 1;
            }
        }
        else
        {
            playerAnim.SetFloat(Movement, 0,.1f, Time.deltaTime);
            AnimationState = 0;
        }
        
    }

    public void DisplayCutsceneAnimation()
    {
        playerAnim.SetTrigger(StartCutscene);
    }

    public void DisplayAttackAnimation()
    {
        playerAnim.SetTrigger(Attack);
    }

    public void DisplayDamageAnimation()
    {
        playerAnim.SetTrigger(Damage);
    }
}
