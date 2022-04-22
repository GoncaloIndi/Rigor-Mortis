using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;

    private float playerBackwardsMovementSpeed;

    [SerializeField] private float playerRotationSpeed = 55f;

    [HideInInspector] public PlayerActions PlayerActionsScript;
    
    [HideInInspector] public PlayerStats PlayerStatsScript;

    [HideInInspector] public PlayerAnimations PlayerAnimationsScript;

    [Header("Modern Movement")]
    public GameObject CurrentCamera;

    public GameObject CameraToUseMovement;
    public bool IsHoldingMovementCamera = false;

    //Character Controller Related
    private Vector3 gravityVector;
    private float sprintSpeedMultiplier = 1.6f;
    private float gravity = -9.81f;

    private void Awake()
    {
        PlayerStatsScript = GetComponent<PlayerStats>();
        playerBackwardsMovementSpeed = -PlayerStatsScript.PlayerFowardMovementSpeed *.8f;
        playerController = GetComponent<CharacterController>();
        PlayerActionsScript = GetComponent<PlayerActions>();
        PlayerAnimationsScript = GetComponent<PlayerAnimations>();
        CurrentCamera = FindObjectOfType<FollowPlayer>().gameObject;
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        if(GameSettings.IsUsingTankControls) UseTankControls();
        else
        {
            if(!PlayerStatsScript.IsOnTargetLockOn) MovePlayerBasedOnCamera();
            else LockOnMovementLogic();
        }

        //For alternate controls camera holding
        if (IsHoldingMovementCamera)
        {
            SwitchCameraBasedInput();
        }
    }

    private void ApplyGravity()
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


    }

    //Tank Controls
    private void MovePlayer(float direction)
    {
        if (direction > 0.1)
        {
            playerController.Move(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed);
            
        }
        else if(direction < -0.1)
        {
            playerController.Move(transform.forward * playerBackwardsMovementSpeed);
        }
        
    }

    private void RotatePlayer(float rotationDirection)
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

    private void UseTankControls()
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
    
    //Alternate Controls
    private void MovePlayerBasedOnCamera()
    {
        if (PlayerStatsScript.CanMove && PlayerStatsScript.CanRotate)
        {
            Vector3 xMovement = CurrentCamera.transform.right * PlayerActionsScript.PlayerMovementVector.x;
            Vector3 yMovement = Vector3.zero;
            Vector3 zMovement = CurrentCamera.transform.forward * PlayerActionsScript.PlayerMovementVector.y;
            Vector3 movement = xMovement + yMovement + zMovement;

            movement = new Vector3(movement.x, 0, movement.z);
            movement.Normalize();

            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement), playerRotationSpeed * 10 * Time.deltaTime );
            }

            playerController.Move(movement * PlayerStatsScript.PlayerFowardMovementSpeed);
        }
        else if (PlayerStatsScript.CanMove && !PlayerStatsScript.CanRotate) 
        {
            Vector3 xMovement = CurrentCamera.transform.right * PlayerActionsScript.PlayerMovementVector.x;
            Vector3 yMovement = Vector3.zero;
            Vector3 zMovement = CurrentCamera.transform.forward * PlayerActionsScript.PlayerMovementVector.y;
            Vector3 movement = xMovement + yMovement + zMovement;
            
            movement = new Vector3(movement.x, 0, movement.z);
            movement.Normalize();

            playerController.Move(movement * PlayerStatsScript.PlayerFowardMovementSpeed);
        }
        
    }

    private void SwitchCameraBasedInput()
    {
        if (PlayerActionsScript.PlayerMovementVector != Vector2.zero) return;

        CurrentCamera = CameraToUseMovement;
        IsHoldingMovementCamera = false;
    }

    private void LockOnMovementLogic() //Verifies the current Quadrant of the vector and determines how the input should work based on that
    {
        if(!PlayerStatsScript.CanMove) return;
        //To simplify math Q1 = 1 | Q2 = 2 | Q3 = -1 | Q4 = -2
        int inputQuadrant = 0; // Q1 X+ | Q2 Y+ | Q3 X- | Q4 Y-

        //Verify enemy quadrant
        if (PlayerStatsScript.LockOnVector.x > 0 && PlayerStatsScript.LockOnVector.z > 0) //Q1
        {
            if (PlayerStatsScript.LockOnVector.x > PlayerStatsScript.LockOnVector.z) inputQuadrant = 1;
            else inputQuadrant = 2;
        }
        else if (PlayerStatsScript.LockOnVector.x < 0 && PlayerStatsScript.LockOnVector.z > 0) //Q2
        {
            if (-PlayerStatsScript.LockOnVector.x > PlayerStatsScript.LockOnVector.z) inputQuadrant = -1;
            else inputQuadrant = 2;
        }
        else if (PlayerStatsScript.LockOnVector.x < 0 && PlayerStatsScript.LockOnVector.z < 0) //Q3
        {
            if (PlayerStatsScript.LockOnVector.x < PlayerStatsScript.LockOnVector.z) inputQuadrant = -1;
            else inputQuadrant = -2;
        }
        else if (PlayerStatsScript.LockOnVector.x > 0 && PlayerStatsScript.LockOnVector.z < 0) //Q4
        {
            if (PlayerStatsScript.LockOnVector.x > -PlayerStatsScript.LockOnVector.z) inputQuadrant = 1;
            else inputQuadrant = -2;
        }
        
        //Handle movement
        if (inputQuadrant == -1)
        {
            if(PlayerActionsScript.PlayerMovementVector.x > 0) playerController.Move(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed);
            else if (PlayerActionsScript.PlayerMovementVector.x < 0) playerController.Move(transform.forward * playerBackwardsMovementSpeed);
        }
        if (inputQuadrant == -2)
        {
            if(PlayerActionsScript.PlayerMovementVector.y > 0) playerController.Move(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed);
            else if (PlayerActionsScript.PlayerMovementVector.y < 0) playerController.Move(transform.forward * playerBackwardsMovementSpeed);
        }
        if (inputQuadrant == 1)
        {
            if(PlayerActionsScript.PlayerMovementVector.x < 0) playerController.Move(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed);
            else if (PlayerActionsScript.PlayerMovementVector.x > 0) playerController.Move(transform.forward * playerBackwardsMovementSpeed);
        }
        if (inputQuadrant == 2)
        {
            if(PlayerActionsScript.PlayerMovementVector.y < 0) playerController.Move(transform.forward * PlayerStatsScript.PlayerFowardMovementSpeed);
            else if (PlayerActionsScript.PlayerMovementVector.y > 0) playerController.Move(transform.forward * playerBackwardsMovementSpeed);
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
    
    public void ForcePlayerToWalk() //Called By PlayerActions WEIRD CHECK LATER
    {
        if (!PlayerStatsScript.CanRun) return;
        
        PlayerStatsScript.PlayerFowardMovementSpeed /= sprintSpeedMultiplier;
        PlayerAnimationsScript.DisplayRunningAnimation = false;
    }
    

}
