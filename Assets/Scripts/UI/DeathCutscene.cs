using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathCutscene : MonoBehaviour
{
    [SerializeField] private string deathCutsceneText;
    [SerializeField] private Text cutsceneUIText;
    [SerializeField] private Animator faderAnim;
    private static readonly int Darken = Animator.StringToHash("Darken");
    private PlayerActions playerActionsScript;

    private void Awake()
    {
        playerActionsScript = FindObjectOfType<PlayerActions>();
    }

    public IEnumerator StartDeathCutscene()
    {
        playerActionsScript.PlayerToNoInput(true);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/sfx_PlayerDeathStinger");
        faderAnim.SetTrigger(Darken);
        yield return new WaitForSeconds(1.5f);
        cutsceneUIText.gameObject.SetActive(true);
        cutsceneUIText.text = deathCutsceneText;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
