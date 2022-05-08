using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAnimations : MonoBehaviour
{
    [SerializeField] private Animator ratAnim;
    private float speed;
    private Vector3 lastPosition;

    private RatStateManager ratStateManager;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Damage = Animator.StringToHash("Damage");
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int ElectricDeath = Animator.StringToHash("ElectricDeath");

    private void Awake()
    {
        ratStateManager = GetComponent<RatStateManager>();
    }

    private void FixedUpdate()
    {
        //Yoinked from the internet (Calculates the speed)
        var position = transform.position;
        speed = Mathf.Lerp(speed, (position - lastPosition).magnitude / Time.deltaTime, 0.75f);
        lastPosition = position;

        ratAnim.SetFloat(Speed, speed);
    }

    public void DisplayDamageAnimation() //Called by enemyCombat
    {
        ratStateManager.RatNavMeshAgent.speed = 0;
        ratAnim.SetTrigger(Damage);
    }

    public void DisplayDeathAnimation()
    {
        ratAnim.SetTrigger(Death); 
    }

    public void DisplayElectrifyAnimation()
    {
        ratAnim.SetTrigger(ElectricDeath);
    }
}
