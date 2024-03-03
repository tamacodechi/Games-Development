using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    bool runOnce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (runOnce == false)
        {
            Button backButton = GameObject.Find("Back Button").GetComponent<Button>();

            backButton.Select();

            runOnce = true;
        }
    }

    void OnEnable()
    {
        runOnce = false;
    }
}
