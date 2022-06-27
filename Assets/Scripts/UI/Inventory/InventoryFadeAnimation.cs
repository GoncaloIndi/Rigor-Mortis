using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFadeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject inventoryBase;
    [SerializeField] private GameObject inventory;
    private Animator anim;
    private static readonly int FadeIn = Animator.StringToHash("FadeIn");
    private static readonly int FadeOut = Animator.StringToHash("FadeOut");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        anim.SetTrigger(FadeIn);
    }

    //CalledByBackgroundAnimations

    public void OnFadeInEnd()
    {
        inventoryBase.SetActive(true);
    }
    
    public void OnFadeOutBegin()
    {
        inventoryBase.SetActive(false);
    }

    public void OnFadeOutEnd()
    {
        inventory.SetActive(false);
    }

    public void TriggerFadeOut()
    {
        anim.SetTrigger(FadeOut);
    }
    
    
}
