using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_LifeSpan;

    private void Start()
    {
        FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        StraightLazer();
    }

    void FadeOut()
    {
        Destroy(gameObject, m_LifeSpan);
    }

    void StraightLazer()
    {
        float speed = m_Speed * Time.deltaTime;
        transform.Translate(0, speed, 0);
    }
}
