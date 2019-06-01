using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int cost = 100;

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

    public void AddStars(int stars)
    {
        FindObjectOfType<StarDisplay>().Stars += stars;
    }

    private void OnDestroy()
    {
        DefenderSpawner.Occupied.Remove(transform.position);
    }
}
