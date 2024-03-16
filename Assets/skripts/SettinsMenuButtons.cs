using TMPro;
using UnityEngine;


public class SettinsMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject StatisticCanvas;
    [SerializeField] private GameObject GraphicCanvas;
    [SerializeField] private GameObject SoundCanvas;

    [SerializeField] private TMPro.TMP_Text StatisticText;
    [SerializeField] private TMPro.TMP_Text GraphicText;
    [SerializeField] private TMPro.TMP_Text SoundText;

    void Start()
    {
        StatisticCanvas.SetActive(true);
        GraphicCanvas.SetActive(false);
        SoundCanvas.SetActive(false);
        StatisticText.GetComponent<TextMeshProUGUI>().color = Color.green;
        GraphicText.GetComponent<TextMeshProUGUI>().color = Color.black;
        SoundText.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void OnSettingsButtonClick()
    {
        if (gameObject.name == "StatisticsText")
        {
            StatisticCanvas.SetActive(true);
            GraphicCanvas.SetActive(false);
            SoundCanvas.SetActive(false);
            StatisticText.GetComponent<TextMeshProUGUI>().color = Color.green;
            GraphicText.GetComponent<TextMeshProUGUI>().color = Color.black;
            SoundText.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        else if (gameObject.name == "GraphicText")
        {
            StatisticCanvas.SetActive(false);
            GraphicCanvas.SetActive(true);
            SoundCanvas.SetActive(false);
            StatisticText.GetComponent<TextMeshProUGUI>().color = Color.black;
            GraphicText.GetComponent<TextMeshProUGUI>().color = Color.green;
            SoundText.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        else 
        {
            StatisticCanvas.SetActive(false);
            GraphicCanvas.SetActive(false);
            SoundCanvas.SetActive(true);
            StatisticText.GetComponent<TextMeshProUGUI>().color = Color.black;
            GraphicText.GetComponent<TextMeshProUGUI>().color = Color.black;
            SoundText.GetComponent<TextMeshProUGUI>().color = Color.green;
        }

    }
}
