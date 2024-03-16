using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StatisticSave : GoalScore
{
    [SerializeField] private TMPro.TMP_Text SurvivalScoreRecord;
    [SerializeField] private TMPro.TMP_Text NoTimeScoreRecord;
    [SerializeField] private TMPro.TMP_Text QuestScoreRecord;
    void Update()
    {
        SurvivalScoreRecord.text = $"Survival: {PlayerPrefs.GetInt("SurvivalScoreRecord")}";
        NoTimeScoreRecord.text = $"NoTime: {PlayerPrefs.GetInt("NoTImeScoreRecord")}";
        QuestScoreRecord.text = $"Quest: {PlayerPrefs.GetInt("QuestScoreRecord")}";
    }

}
