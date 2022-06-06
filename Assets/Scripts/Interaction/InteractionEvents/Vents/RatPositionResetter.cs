using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RatPositionResetter : InteractionEvent 
{
    [SerializeField] private Transform rat;
    [SerializeField] private Vector3[] teleportPositions;
    private RatStateManager ratStateManager;

    private void Awake()
    {
        rat = GetComponent<Transform>();
        ratStateManager = GetComponent<RatStateManager>();
    }

    public override void Trigger()
    {
        if (!this.gameObject.activeSelf) return;
        
        int rng = Random.Range(0, teleportPositions.Length);

        rat.localPosition = teleportPositions[rng];
        ratStateManager.ResetRatState();
    }
}
