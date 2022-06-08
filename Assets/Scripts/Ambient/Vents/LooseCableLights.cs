using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LooseCableLights : MonoBehaviour
{
    [SerializeField] private Light cableLight;
    [SerializeField] private float[] lightTime;
    [SerializeField] private float lightChance = 69;

    private void Awake()
    {
        cableLight = GetComponent<Light>();
    }

    private void OnEnable()
    {
        StartCoroutine(CableLights());
        
    }

    private IEnumerator CableLights()
    {
        while (true)
        {
            yield return new WaitForSeconds(lightTime[0]);
            StartCoroutine(EnableLights());
            yield return new WaitForSeconds(lightTime[1]);
            StartCoroutine(EnableLights());
            yield return new WaitForSeconds(lightTime[2]);
            StartCoroutine(EnableLights());
            yield return new WaitForSeconds(lightTime[3]);
            StartCoroutine(EnableLights());
            yield return new WaitForSeconds(lightTime[4]);
        }
    }

    private IEnumerator EnableLights()
    {
        float rng = Random.Range(0, 100);
        if (rng > lightChance) yield break;

        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/sfx_ElectricCable",transform.position);
        cableLight.enabled = true;
        yield return new WaitForSeconds(.1f);
        cableLight.enabled = false;
    }
}
