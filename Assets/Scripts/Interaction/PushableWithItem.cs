using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableWithItem : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] private float distanceToRevealItem = .2f;
    [SerializeField] private Collider itemToCollect;


    private void Awake()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(startPosition, transform.position) >= distanceToRevealItem)
        {
            itemToCollect.enabled = true;
            this.enabled = false;
        }
    }
}
