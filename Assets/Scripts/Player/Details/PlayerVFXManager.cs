using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem woodchips;

    public void WoodchipsVFX()
    {
        woodchips.Play();
    }
}
