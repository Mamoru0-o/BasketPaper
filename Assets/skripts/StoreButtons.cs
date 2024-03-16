using TMPro;
using UnityEngine;

public class StoreButtons : MoveCameraMenu
{
    [SerializeField] private GameObject BallSkins;
    [SerializeField] private TMPro.TMP_Text BallText;
    [SerializeField] private GameObject BinSkins;
    [SerializeField] private TMPro.TMP_Text BinText;

    private void Start()
    {
        BallSkins.SetActive(false);
        BinSkins.SetActive(true);
        BinText.GetComponent<TextMeshProUGUI>().color = Color.green;
        BallText.GetComponent<TextMeshProUGUI>().color = Color.black;
    }
    public void OnClick()
    {
        if (gameObject.name == "BinText")
        {
            Move = true;
            RotatePoint.transform.localPosition = new Vector3(0, 0, 0);
            BallSkins.SetActive(false);
            BinSkins.SetActive(true);
            BinText.GetComponent<TextMeshProUGUI>().color = Color.green;
            BallText.GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        else
        {
            RotatePoint.transform.localEulerAngles = new Vector3(0, 0, 0);
            Move = false;
            RotatePoint.transform.localPosition = new Vector3(-4f, -12.5f, 3f);
            BallSkins.SetActive(true);
            BinSkins.SetActive(false);
            BallText.GetComponent<TextMeshProUGUI>().color = Color.green;
            BinText.GetComponent<TextMeshProUGUI>().color = Color.black;
        }

    }
}
