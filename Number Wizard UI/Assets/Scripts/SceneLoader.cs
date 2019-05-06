using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public void LoadNextScene()
    {
        int currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        if (currentActiveScene + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentActiveScene + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
