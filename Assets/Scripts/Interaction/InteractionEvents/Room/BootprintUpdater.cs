using UnityEngine;

public class BootprintUpdater : InteractionEvent
{
    [SerializeField] private RatNestItem ratNestItemEvent;

    [SerializeField] private GameObject updatedBootprint;

    public override void Trigger()
    {
        ratNestItemEvent.Bootprint = updatedBootprint;
    }
}
