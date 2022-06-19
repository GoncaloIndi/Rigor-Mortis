using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BloodySword : MonoBehaviour
{
    [SerializeField] private Material[] bloodySwordMats;
    private MeshRenderer swordMesh;
    private int swordHits = 0;

    [SerializeField] private ParticleSystem dropletVFX;
    [SerializeField] private Transform swordTip;

    private void Awake()
    {
        swordMesh = GetComponent<MeshRenderer>();
    }

    public void UpdateSword() //Whenever the player hits the rat
    {
        swordHits++;
        
        if (swordHits == 2)
        {
            swordMesh.material = bloodySwordMats[0];
        }
        else if (swordHits == 4)
        {
            swordMesh.material = bloodySwordMats[1];
        }
        else if (swordHits == 6)
        {
            swordMesh.material = bloodySwordMats[2];
            StartCoroutine(BloodyDroplets());
        }
    }

    private IEnumerator BloodyDroplets() //Random drops of blood from the sword for a while after killing rat
    {
        var timeElapsed = 0;

        while (timeElapsed <= 60)
        {
            var swordTipPosition = swordTip.position;
            dropletVFX.gameObject.transform.position = swordTipPosition;
            dropletVFX.Play();

            var rng = Random.Range(1, 5);
            yield return new WaitForSeconds(rng);
            timeElapsed += rng;
        }
        
    }
    
    
    
    
    
}
