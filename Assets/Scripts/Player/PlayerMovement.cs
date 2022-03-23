using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;

    private float playerBackwardsMovementSpeed;

    [SerializeField] private float playerRotationSpeed = 55f;

    [HideInInspector] public PlayerActions PlayerActionsScript;
    
    [HideInInspector] public PlayerStats PlayerStatsScript;

    [HideInInspector] public PlayerAnimations PlayerAnimationsScript;

    //Character Controller Related
    private Vector3 gravityVector;
    private float sprintSpeedMultiplier = 1.6f;
    private float gravity = -9.81f;

    private void Awake()
    {
        PlayerStatsScript = GetComponent<PlayerStats>();
        playerBackwardsMovementSpeed = -PlayerStatsScript.PlayerFowardMovementSpeed;
        playerController = GetComponent<CharacterController>();
        PlayerActionsScript = GetComponent<PlayerActions>();
        PlayerAnimationsScript = GetComponent<PlayerAnimations>();
    }

    private void FixedUpdate()
    {
        //Apply movement
        if(PlayerStatsScript.CanMove && PlayerStatsScript.CanRotate)
        {
            MovePlayer(PlayerActionsScript.PlayerMovementVector.y);
            RotatePlayer(PlayerActionsScript.PlayerMovementVector.x);
        }
        else if(PlayerStatsScript.CanMove && !PlayerStatsScript.CanRotate)
        {
            MovePlayer(PlayerActionsScript.PlayerMovementVector.y);
        }
    }

    public void MovePlayer(float direction)
    {
        //Gravity
        if (playerController.isGrounded)
        {
            gravityVector.y = -1;
        }
        else
        {
            gravityVector.y -= gravity * -2 * Time.deltaTime;
        }
        playerController.Move(gravityVector);
        
        
        if (direction > 0.1)
        {
            playerController.Move(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed);
            
        }
        else if(direction < -0.1)
        {
            playerController.Move(transform.forward * playerBackwardsMovementSpeed);
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
        PlayerStatsScript.IsRunning = true;
        if (!PlayerStatsScript.CanRun) return;
        
        PlayerStatsScript.PlayerFowardMovementSpeed *= sprintSpeedMultiplier;
        PlayerAnimationsScript.DisplayRunningAnimation = true;
    }

    public void StopPlayerSprintingMomentum() //Called By PlayerActions
    {
        PlayerStatsScript.IsRunning = false;
        if (!PlayerStatsScript.CanRun) return;
        
        PlayerStatsScript.PlayerFowardMovementSpeed /= sprintSpeedMultiplier;
        PlayerAnimationsScript.DisplayRunningAnimation = false;
    }
    
    public void ForcePlayerToWalk() //Called By PlayerActions
    {
        if (!PlayerStatsScript.CanRun) return;
        
        PlayerStatsScript.PlayerFowardMovementSpeed /= sprintSpeedMultiplier;
        PlayerAnimationsScript.DisplayRunningAnimation = false;
    }
    

}
