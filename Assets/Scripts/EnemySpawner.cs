using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        if (scoreKeeper.GetScore() > 500)
        {
            isLooping = false;
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    if (isLooping)
                    {
                        Instantiate(currentWave.GetEnemyPrefab(i),
                                    currentWave.GetStartingWaypoint().position,
                                    Quaternion.Euler(0, 0, 180),
                                    transform);
                        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                    }
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
            
        }
        while(isLooping);
    }
}
