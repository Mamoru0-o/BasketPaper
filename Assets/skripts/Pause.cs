using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject PaperBall;
    [SerializeField] private GameObject EndMenu;
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (PauseMenu.active)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1.0f;
                PaperBall.SetActive(true);
            }
            else
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
                PaperBall.SetActive(false);
            }
        }
    }

    public void OnContinueClick()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        PaperBall.SetActive(true);
    }

    public void OnRestartClick() 
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        PaperBall.SetActive(true);
    }

    public void OnMenuClick() 
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    }

    public void OnFinishClick()
    {
        EndMenu.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 0f;
        PaperBall.SetActive(false);
    }
}
