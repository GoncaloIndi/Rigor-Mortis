using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject defaultMenu, optionsMenu;
    [SerializeField] private Animator fadeAnim;
    private static readonly int Fade = Animator.StringToHash("Fade");
    [SerializeField] private GameObject defaultOptionsButton, optionsClosedButton, music;

    private void Awake()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Play()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ButtonPressed");
        StartCoroutine(FadeToNextScene());
    }

    public void Options() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ButtonPressed");
        defaultMenu.SetActive(false);
        optionsMenu.SetActive(true);
        //Set default button in options later
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Quit()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ButtonPressed");
        Application.Quit(0);
    }

    public void Back()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_ButtonPressed");
        if (optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
            defaultMenu.SetActive(true);
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(defaultOptionsButton);
        }
    }

    private IEnumerator FadeToNextScene()
    {
        fadeAnim.SetTrigger(Fade);
        music.SetActive(false);
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_MainMenuKidCry");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
