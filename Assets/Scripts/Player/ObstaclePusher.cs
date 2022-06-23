using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using XInputDotNetPure;
using Random = UnityEngine.Random;

public class ObstaclePusher : MonoBehaviour
{
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    private bool playDragSound;
    private bool isSoundPlaying;

    [SerializeField] private float forceMagnitude;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == 7)
        {
            if (!playDragSound && !isSoundPlaying)
            {
                playDragSound = true;
                StartCoroutine(DragSound());
            }

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
        playDragSound = false;
    }

    private IEnumerator DragSound()
    {
        isSoundPlaying = true;
        while (playDragSound)
        {
            float rng = Random.Range(.9f, 1.5f);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/sfx_DragObject");
            yield return new WaitForSeconds(rng);
        }
        isSoundPlaying = false;
    }
}
