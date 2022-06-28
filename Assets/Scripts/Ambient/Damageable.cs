using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private string fmodEvent;

    public virtual void OnDamage()
    {
        if (fmodEvent != null)
        {
            FMODUnity.RuntimeManager.PlayOneShot(fmodEvent);
        }
    }
}
