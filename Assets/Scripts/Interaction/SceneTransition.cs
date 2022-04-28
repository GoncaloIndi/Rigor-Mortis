using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : Interactible
{
    [SerializeField] private Animator fadeEffect;

    [Header("Scene Transforms")] [SerializeField] private Vector3 playerTeleportPosition;

    private Transform playerPosition;

    protected override void Awake()
    {
        playerPosition = FindObjectOfType<PlayerStats>().GetComponent<Transform>();
    }

    public override void Interact()
    {
        
    }

    private void TeleportPlayer()
    {
        playerPosition.position = playerTeleportPosition;
    }
}
