using System.Collections;
using UnityEngine;
using XInputDotNetPure;

public class ObstaclePusher : MonoBehaviour
{
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    [SerializeField] private float forceMagnitude;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == 7)
        {

            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null)
            {
                var position = transform.position;
                Vector3 forceDirection = hit.collider.ClosestPointOnBounds(position) - position; //Gets closest collider point to the player
                forceDirection.y = -.1f;
                forceDirection.Normalize();
                
                rb.AddForceAtPosition(forceDirection * forceMagnitude , position, ForceMode.Impulse);
                StartCoroutine(VibrateController());
            }
        }
    }

    private IEnumerator VibrateController()
    {
        var vibrationTime = .1f;
        GamePad.SetVibration(playerIndex, .1f, .1f);

        yield return new WaitForSeconds(vibrationTime);
        GamePad.SetVibration(playerIndex, 0, 0);
    }

}
