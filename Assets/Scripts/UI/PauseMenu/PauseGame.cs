using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerActions playerActionsScript;

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
        }
        else //Resume game
        {
            IsGamePaused = false;
            pauseMenu.SetActive(false);
            playerActionsScript.PlayerToPauseMenuUI();
            
            Time.timeScale = 1;
        }
    }
    
    
}
