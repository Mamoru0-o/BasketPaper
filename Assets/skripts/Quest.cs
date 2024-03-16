using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject EndMenu;
    [SerializeField] private TMPro.TMP_Text TimeText;
    private int Minuts;
    private int Seconds;

    [SerializeField] private GameObject PauseMenu;

    [SerializeField] private TMPro.TMP_Text QuestScoreText;
    private int QuestScore;
    private int PlayerScore;

    void Start()
    {
        EndMenu.SetActive(false);
        Minuts = 3;
        Seconds = 0;
        StartCoroutine(Timer());
        QuestScore = 10;
    }

    [System.Obsolete]
    void Update()
    {
        QuestScoreText.text = $" {PlayerScore} / {QuestScore}";
        if (PlayerScore >= QuestScore)
        {
            QuestScore += Random.Range(5, 20);
            PlayerScore = 0;
            Minuts += 3;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TimerGO();
            Time.timeScale = 1f;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
        }

        if (Seconds > 9)
        {
            TimeText.text = $"{Minuts}:{Seconds}";
        }
        else
        {
            TimeText.text = $"{Minuts}:0{Seconds}";
        }
        if (Seconds >= 60)
        {
            Minuts += 1;
            Seconds -= 60;
        }


    }

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "bin")
        {
            PlayerScore += 1;
        }
        else if (collide.gameObject.tag == "button")
        {
            PlayerScore += 20;
        }
        else if (collide.gameObject.tag == "cup")
        {
            PlayerScore += 50;
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        if (Minuts <= 0 && Seconds <= 0)
        {
            EndMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            if (Seconds <= 0)
            {
                Minuts--;
                Seconds = 59;
            }
            else
            {
                Seconds--;
            }
        }
        StartCoroutine(Timer());

    }
    public void TimerGO()
    {
        StartCoroutine(Timer());
    }
}
