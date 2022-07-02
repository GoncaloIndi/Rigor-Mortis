using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnItemUse : MonoBehaviour //Where items will be used
{
    private PlayerStats playerStatsScript;
    [SerializeField] private int itemToBeUsed; //Item ID
    [SerializeField] private GameObject turnedOnEffect; 

    private void Awake()
    {
        playerStatsScript = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerStatsScript.CurrentItemUse = this;
    }

    private void OnTriggerExit(Collider other)
    {
        playerStatsScript.CurrentItemUse = null;
    }

    public virtual bool CheckForItem(int currentItem)
    {
        if (currentItem != itemToBeUsed) return false;
        //DefaultCase
        turnedOnEffect.SetActive(true);
        this.gameObject.SetActive(false);
        return true;
    }
}
