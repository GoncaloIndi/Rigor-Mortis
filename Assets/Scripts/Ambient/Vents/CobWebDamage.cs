using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobWebDamage : Damageable
{
    [SerializeField] private ParticleSystem webParticles;
    private SpriteRenderer webSprite;
    private bool isWebBroken;

    private void Awake()
    {
        webSprite = GetComponent<SpriteRenderer>();
    }

    public override void OnDamage()
    {
        if (!isWebBroken)
        {
            isWebBroken = true;
            //base.OnDamage(); //Sound
            webSprite.enabled = false;
            webParticles.Play();
        }
        
        
    }
}
