using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int max;
    [SerializeField] TextMeshProUGUI guessText;
    private int guess;

    private void proposeGuess()
    {
        guess = (min + max) / 2;
        guessText.SetText(guess.ToString());
    }

    public void Start()
    {
        guess = (min + max) / 2;
        max = max + 1;
        guessText.SetText(guess.ToString());
    }

    public void OnPressHigher()
    {
        min = guess;
        proposeGuess();
    }

    public void OnPressLower()
    {
        max = guess;
        proposeGuess();
    }
}
