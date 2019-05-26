using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : PersistentGameObjectSingleton<GameSession>
{
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
}
