using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShockJumpscareTrigger : MonoBehaviour //Activated by rat shock death (EnemyCombat)
{
    [SerializeField] private Animator ratAnim;
    [SerializeField] private int jumpscareChance = 50;
    [SerializeField] private int jumpscareChanceIncrement = 20; //How much the change goes up every time the player passes the trigger (until it hits 100)
    private static readonly int JumpScare = Animator.StringToHash("JumpScare");
    private bool shouldHoldJumpscare = true;

    [Header("Camera Cutscene")] 
    [SerializeField] private FollowPlayer jumpscareCamera;
    [SerializeField, Range(.5f, 1.5f)] private float zoom = 1;
    [SerializeField] private float speed = .5f;
    private Vector3 startingCameraVector;
    private Vector3 endingCameraVector;
    private bool doCameraZoom = false;
    private int timesPingPonged; //Prevent camera from doing lerp more than two times

    private void OnEnable()
    {
        StartCoroutine(HoldJumpscare());
        
        //Camera zoom
        startingCameraVector = jumpscareCamera.CameraOffset;
        endingCameraVector = new Vector3(zoom, jumpscareCamera.CameraOffset.y,
            jumpscareCamera.CameraOffset.z);
    }

    private void OnDisable()//Failsafe if the player transitions into another camera
    {
        jumpscareCamera.CameraOffset = startingCameraVector;
    }

    private void FixedUpdate()
    {
        if (doCameraZoom)
        {
            float pingPong = Mathf.PingPong(Time.time * speed, 1);
            jumpscareCamera.CameraOffset = Vector3.Lerp(startingCameraVector, endingCameraVector, pingPong);

            if (pingPong >= .9) //Camera only pingPongs two times
            {
                timesPingPonged++;
                if (timesPingPonged >= 2)
                {
                    doCameraZoom = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !shouldHoldJumpscare)
        {
            var rng = Random.Range(1, 101);

            if (rng <= jumpscareChance) //Jumpscare happens
            {
                StartCoroutine(RatJumpScare());
            }
            else //Improve chances
            {
                jumpscareChance += jumpscareChanceIncrement;
            }  
        }
    }

    private IEnumerator RatJumpScare()
    {
        //Sound
        doCameraZoom = true;
        ratAnim.enabled = true;
        ratAnim.SetTrigger(JumpScare);
        yield return new WaitForSeconds(1.87f); //AnimationDuration
        ratAnim.enabled = false;
        this.gameObject.SetActive(false);
    }

    private IEnumerator HoldJumpscare() //To prevent jumpscare from happening
    {
        yield return new WaitForSeconds(3);
        shouldHoldJumpscare = false;
    }
}
