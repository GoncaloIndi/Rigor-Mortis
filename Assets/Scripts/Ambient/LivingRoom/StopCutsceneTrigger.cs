using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCutsceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameplayCamera, cutsceneCamera;
    private PlayerAnimations playerAnimations;
    [SerializeField] private Animator darkenerAnim;
    private static readonly int Blink = Animator.StringToHash("Blink");

    private void Awake()
    {
        playerAnimations = FindObjectOfType<PlayerAnimations>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Stop");
            playerAnimations.StopFallAnimation();
            Invoke("BlinkDarkener", .45f);
            Invoke("DisableCutsceneCamera", .9f);
        }
        
    }

    private void BlinkDarkener()
    {
        darkenerAnim.SetTrigger(Blink);
    }

    private void DisableCutsceneCamera()
    {
        gameplayCamera.SetActive(true);
        cutsceneCamera.SetActive(false);
        this.gameObject.SetActive(false);
    }
    
}
