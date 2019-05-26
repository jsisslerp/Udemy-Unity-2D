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

        set
        {
            score = value;
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
