using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeshButtonColor : MonoBehaviour
{
    private Color Color = Color.green;
    private Vector3 StartScale;

    private void Start()
    {
        StartScale = gameObject.transform.localScale;
    }
    public void ButtonEnter()
    {
        if (gameObject.name == "StoreText" || gameObject.name == "NoTimeText" || gameObject.name == "RestartText" || gameObject.name == "BinText")
        {
            Color = Color.yellow;
        }
        else if (gameObject.name == "ExitText" || gameObject.name == "SurvivalText" || gameObject.name == "BackText" || gameObject.name == "FinishText")
        {
            Color = Color.red;
        }
        gameObject.GetComponent<TextMeshProUGUI>().color = Color; 
        gameObject.transform.localScale += new UnityEngine.Vector3(0.1f, 0.1f, 0);
    }
    public void ButtonExit()
    {
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.black;
        gameObject.transform.localScale -= new UnityEngine.Vector3(0.1f, 0.1f, 0);
    }
    public void ButtonClickColor()
    {
        gameObject.GetComponent<TextMeshProUGUI>().color = Color.black;
         gameObject.transform.localScale = StartScale;
    }
    }
