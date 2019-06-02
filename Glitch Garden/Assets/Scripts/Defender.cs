using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int cost = 100;
    private StarDisplay starDisplay;

    private AttackerSpawner GetAttackerSpawner()
    {
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            if (Mathf.RoundToInt(spawner.transform.position.y) == Mathf.RoundToInt(transform.position.y))
            {
                return spawner;
            }
        }
        return null;
    }

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
        GetComponent<Animator>().SetBool("IsAttacking", false);
    }

    public void AddStars(int stars)
    {
        starDisplay.Stars += stars;
    }

    private void OnDestroy()
    {
        DefenderSpawner.Occupied.Remove(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        SetIsAttacking();
    }

    private void SetIsAttacking()
    {
        AttackerSpawner spawner = GetAttackerSpawner();
        if (spawner && spawner.Spawned.Count > 0)
        {
            GetComponent<Animator>().SetBool("IsAttacking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }
}
