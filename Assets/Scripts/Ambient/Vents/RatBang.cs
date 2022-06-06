using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RatBang : MonoBehaviour
{
    [SerializeField] private Vector3[] bangPositions;
    private Vector3 furthestPosition;
    [SerializeField] private Transform playerPos;
    private float furthestDistance = 0;
    
    private void OnEnable()
    {
        StartCoroutine(RatNoise());
    }

    private IEnumerator RatNoise()
    {
        
        while (true)
        {
            furthestDistance = 0;
            int rng = Random.Range(25, 47);
            yield return new WaitForSeconds(rng);
            for (int i = 0; i < bangPositions.Length; i++)
            {
                float distance = Vector3.Distance(playerPos.position, bangPositions[i]);
                if (distance > furthestDistance)
                {
                    furthestPosition = bangPositions[i];
                    
                    furthestDistance = distance;
                }
            }
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/sfx_RatBang", furthestPosition);
            
        }
    }
}
