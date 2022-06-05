using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public bool DisplayRunningAnimation = false;
    
    [SerializeField]
    private Animator playerAnim;
    private static readonly int Movement = Animator.StringToHash("Movement");
    [HideInInspector] public PlayerActions PlayerActionsScript;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Damage = Animator.StringToHash("Damage");

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
                playerAnim.SetFloat(Movement, 1, .1f, Time.deltaTime);
            }
            else
            {
                playerAnim.SetFloat(Movement, .5f,.15f, Time.deltaTime);
            }
        }
        else
        {
            playerAnim.SetFloat(Movement, 0,.15f, Time.deltaTime);
        }
        
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
