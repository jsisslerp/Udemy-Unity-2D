using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private bool looping = false;

	// Use this for initialization
    IEnumerator Start()
    {
        do
        {
            yield return SpawnAllWaves();
            new WaitForSeconds(UnityEngine.Random.Range(0.25f, 1f));
        } while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig waveConfig in waveConfigs)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++)
        {
            GameObject enemy = Instantiate(waveConfig.EnemyPrefab, waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyPathing>().WaveConfig = waveConfig;
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }
}
