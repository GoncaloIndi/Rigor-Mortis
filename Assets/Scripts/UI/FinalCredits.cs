using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCredits : MonoBehaviour
{
    private PlayerActions _playerActions;

    private void Awake()
    {
        _playerActions = FindObjectOfType<PlayerActions>();
    }

    //Called via animation
    public void OnCreditsStart()
    {
        _playerActions.PlayerToNoInput(true);
    }
    
    public void OnCreditsEnd()
    {
        SceneManager.LoadScene(0);
    }
}
