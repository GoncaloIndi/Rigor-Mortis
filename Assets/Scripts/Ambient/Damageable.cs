using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private string fmodEvent;
    private string defaultString;

    public virtual void OnDamage()
    {
        if (fmodEvent != null || fmodEvent == defaultString)
        {
            FMODUnity.RuntimeManager.PlayOneShot(fmodEvent);
        }
    }
}
