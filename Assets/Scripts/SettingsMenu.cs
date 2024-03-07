using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    bool runOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
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
}
