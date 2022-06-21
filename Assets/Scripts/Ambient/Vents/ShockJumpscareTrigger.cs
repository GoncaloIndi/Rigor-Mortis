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
    [SerializeField, Range(.2f, 1.5f)] private float zoom = 1;
    [SerializeField] private float lerpSpeed = .5f;
    private Vector3 startingCameraVector;
    private Vector3 endingCameraVector;
    private bool doCameraZoom = false;
    [SerializeField] private float smoothnessMultiplier = 2;
    [SerializeField] private PlayerActions playerActionsScript;
    private float lerpTimer;
    private bool isZoomingBackwards = true;

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
        jumpscareCamera.CameraSmoothness /= smoothnessMultiplier;
    }

    private void FixedUpdate()
    {

        if (doCameraZoom) //Fuck linear interpolation, all my homies hate linear interpolation
        {
            lerpTimer *= Time.time * lerpSpeed;
            
            if (!isZoomingBackwards)
            {
                jumpscareCamera.CameraOffset = Vector3.Lerp(startingCameraVector, endingCameraVector, lerpTimer);
            }
            else
            {
                jumpscareCamera.CameraOffset = Vector3.Lerp(endingCameraVector, startingCameraVector, lerpTimer);
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
        playerActionsScript.PlayerToNoInput(true);
        doCameraZoom = true;
        lerpTimer = 0; //Reset Lerp
        jumpscareCamera.CameraSmoothness *= smoothnessMultiplier;
        ratAnim.enabled = true;
        ratAnim.SetTrigger(JumpScare);
        yield return new WaitForSeconds(1.87f); //AnimationDuration
        ratAnim.enabled = false;
        isZoomingBackwards = false;
        lerpTimer = 0; //Reset Lerp
        yield return new WaitForSeconds(.5f); //Time to lerpBackwards
        playerActionsScript.PlayerToNoInput(false);
        this.gameObject.SetActive(false);
    }

    private IEnumerator HoldJumpscare() //To prevent jumpscare from happening
    {
        yield return new WaitForSeconds(3);
        shouldHoldJumpscare = false;
        
    }
}
