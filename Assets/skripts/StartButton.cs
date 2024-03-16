using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject PlayMenu;
    [SerializeField] private GameObject MenuBouttons;

    private void Start()
    {
        PlayMenu.SetActive(false);
    }
    public void OnCLickPlay() 
    {
        PlayMenu.SetActive(true);
        MenuBouttons.SetActive(false);
    }

    public void OnCLickBack()
    {
        PlayMenu.SetActive(false);
        MenuBouttons.SetActive(true);
    }

    public void SurvivalMode()
    {
        SceneManager.LoadScene("SurvivalScene");
    }

    public void NoTimeMode()
    {
        SceneManager.LoadScene("NoTimeScene");
    }

    public void QuestMode()
    {
        SceneManager.LoadScene("QuestScene");
    }
}
