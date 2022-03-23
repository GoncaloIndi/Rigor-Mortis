using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePusher : MonoBehaviour
{

    [SerializeField] private float forceMagnitude;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == 7)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null)
            {
                var position = transform.position;
                Vector3 forceDirection = hit.gameObject.transform.position - position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                
                rb.AddForceAtPosition(forceDirection * forceMagnitude , position, ForceMode.Impulse);
            }
        }
    }
}
