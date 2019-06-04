using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Attacker[] attackerPrefabs;
    private List<Attacker> spawned = new List<Attacker>();

    public List<Attacker> Spawned
    {
        get
        {
            return spawned;
        }
    }

    // Use this for initialization
    IEnumerator Start () {
        GameTimer gameTimer = FindObjectOfType<GameTimer>();
        while (!gameTimer.TimeExpired)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
	}

    private void SpawnAttacker()
    {
        Attacker attacker = Instantiate(attackerPrefabs[UnityEngine.Random.Range(0, attackerPrefabs.Length)], 
            transform.position, transform.rotation) as Attacker;
        attacker.Spawner = this;
        Spawned.Add(attacker);
    }
}
