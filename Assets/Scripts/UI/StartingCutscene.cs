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

    private PlayerActions playerActionsScript;
    private static readonly int ForceDefault = Animator.StringToHash("ForceDefault");
    [SerializeField] private TutorialMessage tutorial;

    [Header("In Game Cutscene")]
    [SerializeField] private GameObject roomCamera;
    [SerializeField] private GameObject cutsceneCamera;
    private PlayerAnimations playerAnimations;
    private Animator cutsceneAnim;
    private static readonly int StartCutscene = Animator.StringToHash("Start");
    private static readonly int Blink = Animator.StringToHash("Blink");

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        if (!shouldPlayCutscene)
        {
            this.gameObject.SetActive(false);
            DarkenerAnim.SetTrigger(ForceDefault);
        }
        else
        {
            cutsceneText = this.gameObject.GetComponent<Text>();
            playerActionsScript = FindObjectOfType<PlayerActions>();
            playerActionsScript.PlayerToNoInput(true);
            playerAnimations = FindObjectOfType<PlayerAnimations>();
            cutsceneAnim = cutsceneCamera.GetComponent<Animator>();
        }
    }

    private void Start()
    {
        if (shouldPlayCutscene)
        {
           roomCamera.SetActive(false);
           cutsceneCamera.SetActive(true);
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
            
            StartInGameCutscene();
            
        }
        
    }
    
    //Second part of the cutscene (In game)

    private void StartInGameCutscene()
    {
        Invoke("CutsceneBlink", 12.65f);
        Invoke("EndInGameCutScene", 13);
        //roomCamera.SetActive(false);
        //cutsceneCamera.SetActive(true);
        cutsceneAnim.SetTrigger(StartCutscene);
        playerAnimations.DisplayCutsceneAnimation();
    }

    private void CutsceneBlink()
    {
        DarkenerAnim.SetTrigger(Blink);
    }
    
    private void EndInGameCutScene()
    {
        roomCamera.SetActive(true);
        cutsceneCamera.SetActive(false);
        playerActionsScript.PlayerToNoInput(false);
        tutorial.DisplayInteractMessage();
    }
}
