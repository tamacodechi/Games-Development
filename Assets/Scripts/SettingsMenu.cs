using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] Dropdown resolutionsDropdown;
    [SerializeField] Dropdown graphicQualityDropdown;

    private List<Resolution> filteredResolutions;
    private int resolutionDropdownIndex;

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
            Screen.fullScreen = Screen.fullScreenMode != FullScreenMode.Windowed;
        }

        if(!PlayerPrefs.HasKey("graphicQuality"))
        {
            PlayerPrefs.SetInt("graphicQuality", 4);
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

            PopulateResolutions();
            resolutionsDropdown.value = resolutionDropdownIndex;

            int graphicQuality = PlayerPrefs.GetInt("graphicQuality");
            graphicQualityDropdown.value = graphicQuality;

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

    public void SetGraphicQuality()
    {
        QualitySettings.SetQualityLevel(graphicQualityDropdown.value, true);

        PlayerPrefs.SetInt("graphicQuality", graphicQualityDropdown.value);
    }

    public void SetResolution()
    {
        Resolution resolution = filteredResolutions[resolutionsDropdown.value];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    void PopulateResolutions()
    {
        Resolution[] resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        foreach(Resolution resolution in resolutions)
        {
            // There is a refreshRate mismatch when using a game build (ie: 60Hz -> 59Hz), so we reduce it by 1 in these cases
            // We also only wanna add resolutions that match the user's screen refresh rate to avoid duplicate entries
            float screenRefreshRate = Screen.currentResolution.refreshRate;

            if(resolution.refreshRate == (Application.isEditor ? screenRefreshRate : screenRefreshRate - 1))
            {
                filteredResolutions.Add(resolution);
            }
        }

        List<string> formattedResolutions = new List<string>();
        foreach(Resolution filteredResolution in filteredResolutions)
        {
            // Format user-readable resolution and add it to the formattedResolutions list
            string resolutionOption = filteredResolution.width + "x" + filteredResolution.height;
            formattedResolutions.Add(resolutionOption);

            // If the resolution matches the user's screen, we save it so we can update the dropdown's starting value
            if(filteredResolution.width == Screen.width && filteredResolution.height == Screen.height)
            {
                resolutionDropdownIndex = filteredResolutions.IndexOf(filteredResolution);
            }
        }

        resolutionsDropdown.AddOptions(formattedResolutions);
    }
}
