using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "A.I/Actions/Rat Attack Action")]
public class RatAttackAction : ScriptableObject
{
    [Header("Attack Animation")] 
    public string AttackAnimation;

    [Header("Attack Cooldown")] 
    public float AttackCooldown = 4f;
    
    [Header("Attack Parameters")]
    public float MinAttackAngle = -30;
    public float MaxAttackAngle = 30;
    public float MinAttackDistance = .5f;
    public float MaxAttackDistance = 2.3f;
    public int AttackNumber = 0;


}
