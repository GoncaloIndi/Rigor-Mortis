using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FatherCoughing : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Cough());
    }

    private IEnumerator Cough()
    {
        while (true)
        {
            var rng = Random.Range(4.5f, 27f);
            
            yield return new WaitForSeconds(rng);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Room_2/sfx_DadCough", transform.position);
        }
    }
}
