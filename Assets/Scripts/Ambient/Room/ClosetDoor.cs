using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClosetDoor : MonoBehaviour
{
    public bool IsAffectedByWind = false;
    [SerializeField] private float minDelay = 10;
    [SerializeField] private float maxDelay = 32;
    [SerializeField] private Animator closetAnim;
    private static readonly int One = Animator.StringToHash("One");
    private static readonly int Two = Animator.StringToHash("Two");
    private static readonly int Three = Animator.StringToHash("Three");

    private void OnEnable()
    {
        if (!IsAffectedByWind) return;
        StartCoroutine(SpookyDoor());
    }

    private IEnumerator SpookyDoor()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay); //After delay chooses a random animation to play (Diferent audio clips for diferent animations)
            yield return new WaitForSeconds(delay);
            int rng = Random.Range(1, 4);
            
            switch (rng)
            {
                case 1:
                    closetAnim.SetTrigger(One);
                    break;
                case 2:
                    closetAnim.SetTrigger(Two);
                    break;
                case 3:
                    closetAnim.SetTrigger(Three);
                    break;
            }
        }
    }
}
