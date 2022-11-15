using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMoving : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_LifeSpan;

    Vector3 m_Target;
    Vector2 m_Direction;

    private void Awake()
    {
        m_Target = GameManager.Instance.GetPlayerPosition();
    }

    private void Start()
    {
        m_Direction = (m_Target - transform.position).normalized * m_Speed;
    }


    void Update()
    {
        StraightLazer();
        FadeOut();
    }

    void FadeOut()
    {
        Destroy(gameObject, m_LifeSpan);
    }

    void StraightLazer()
    {
        transform.Translate(m_Direction * Time.deltaTime);
    }
}
