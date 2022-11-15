using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    WaveSpawner enemySpawner;
    private WaveConfig m_waveConfig;
    private List<Transform> m_Waypoints;
    private int m_WaypointIndex = 0;

    void Awake()
    {
       // m_waveConfig = FindObjectOfType<WaveConfig>();
        enemySpawner = FindObjectOfType<WaveSpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_waveConfig = enemySpawner.GetCurrentWave();
        m_Waypoints = m_waveConfig.GetWaypoints();
        transform.position = m_Waypoints[m_WaypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (m_WaypointIndex < m_Waypoints.Count)
        {
            float delta = m_waveConfig.MoveSpeed() * Time.deltaTime;
            Vector3 targetPosition = m_Waypoints[m_WaypointIndex].position;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if (transform.position == targetPosition)
            {
                m_WaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
