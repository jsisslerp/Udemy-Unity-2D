using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
    [SerializeField] private GameObject winLabel;
    [SerializeField] private float nextSceneDelay = 3f;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		if (Attacker.NumAttackers == 0 && FindObjectOfType<GameTimer>().TimeExpired)
        {
            StartCoroutine(HandleWinCondition());
        }
	}

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(nextSceneDelay);
        FindObjectOfType<BuildOrderSceneLoader>().LoadNextScene();
    }
}
