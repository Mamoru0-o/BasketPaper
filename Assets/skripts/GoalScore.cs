using System.Collections;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GoalScore : GetPower
{
    [SerializeField] private TMPro.TMP_Text ScoreText;
    [SerializeField] private MeshRenderer Button;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private Material red;
    [SerializeField] private Material green;
    [SerializeField] private Transform first;
    [SerializeField] private GameObject PowerBar;

    [SerializeField] private TMPro.TMP_Text EndScoreText;
    [SerializeField] private TMPro.TMP_Text Multiplier;
    [SerializeField] private TMPro.TMP_Text EndGetCoins;
    private float MultiplierF;
    private int Combo;

    static protected int BalanceCount;

    private bool PS = false;

    protected int score = 0;

    static protected int Lives;
    static protected int MaxLives = 5;
    private bool Goal = false;
    private int Heal = 0;

    void Start()
    {
        Combo = 0;
        MultiplierF = 1.0f;
        Lives = 5;
        try 
        {
            WinScreen.SetActive(false);
        }
        catch { }
    }

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "bin")
        {
            score++;
        }
        else if (collide.gameObject.tag == "button")
        {
            score += 20;
            
            if (!PS)
            {
                PS = true;
                WinScreen.SetActive(true);
                Button.material = green;
            }
            else
            {
                PS = false;
                WinScreen.SetActive(false);
                Button.material = red;
            }
        }
        else if (collide.gameObject.tag == "cup")
        { 
            score += 50;
        }
        ScoreText.text = $": {score}";
        Statistic();
        StartCoroutine(PaperResp());
        Goal = true; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(PaperResp());
    }

    IEnumerator PaperResp()
    {
        yield return new WaitForSeconds(1.5f);
        if (!Paper.isKinematic)
        {
            PowerBar.SetActive(false);
            power = false;
            Paper.isKinematic = true;
            gameObject.transform.position = first.position;
            JumpKey = true;
            if (!Goal)
            {
                Lives -= 1;
                Heal = 0;
                Combo = 0;
            }
            else
            {
                Combo += 1;
                MultiplierF += (0.1f * Combo);
                Heal += 1;
            }
            Goal = false;
            if (Heal == 3) 
            {
                Lives += 1;
            }
        }
    }
    
    private void Statistic()
    {
        EndScoreText.text = $"Score : {score}";
        Multiplier.text = $"Multiplier : x {MultiplierF}";
        EndGetCoins.text = $"          : {Math.Round(score * MultiplierF)}";
    }

    public void EndClick()
    {
        int SummBalance = Convert.ToInt32(Math.Round(score * MultiplierF));
        if (PlayerPrefs.HasKey("BalanceCount"))
        {
            BalanceCount = PlayerPrefs.GetInt("BalanceCount");
        }
        BalanceCount += SummBalance;
        PlayerPrefs.SetInt("BalanceCount",BalanceCount);
        PlayerPrefs.Save();
        BalanceCount = PlayerPrefs.GetInt("BalanceCount");
        Scene scene = SceneManager.GetActiveScene();
        int MaxScore = 0;
        if (scene.name == "SurvivalScene")
        {
            MaxScore = PlayerPrefs.GetInt("SurvivalScoreRecord");
            if (score > MaxScore)
            {
                PlayerPrefs.SetInt("SurvivalScoreRecord", score);
                PlayerPrefs.Save();
            }
        }else if (scene.name == "NoTImeScene")
        {
            MaxScore = PlayerPrefs.GetInt("NoTImeScoreRecord");
            if (score > MaxScore)
            {
                PlayerPrefs.SetInt("NoTImeScoreRecord", score);
                PlayerPrefs.Save();
            }
        }
        else if (scene.name == "QuestScene")
        {
            MaxScore = PlayerPrefs.GetInt("QuestScoreRecord");
            if (score > MaxScore)
            {
                PlayerPrefs.SetInt("QuestScoreRecord", score);
                PlayerPrefs.Save();
            }
        }
        score = 0;
    }
}
