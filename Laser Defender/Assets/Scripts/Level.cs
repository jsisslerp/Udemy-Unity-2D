using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField] private float delayInSeconds = 1f;
    [SerializeField] private string gameOverSceneName = "Game Over";
    [SerializeField] private string gameSceneName = "Game";
    [SerializeField] private string startSceneName = "Start";

    public void LoadGameOver()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(gameOverSceneName);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(startSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
