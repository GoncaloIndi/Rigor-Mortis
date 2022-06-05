using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Range(0, 2)] public int CurrentButton = 0; //0-Resume / 1-Options / 2-Quit

    [SerializeField] private PauseGame pauseGameScript;

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject defaultMenu;

    [Header("Buttons")] [SerializeField] private GameObject onPauseButton, optionsFirstButton, optionsClosedButton;

    public void ResumeGame()
    {
        pauseGameScript.Pause();
    }

    public void Options()
    {
        defaultMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }

    public void Back() //Called by PlayerAction & backButton
    {
        if (optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
            defaultMenu.SetActive(true);
        }
        else
        {
            pauseGameScript.Pause();
        }
    }
    
    
}
