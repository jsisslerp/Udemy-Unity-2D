using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int cost = 100;
    private StarDisplay starDisplay;

    public int Cost
    {
        get
        {
            return cost;
        }

        set
        {
            cost = value;
        }
    }

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int stars)
    {
        starDisplay.Stars += stars;
    }

    private void OnDestroy()
    {
        DefenderSpawner.Occupied.Remove(transform.position);
    }
}
