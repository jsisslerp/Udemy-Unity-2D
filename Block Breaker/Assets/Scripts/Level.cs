using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField] GameObject blockContainer;
    [SerializeField] SceneLoader sceneLoader;
	
	// Update is called once per frame
	void Update () {
        if (blockContainer.transform.childCount == 0)
        {
            sceneLoader.LoadNextScene();
        }
	}
}
