using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : GoalScore
{
    [SerializeField] private TMPro.TMP_Text BalanceT;

    private void Start()
    {
        BalanceCount = PlayerPrefs.GetInt("BalanceCount");
    }
    void Update()
    {
        BalanceT.text = $" : {BalanceCount}";
    }
}
