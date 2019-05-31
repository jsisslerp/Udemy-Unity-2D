using System;
using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Attacker attackerPrefab;

    private bool spawn = true;

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
        attacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
