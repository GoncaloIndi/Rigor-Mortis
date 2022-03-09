using System.Collections;
using UnityEngine;
using XInputDotNetPure;

public class ToyBlocksVibration : MonoBehaviour
{
    //From xinput don't know wtf it does
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(VibrateController());
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
