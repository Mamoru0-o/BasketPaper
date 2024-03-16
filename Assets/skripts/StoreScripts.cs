using UnityEngine;

public class StoreScripts : MonoBehaviour
{
    [SerializeField] private GameObject GameName;
    [SerializeField] private GameObject MenuButtons;
    [SerializeField] private GameObject MoneyWindow;

    [SerializeField] private GameObject StoreMenu;

    [SerializeField] private TMPro.TMP_Text MoneyWindowText;

    public void OnStoreClick()
    {
        GameName.SetActive(false);
        MenuButtons.SetActive(false);
        MoneyWindow.transform.localPosition += new Vector3(-0.9f, 0.4f, 0);
        StoreMenu.SetActive(true);
    }

    public void OnBackClick()
    {
        GameName.SetActive(true);
        MenuButtons.SetActive(true);
        MoneyWindow.transform.localPosition -= new Vector3(-0.9f, 0.4f, 0);
        StoreMenu.SetActive(false);
    }

}
