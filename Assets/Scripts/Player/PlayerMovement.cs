using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;

    private float playerBackwardsMovementSpeed;

    [SerializeField] private bool isUsingTankControls = true; //To be put in the options script later

    [SerializeField] private float playerRotationSpeed = 55f;

    [HideInInspector] public PlayerActions PlayerActionsScript;
    
    [HideInInspector] public PlayerStats PlayerStatsScript;

    [HideInInspector] public PlayerAnimations PlayerAnimationsScript;

    private GameObject currentCamera; //Change later based on which camera is rendering

    //Character Controller Related
    private Vector3 gravityVector;
    private float sprintSpeedMultiplier = 1.6f;
    private float gravity = -9.81f;

    private void Awake()
    {
        PlayerStatsScript = GetComponent<PlayerStats>();
        playerBackwardsMovementSpeed = -PlayerStatsScript.PlayerFowardMovementSpeed *.6f;
        playerController = GetComponent<CharacterController>();
        PlayerActionsScript = GetComponent<PlayerActions>();
        PlayerAnimationsScript = GetComponent<PlayerAnimations>();
        currentCamera = FindObjectOfType<FollowPlayer>().gameObject;
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        if(isUsingTankControls) UseTankControls();
        else MovePlayerBasedOnCamera();

        
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
            Vector3 xMovement = currentCamera.transform.right * PlayerActionsScript.PlayerMovementVector.x;
            Vector3 yMovement = Vector3.zero;
            Vector3 zMovement = currentCamera.transform.forward * PlayerActionsScript.PlayerMovementVector.y;
            Vector3 Movement = xMovement + yMovement + zMovement;

            Movement = new Vector3(Movement.x, 0, Movement.z);
            Movement.Normalize();

            if (Movement != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Movement), playerRotationSpeed * 10 * Time.deltaTime );
            }

            playerController.Move(Movement * PlayerStatsScript.PlayerFowardMovementSpeed);
        }
        else if (PlayerStatsScript.CanMove && !PlayerStatsScript.CanRotate) //Need to figure out how to make alternate controls work with lock on
        {
            Vector3 xMovement = currentCamera.transform.right * PlayerActionsScript.PlayerMovementVector.x;
            Vector3 yMovement = Vector3.zero;
            Vector3 zMovement = currentCamera.transform.forward * PlayerActionsScript.PlayerMovementVector.y;
            Vector3 Movement = xMovement + yMovement + zMovement;
            
            Movement = new Vector3(Movement.x, 0, Movement.z);
            Movement.Normalize();
            
            playerController.Move(Movement * PlayerStatsScript.PlayerFowardMovementSpeed);
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
