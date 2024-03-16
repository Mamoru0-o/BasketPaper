using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImer : MonoBehaviour
{
    [SerializeField] private GameObject EndMenu;
    [SerializeField] private TMPro.TMP_Text TimeText;
    private int Minuts;
    private int Seconds;

    [SerializeField] private GameObject PauseMenu;
    void Start()
    {
        EndMenu.SetActive(false);
        Minuts = 3;
        Seconds = 0;
        StartCoroutine(Timer());
    }

    [System.Obsolete]
    void Update()
    {
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
        if (Seconds >= 60) {
            Minuts += 1;
            Seconds -= 60;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Seconds += 5;
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
