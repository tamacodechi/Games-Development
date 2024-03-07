using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle fullscreenToggle;
    bool runOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        if(!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 1);
            Screen.fullScreen = true;
        }
        else
        {
            bool isFullScreen = Screen.fullScreenMode != FullScreenMode.Windowed;

            Screen.fullScreen = isFullScreen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!runOnce)
        {
            float volume = PlayerPrefs.GetFloat("volume");
            AudioListener.volume = volume;
            volumeSlider.value = volume;

            fullscreenToggle.isOn = Screen.fullScreenMode != FullScreenMode.Windowed;

            runOnce = true;
        }
    }

    public void ChangeVolume()
    {
        if(runOnce)
        {
            AudioListener.volume = volumeSlider.value;
            PlayerPrefs.SetFloat("volume", volumeSlider.value);
        }
    }

    public void ToggleFullscreen()
    {
        if(!runOnce) return;

        Screen.fullScreen = !Screen.fullScreen;

        if (Screen.fullScreenMode == FullScreenMode.Windowed)
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
    }
}
