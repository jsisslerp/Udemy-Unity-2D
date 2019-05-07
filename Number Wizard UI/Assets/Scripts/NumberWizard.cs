using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int max;
    [SerializeField] private bool random;
    [SerializeField] TextMeshProUGUI guessText;
    private int guess;

    private void proposeGuess()
    {
        if (random)
        {
            guess = Random.Range(min, max + 1);
        }
        else
        {
            guess = (min + max) / 2;
        }
        guessText.SetText(guess.ToString());
    }

    public void Start()
    {
        proposeGuess();
    }

    public void OnPressHigher()
    {
        min = guess + 1;
        proposeGuess();
    }

    public void OnPressLower()
    {
        max = guess - 1;
        proposeGuess();
    }
}
