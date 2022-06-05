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
    [SerializeField] private GameObject defaultOptionsButton, optionsClosedButton;

    private void Awake()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Play()
    {
        StartCoroutine(FadeToNextScene());
    }

    public void Options() 
    {
        defaultMenu.SetActive(false);
        optionsMenu.SetActive(true);
        //Set default button in options later
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Quit()
    {
        Application.Quit(0);
    }

    public void Back()
    {
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
        //StopMusic
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
