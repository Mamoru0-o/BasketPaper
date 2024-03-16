using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public void OpenSettings()
    {
           gameObject.transform.localPosition = new Vector3(-200, -383, 0);
    }

    public void CloseSettings()
    {
        gameObject.transform.localPosition = new Vector3(658, -383, 0);
    }
}
    