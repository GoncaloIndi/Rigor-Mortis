using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerPosition;


    public Vector3 CameraOffset;

    public float CameraSmoothness;

    //Both have min an max values to clamp the camera
    [Header("Camera Constraints")]
    [SerializeField] private float[] xCameraClamp;
    [SerializeField] private float[] zCameraClamp;

    [Header("Fog")] 
    [SerializeField] private bool isFogEnabled = true;

    [SerializeField] private float fogDensity = .2f;
    

    private void Awake()
    {
        //Cursor.visible = false;
        playerPosition = FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }

    private void OnEnable() 
    {
        RenderSettings.fog = isFogEnabled;
        RenderSettings.fogDensity = fogDensity;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = playerPosition.position + CameraOffset;
        var position = transform.position;
        Vector3 smoothPosition = Vector3.Lerp(position, newPosition, CameraSmoothness * Time.fixedDeltaTime);

        float xPosition = Mathf.Clamp(smoothPosition.x, xCameraClamp[0], xCameraClamp[1]);
        float yPosition = smoothPosition.y;
        float zPosition = Mathf.Clamp(smoothPosition.z, zCameraClamp[0], zCameraClamp[1]);

        position = new Vector3(xPosition, yPosition, zPosition);
        transform.position = position;
    }

}
