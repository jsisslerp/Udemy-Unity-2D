using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {
    [SerializeField] private int lives = 5;
    private Text livesText;

    public int Lives
    {
        get
        {
            return lives;
        }

        set
        {
            lives = value;
            livesText.text = lives.ToString();
            if (lives <= 0)
            {
                FindObjectOfType<BuildOrderSceneLoader>().LoadLoseScene();
            }
        }
    }

    private void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = lives.ToString();
    }
}
