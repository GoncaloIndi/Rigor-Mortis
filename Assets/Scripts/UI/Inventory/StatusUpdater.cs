using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUpdater : MonoBehaviour
{
    private PlayerStats playerStatsScript;
    private Animator statusAnim;

    [SerializeField] private int yellowHPTrigger, redHPTrigger;
    private static readonly int Green = Animator.StringToHash("Green");
    private static readonly int Orange = Animator.StringToHash("Orange");
    private static readonly int Red = Animator.StringToHash("Red");

    private void Awake()
    {
        statusAnim = GetComponent<Animator>();
        playerStatsScript = FindObjectOfType<PlayerStats>();
    }

    private void OnEnable()
    {
        UpdateStatus(); 
    }

    private void UpdateStatus()
    {
        if (playerStatsScript.PlayerHp > yellowHPTrigger)
        {
            statusAnim.SetTrigger(Green); //Green
        }
        else if(playerStatsScript.PlayerHp > redHPTrigger && playerStatsScript.PlayerHp < yellowHPTrigger)
        {
            statusAnim.SetTrigger(Orange); //Orange
        }
        else
        {
            statusAnim.SetTrigger(Red); //Red
        }
    }
}
