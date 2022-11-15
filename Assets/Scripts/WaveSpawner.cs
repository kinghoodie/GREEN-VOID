using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> m_WaveConfigs;
    [SerializeField] private float m_WaveInterval;
    WaveConfig currentWave;
    [SerializeField] private bool m_IsLooping;

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfig wave in m_WaveConfigs)
            {
                currentWave = wave;
                int index = 0;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(index), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetSpawnInterval());
                    index++;
                }
                yield return new WaitForSeconds(m_WaveInterval);
            }
        }
        while (m_IsLooping);
        
        
    }
}
