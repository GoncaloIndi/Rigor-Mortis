using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PauseGame pauseGameScript;

    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject defaultMenu;

    

    public void ResumeGame()
    {
        pauseGameScript.Pause();
    }

    public void Options()
    {
        defaultMenu.SetActive(false);
        optionsMenu.SetActive(true);
        pauseGameScript.HandleOptionsButtonSelection(true);
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
            pauseGameScript.HandleOptionsButtonSelection(false);
        }
        else
        {
            pauseGameScript.Pause();
        }
    }
    
    
}
