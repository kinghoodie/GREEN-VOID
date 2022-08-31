using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config" ,fileName = "New Wave Config" )]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private List<GameObject> m_EnemyPrefabs;
    [SerializeField] private Transform m_PathPrefab;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_SpawnInterval;

    public int GetEnemyCount()
    {
        return m_EnemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return m_EnemyPrefabs[index];
    }

    public float GetSpawnInterval()
    {
        return m_SpawnInterval;
    }

    public Transform GetStartingWaypoint()
    {
        return m_PathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in m_PathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float MoveSpeed()
    {
        return m_MoveSpeed;
    }
}
