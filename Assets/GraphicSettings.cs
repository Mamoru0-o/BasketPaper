using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GraphicSettings : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Dropdown ScreenSize;
    Resolution[] resolutions;
    [SerializeField] private TMPro.TMP_Dropdown Shadows;
    [SerializeField] private TMPro.TMP_Dropdown TextureQuality;
    [SerializeField] private TMPro.TMP_Dropdown AntyAlising;
    [SerializeField] private Toggle VSyng;
    void Start()
    {
        ScreenSize.ClearOptions();
        List<string> SizeOptions = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + Math.Round(resolutions[i].refreshRateRatio.value) + "Hz";
            SizeOptions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        ScreenSize.AddOptions(SizeOptions);
        ScreenSize.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }


    public void SetScreenSize(int resolutionIndex)
    {
        Resolution resolution = resolutions[ScreenSize.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ScreenSize", ScreenSize.value);
        PlayerPrefs.Save();
    }


    public void SetShadowQuality()
    {
        switch (Shadows.value)
        {
            case 1: QualitySettings.shadowResolution = ShadowResolution.Low; break;
            case 2: QualitySettings.shadowResolution = ShadowResolution.Medium; break;
            case 3: QualitySettings.shadowResolution = ShadowResolution.High; break;
            case 4: QualitySettings.shadowResolution = ShadowResolution.VeryHigh; break;
        }
        PlayerPrefs.SetInt("ShadowQuality", Shadows.value);
        PlayerPrefs.Save();
    }


    public void SetTextureQuality()
    {

        QualitySettings.globalTextureMipmapLimit = TextureQuality.value - 1;
        PlayerPrefs.SetInt("TextureQuality", TextureQuality.value);
        PlayerPrefs.Save();
    }


    public void SetAntiAlising()
    { 
        QualitySettings.antiAliasing = AntyAlising.value - 1;
        PlayerPrefs.SetInt("AntyAlising", AntyAlising.value);
        PlayerPrefs.Save();
    }


    public void SetVSyng()
    {
        QualitySettings.vSyncCount = Convert.ToInt32(VSyng.isOn);
        PlayerPrefs.SetInt("vSync", Convert.ToInt32(VSyng.isOn));
        PlayerPrefs.Save();
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ScreenSize"))
        {
           ScreenSize.value = PlayerPrefs.GetInt("ScreenSize");
        }
        else
        {
            ScreenSize.value = currentResolutionIndex;
        }

        if (PlayerPrefs.HasKey("TextureQuality"))
        {
            TextureQuality.value = PlayerPrefs.GetInt("TextureQuality");
        }
        else
        {
            TextureQuality.value = 1;
        }

        if (PlayerPrefs.HasKey("AntyAlising"))
        {
            AntyAlising.value = PlayerPrefs.GetInt("AntyAlising");
        }
        else
        {
            AntyAlising.value = 4;
        }

        if (PlayerPrefs.HasKey("ShadowQuality"))
        {
            Shadows.value = PlayerPrefs.GetInt("ShadowQuality");
        }
        else
        {
            Shadows.value = 4;
        }

        if (PlayerPrefs.HasKey("vSync"))
        {
            VSyng.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("vSync"));
        }
        else
        {
            VSyng.isOn = false;
        }
    }



}
