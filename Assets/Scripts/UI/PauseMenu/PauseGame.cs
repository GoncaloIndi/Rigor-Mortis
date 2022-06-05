using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerActions playerActionsScript;
    [Header("Buttons")] [SerializeField] private GameObject onPauseButton, optionsFirstButton, optionsClosedButton;

    public static bool IsGamePaused;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        if (!IsGamePaused) //Pause game
        {
            IsGamePaused = true;
            pauseMenu.SetActive(true);
            playerActionsScript.PlayerToPauseMenuUI();
            
            Time.timeScale = 0;
            
            //Select default button
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(onPauseButton);
        }
        else //Resume game
        {
            IsGamePaused = false;
            pauseMenu.SetActive(false);
            playerActionsScript.PlayerToPauseMenuUI();
            
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
