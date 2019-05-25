using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    private int score = 0;

    public int Score
    {
        get
        {
            return score;
        }
    }

    public void AddToScore(int addition)
    {
        score += addition;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


}
