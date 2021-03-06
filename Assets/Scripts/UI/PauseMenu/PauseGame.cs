using UnityEngine;
using UnityEngine.EventSystems;
using XInputDotNetPure;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerActions playerActionsScript;
    [Header("Buttons")] [SerializeField] private GameObject onPauseButton, optionsFirstButton, optionsClosedButton;
    
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public static bool IsGamePaused;
    private bool cameFromNoInput;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    public void Pause(bool pauseFromNoInput)
    {
        if (!IsGamePaused) //Pause game
        {
            IsGamePaused = true;
            pauseMenu.SetActive(true);
            GamePad.SetVibration(playerIndex, 0, 0); //Prevent infinite vibration
            if (!pauseFromNoInput) //To switch action maps accordingly
            {
                cameFromNoInput = false;
                playerActionsScript.PlayerToPauseMenuUI();
            }
            else
            {
                cameFromNoInput = true;
                playerActionsScript.PauseToNoInput(false);
            }


            Time.timeScale = 0;
            
            //Select default button
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(onPauseButton);
        }
        else //Resume game
        {
            IsGamePaused = false;
            pauseMenu.SetActive(false);

            if (cameFromNoInput)
            {
                playerActionsScript.PauseToNoInput(true);
            }
            else
            {
                playerActionsScript.PlayerToPauseMenuUI();
            }
            
            
            Time.timeScale = 1;
        }
    }

    public void HandleOptionsButtonSelection(bool isOptionsMenuOpening) //To be called by pauseMenu Buttons
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (isOptionsMenuOpening)
        {
            EventSystem.current.SetSelectedGameObject(optionsFirstButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(optionsClosedButton);
        }
    }
    
    
}
