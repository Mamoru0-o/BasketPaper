using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeMusic : MonoBehaviour
{
    [SerializeField] private AudioSource BackgroundMusic;
    private GameObject SliderBar;
    private Slider VolumeBar;

    private void Start()
    {
        SliderBar = GameObject.Find("Slider");
        try 
        {
            VolumeBar = SliderBar.GetComponent<Slider>();
            if (PlayerPrefs.HasKey("Volume"))
            {
                VolumeBar.value = PlayerPrefs.GetFloat("Volume");
            }
        } catch { }
    }
    void Update()
    {
        BackgroundMusic.volume = PlayerPrefs.GetFloat("Volume");
    }

    public void ONValueChanged()
    {
        SliderBar = GameObject.Find("Slider");
        VolumeBar = SliderBar.GetComponent<Slider>();
        PlayerPrefs.SetFloat("Volume", VolumeBar.value);
        PlayerPrefs.Save();
    }
}
