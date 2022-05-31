using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingCutscene : MonoBehaviour
{
    private Text cutsceneText;

    private bool isOnLastTextDisplay = false;

    [SerializeField] private bool shouldPlayCutscene = true;
    [SerializeField] private Animator DarkenerAnim;
    private static readonly int Lighten = Animator.StringToHash("Lighten");

    public PlayerStats PlayerStatsScript;
    private static readonly int ForceDefault = Animator.StringToHash("ForceDefault");

    private void Awake()
    {
        if (!shouldPlayCutscene)
        {
            this.gameObject.SetActive(false);
            DarkenerAnim.SetTrigger(ForceDefault);
        }
        else
        {
            cutsceneText = this.gameObject.GetComponent<Text>();
            PlayerStatsScript = FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>();
            PlayerStatsScript.CanMove = false;
        }
    }

    private void NextDisplay() //Both functions called by animation FadeText
    {
        if (isOnLastTextDisplay)
        {
            this.gameObject.SetActive(false);  
        }
        else
        {
            cutsceneText.text = "A little soldier emerges\nfrom darkness...";
            isOnLastTextDisplay = true;
        }
    }

    private void StartDarkenerFadeOut()
    {
        if (isOnLastTextDisplay)
        {
            DarkenerAnim.SetTrigger(Lighten);
            PlayerStatsScript.CanMove = true;
        }
        
    }
    
}
