using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingCutscene : MonoBehaviour
{
    private Text cutsceneText;

    private bool isOnLastTextDisplay = false;

    [SerializeField] private Animator DarkenerAnim;
    private static readonly int Ligthen = Animator.StringToHash("Ligthen");
    private static readonly int Lighten = Animator.StringToHash("Lighten");

    public PlayerStats PlayerStatsScript;

    private void Awake()
    {
        cutsceneText = this.gameObject.GetComponent<Text>();
        PlayerStatsScript = FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>();
        PlayerStatsScript.CanMove = false;
    }

    private void NextDisplay() //Both functions called by animation FadeText
    {
        if (isOnLastTextDisplay)
        {
            Destroy(this.gameObject);
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
