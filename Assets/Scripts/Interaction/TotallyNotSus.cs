using UnityEngine;

public class TotallyNotSus : Interactible
{
    [SerializeField] private GameObject transitionToActivate;
    private int tapCount = 0;

    public override void Interact()
    {
        if (tapCount < 15)
        {
            tapCount++;
        }
        else
        {
            transitionToActivate.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
