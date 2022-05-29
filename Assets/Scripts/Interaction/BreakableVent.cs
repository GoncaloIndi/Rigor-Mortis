using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableVent : MonoBehaviour
{
    private int timesAttacked = 0;
    [SerializeField] private GameObject[] ventStates;
    [SerializeField] private ParticleSystem metalVFX;
    private bool canBeAttacked = true;
    

    public void Hit()
    {
        if (timesAttacked >= 2)
        {
            canBeAttacked = false;
        }
        if (!canBeAttacked) return;

        ventStates[timesAttacked].SetActive(false);
        timesAttacked++;
        metalVFX.Play();
        ventStates[timesAttacked].SetActive(true);
    }
}
