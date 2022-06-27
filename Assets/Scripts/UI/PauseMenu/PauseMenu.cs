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
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ButtonPressed");
        pauseGameScript.Pause(false);
    }

    public void Options()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ButtonPressed");
        defaultMenu.SetActive(false);
        optionsMenu.SetActive(true);
        pauseGameScript.HandleOptionsButtonSelection(true);
    }

    public void QuitGame()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ButtonPressed");
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
            pauseGameScript.Pause(false);
        }
    }
    
    
}
