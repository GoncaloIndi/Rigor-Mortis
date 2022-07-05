using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatVFXManager : MonoBehaviour
{
    [Header("Death Particles")]
    [SerializeField] private ParticleSystem dustVFX;
    [SerializeField] private ParticleSystem electricVFX;
    [Header("Blood")] 
    //[SerializeField] private GameObject bloodVFX; Change when new blood mechanic is implemented
    [SerializeField] private ParticleSystem bloodVFX;

    public void DustVFX() //Dust when the rat dies via combat
    {
        dustVFX.Play();
    }
    
    public void SmokeVFX() //Smoke when the rat dies via electric trap
    {
        electricVFX.Play();
    }

    public void BloodVFX(Vector3 bloodPos) //Temp
    {
        bloodVFX.transform.position = bloodPos;
        bloodVFX.Play();
    }
    
}
