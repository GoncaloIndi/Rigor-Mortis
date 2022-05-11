using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Thunder : MonoBehaviour
{
    [SerializeField] private float delayBetweenThunders;
    [SerializeField] private float thunderDistance = 12;
    [SerializeField] private bool isStormClosingIn = true;
    [SerializeField] private float minStormFlash;
    [SerializeField] private float maxStormFlash;
    private Light lighting;

    private void Awake()
    {
        lighting = GetComponent<Light>();
    }

    private void StormFurther() //When the storm is getting further away
    {
        thunderDistance += Random.Range(1, 2.5f);
        if (thunderDistance >= 12)
        {
            isStormClosingIn = true;
        }
    }
    
    private void StormCloser() //When the storm is getting closer
    {
        thunderDistance -= Random.Range(1, 2.5f);
        if (thunderDistance <= 2.6f)
        {
            isStormClosingIn = false;
        }
    }

    private void ThunderSound()
    {
        //Implement thunder sounds based on distance
    }

    private IEnumerator Thunderstorm()
    {
        while (true)
        {
            //Delay between thunders
            delayBetweenThunders = Random.Range(20, 70);
            yield return new WaitForSeconds(delayBetweenThunders);
            
            //Lighting
            minStormFlash = Random.Range(.05f, .15f);
            maxStormFlash = Random.Range(.4f, .6f);
            lighting.enabled = true;
            yield return new WaitForSeconds(minStormFlash);
            lighting.enabled = false;
            yield return new WaitForSeconds(minStormFlash / 1.5f);
            lighting.enabled = true;
            yield return new WaitForSeconds(maxStormFlash);
            lighting.enabled = false;
            
            //Thunder
            yield return new WaitForSeconds(thunderDistance);
            if (isStormClosingIn)
            {
                StormCloser();
                ThunderSound();
            }
            else
            {
                StormFurther();
                ThunderSound();
            }
        }
        
        
        
    }

    private void OnEnable()
    {
        StartCoroutine(Thunderstorm());
    }
}
