using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAnimations : MonoBehaviour
{
    [SerializeField] private Animator ratAnim;
    private float speed;
    private float angle;
    private Vector3 lastPosition;
    private Vector3 oldEulerAngles;
    [SerializeField] private float test = .75f;
    private RatSoundManager ratSFX;

    private RatStateManager ratStateManager;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Damage = Animator.StringToHash("Damage");
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int ElectricDeath = Animator.StringToHash("ElectricDeath");
    private static readonly int Angle = Animator.StringToHash("Angle");

    private void Awake()
    {
        ratStateManager = GetComponent<RatStateManager>();
        ratSFX = GetComponent<RatSoundManager>();
    }

    private void FixedUpdate()
    {
        //Yoinked from the internet (Calculates the speed) POSITION
        var position = transform.position;
        speed = Mathf.Lerp(speed, (position - lastPosition).magnitude / Time.deltaTime, 0.75f);
        lastPosition = position;
        //Yoinked from the internet (Calculates the speed) ROTATION;
 
        angle = Mathf.Lerp(angle, (transform.rotation.eulerAngles - oldEulerAngles).magnitude / Time.deltaTime, test);
        //print(angle);
        oldEulerAngles = transform.rotation.eulerAngles;
    
        ratAnim.SetFloat(Speed, speed);
        ratAnim.SetFloat(Angle, angle);    
        
        //Sound
        ratSFX.ShouldPlayFootSteps = speed > .15f;

    }

    public void DisplayDamageAnimation() //Called by enemyCombat
    {
        ratStateManager.RatNavMeshAgent.speed = 0;
        ratAnim.SetTrigger(Damage);
    }

    public void DisplayAttackAnimation(string attackTrigger)
    {
        ratAnim.SetTrigger(attackTrigger);
    }

    //Player must be in damage animation state to transition to die
    public void DisplayDeathAnimation()
    {
        ratAnim.SetTrigger(Death); 
    }

    public void DisplayElectrifyAnimation()
    {
        ratAnim.SetTrigger(ElectricDeath);
    }
}
