using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public bool DisplayRunningAnimation = false;
    
    [SerializeField]
    private Animator PlayerAnim;
    private static readonly int Movement = Animator.StringToHash("Movement");
    [HideInInspector] public PlayerActions PlayerActionsScript;
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Awake()
    {
        PlayerActionsScript = GetComponent<PlayerActions>();
    }

    private void FixedUpdate()
    {

        if (PlayerActionsScript.PlayerMovementVector.y > 0 || PlayerActionsScript.PlayerMovementVector.x > 0 && DisplayRunningAnimation)
        {
            PlayerAnim.SetFloat(Movement, 1, .1f, Time.deltaTime);
        }
        else if (PlayerActionsScript.PlayerMovementVector != Vector2.zero)
        {
            PlayerAnim.SetFloat(Movement, .5f,.15f, Time.deltaTime);
        }
        else
        {
            PlayerAnim.SetFloat(Movement, 0,.15f, Time.deltaTime);
        }
        
    }

    public void DisplayAttackAnimation()
    {
        PlayerAnim.SetTrigger(Attack);
    }
}
