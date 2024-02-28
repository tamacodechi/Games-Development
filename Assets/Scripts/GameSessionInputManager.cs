using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionInputManager : MonoBehaviour
{
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // Opens Main Menu
            // Restricts control to the character
            // Pauses scene(?)

            //Main menu controls:
            // Application quit
            // Sound volume
        }

        if (Input.GetKey(KeyCode.R))
        {
            //Relaods the scene
            //IN a future implementation can reset the position of the car (if it flips)
            ReloadScene();

        }

        if (timer.GetTimeRemaining() <= Mathf.Epsilon)
        {
            LoadNextScene();
        }
    }


    void LoadNextScene()
    {
        //This doesn't work as expected-  we would need to load scenes additively (which wouldn't be awful)
        //For now, a naive impelmentation is to intersperse a shop scene between levels in build settings.
        //
        //As a future implementation, we should load scenes additively based on progression.
        //Scene postRoundShopScene = SceneManager.GetSceneByName("Scenes/PostRoundShop");
        //Debug.Log(postRoundShopScene.name);

        int numScenes = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        //Sends the user to the base scene when there are no more scenes to load, otherwise
        // load the next scene
        if (nextSceneIndex == numScenes)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);


    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
