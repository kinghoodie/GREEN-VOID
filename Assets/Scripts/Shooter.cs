using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject m_LazerEffect;
    [SerializeField] private GameObject[] m_BulletPrefabs;
    private int bulletIndex;
    [SerializeField] private float m_FireRate = 5f;
    private float m_NextShootTime = 0.0f;

    [SerializeField] private bool isFiring;

    private void Start()
    {
        bulletIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        UpdateShooting();
    }

    private void UpdateShooting()
    {
        if (isFiring)
        {
            if(Time.time > m_NextShootTime)
            {
                //Shoot
                var bulletPosition = new Vector2 (transform.position.x, transform.position.y + 0.5f);
                Instantiate(m_BulletPrefabs[bulletIndex], bulletPosition, Quaternion.identity);
                Instantiate(m_LazerEffect, bulletPosition, Quaternion.identity);
                m_NextShootTime = Time.time + m_FireRate;
            }
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            isFiring = true;
        }
    }

    public void SwitchBullet()
    {
        if (bulletIndex < m_BulletPrefabs.Length - 1)
        {
            bulletIndex++;
        }
    }
}
