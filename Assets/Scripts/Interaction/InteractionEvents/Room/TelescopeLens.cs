using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeLens : InteractionEvent
{
    [SerializeField] private GameObject lensFX;
    [SerializeField] private GameObject shards;
    
    public override void Trigger()
    {
        lensFX.SetActive(true);
        shards.SetActive(false);
        StartCoroutine(ResetLensFX());
    }

    private IEnumerator ResetLensFX()
    {
        yield return new WaitForSeconds(.01f);
        lensFX.SetActive(false);
        shards.SetActive(true);
    }
}
