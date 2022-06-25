using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUpdater : MonoBehaviour
{
    private PlayerStats playerStatsScript;
    private Image statusImage;

    [SerializeField] private int yellowHPTrigger, redHPTrigger;
    [SerializeField] private Sprite greenHpSprite, yellowHPSprite, redHPSprite;

    private void Awake()
    {
        statusImage = GetComponent<Image>();
        playerStatsScript = FindObjectOfType<PlayerStats>();
    }

    private void OnEnable()
    {
        UpdateStatus(); 
    }

    private void UpdateStatus()
    {
        statusImage.sprite = greenHpSprite; //Green
        
        if (playerStatsScript.PlayerHp < yellowHPTrigger)
        {
            statusImage.sprite = yellowHPSprite; //Yellow
            if (playerStatsScript.PlayerHp < redHPTrigger)
            {
                statusImage.sprite = redHPSprite; //Red
            }
        }
    }
}
