using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Attacker attackerPrefab;
    private List<Attacker> spawned = new List<Attacker>();

    private bool spawn = true;

    public List<Attacker> Spawned
    {
        get
        {
            return spawned;
        }
    }

    // Use this for initialization
    IEnumerator Start () {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
	}

    private void SpawnAttacker()
    {
        Attacker attacker = Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
        attacker.Spawner = this;
        Spawned.Add(attacker);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
