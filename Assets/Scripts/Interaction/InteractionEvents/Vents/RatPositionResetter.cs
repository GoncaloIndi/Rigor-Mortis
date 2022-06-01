using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RatPositionResetter : InteractionEvent 
{
    [SerializeField] private Transform rat;
    [SerializeField] private Vector3[] teleportPositions;

    private void Awake()
    {
        rat = GetComponent<Transform>();
    }

    public override void Trigger()
    {
        if (!rat.gameObject.activeSelf) return;

        int rng = Random.Range(0, teleportPositions.Length);

        rat.localPosition = teleportPositions[rng];
    }
}
