using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainMenuAnimations : MonoBehaviour
{
    // 41 seconds
    [SerializeField] private Sprite defaultBackground, litWithBear, litWithBearRed, litWithoutBear;
    [SerializeField] private GameObject music;

    private float timeElapsed;

    private Image menuBackground;

    private void Awake()
    {
        menuBackground = GetComponent<Image>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(StartAnimation), 0, 120);
    }

    private void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
    }

    private void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        music.SetActive(true);
        
        while (timeElapsed <= 40.5f)
        {
            float delayBetweenEvent = Random.Range(1, 3.5f);
            float timeActive = Random.Range(.1f, .4f);
            if (timeElapsed + delayBetweenEvent < 119.5)
            {
                yield return new WaitForSeconds(delayBetweenEvent);
            }
            //Event
            menuBackground.sprite = litWithBear;
            yield return new WaitForSeconds(timeActive);
            menuBackground.sprite = defaultBackground;
        }
        menuBackground.sprite = defaultBackground;

        while (timeElapsed <= 119.5)
        {
            float delayBetweenEvent = Random.Range(1, 4.5f);
            float timeActive = Random.Range(.03f, .1f);
            if (timeElapsed + delayBetweenEvent < 119.5)
            {
                yield return new WaitForSeconds(delayBetweenEvent);
            }
            
            //Event
            float rng = Random.Range(0, 2);
            if (rng == 0)
            {
                menuBackground.sprite = litWithoutBear;
            }
            else
            {
                menuBackground.sprite = litWithBearRed;
            }

            
            yield return new WaitForSeconds(timeActive);
            menuBackground.sprite = defaultBackground;
        }
        
        menuBackground.sprite = defaultBackground;
        music.SetActive(false);
        timeElapsed = 0;
    }
}
