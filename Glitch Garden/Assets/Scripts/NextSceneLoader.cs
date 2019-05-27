using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneLoader : MonoBehaviour {
    [SerializeField] private float nextSceneDelay = 3f;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(nextSceneDelay);
        FindObjectOfType<BuildOrderSceneLoader>().LoadNextScene();
	}
}
