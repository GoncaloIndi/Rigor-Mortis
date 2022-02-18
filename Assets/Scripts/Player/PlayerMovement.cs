using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private float playerBackwardsMovementSpeed;

    [SerializeField] private float playerRotationSpeed = 55f;

    [HideInInspector] public PlayerActions PlayerActionsScript;
    
    [HideInInspector] public PlayerStats PlayerStatsScript;

    private float sprintSpeedMultiplier = 1.08f;

    private void Awake()
    {
        PlayerStatsScript = GetComponent<PlayerStats>();
        playerBackwardsMovementSpeed = PlayerStatsScript.PlayerFowardMovementSpeed;
        playerRigidbody = GetComponent<Rigidbody>();
        PlayerActionsScript = GetComponent<PlayerActions>();
    }

    private void FixedUpdate()
    {
        //Apply movement
        if(PlayerStatsScript.CanMove)
        {
            MovePlayer(PlayerActionsScript.PlayerMovementVector.y);
            RotatePlayer(PlayerActionsScript.PlayerMovementVector.x);
        }       
    }

    public void MovePlayer(float direction)
    {
        if (direction > 0.1)
        {
            playerRigidbody.AddForce(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed , ForceMode.Force);
        }
        else if(direction < -0.1)
        {
            playerRigidbody.AddForce(transform.forward * -playerBackwardsMovementSpeed , ForceMode.Force);
        }
        
    }

    public void RotatePlayer(float rotationDirection)
    {
        if (rotationDirection > 0.1)
        {
            transform.Rotate(Vector3.up * (playerRotationSpeed * Time.deltaTime));
        }
        else if(rotationDirection < -0.1)
        {
            transform.Rotate(Vector3.up * (-playerRotationSpeed * Time.deltaTime));
        }
    }

    public void StartPlayerSprintingMomentum() //Called By PlayerActions
    {
        PlayerStatsScript.PlayerFowardMovementSpeed *= sprintSpeedMultiplier;
        playerRigidbody.AddForce(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed * 2.5f, ForceMode.Force);
    }

    public void StopPlayerSprintingMomentum() //Called By PlayerActions
    {
        playerRigidbody.AddForce(transform.forward * -PlayerStatsScript.PlayerFowardMovementSpeed * 3.5f, ForceMode.Force);
        PlayerStatsScript.PlayerFowardMovementSpeed /= sprintSpeedMultiplier;
    }

    public void ApplyJumpStartingMomentum(bool isMovingForward)
    {
        if (isMovingForward)
        {
            playerRigidbody.AddForce(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed * 2.5f, ForceMode.Force);
        }
        else
        {
            playerRigidbody.AddForce(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed * -2.5f, ForceMode.Force);
        }
        
    }


}
