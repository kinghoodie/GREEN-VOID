using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMoving : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private int m_LifeSpan;
    private Rigidbody2D m_Rigid;
    private Vector2 m_StartPos;
    private PlayerHealth m_Target;
    private Vector2 m_TargetPos;

    private void Start()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
        m_Target = FindObjectOfType<PlayerHealth>();
        if (m_Target == null)
        {
            Destroy(gameObject);
            return;
        }

        m_StartPos = transform.position;
        m_TargetPos = m_Target.transform.position;
    }

    // Update is called once per frame
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
        var bulletDir = (m_TargetPos - m_StartPos).normalized;
        m_Rigid.velocity = bulletDir * m_Speed;
    }
}
