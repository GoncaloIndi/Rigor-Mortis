using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerPosition;

    public Vector3 CameraOffset;

    [SerializeField] private float cameraSmoothness;

    //Both have min an max values to clamp the camera
    [SerializeField] private float[] xCameraClamp;
    [SerializeField] private float[] zCameraClamp;

    private void Awake()
    {
        RenderSettings.fog = true;
        playerPosition = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = playerPosition.position + CameraOffset;
        var position = transform.position;
        Vector3 smoothPosition = Vector3.Lerp(position, newPosition, cameraSmoothness * Time.fixedDeltaTime);

        float xPosition = Mathf.Clamp(smoothPosition.x, xCameraClamp[0], xCameraClamp[1]);
        float yPosition = smoothPosition.y;
        float zPosition = Mathf.Clamp(smoothPosition.z, zCameraClamp[0], zCameraClamp[1]);

        position = new Vector3(xPosition, yPosition, zPosition);
        transform.position = position;
    }
}
