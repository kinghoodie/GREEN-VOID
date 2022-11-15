using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject m_Bullet;
    [SerializeField] private float m_MinFireRate = 1f;
    [SerializeField] private float m_MaxFireRate = 1f;
    private bool m_IsShooting = true;
    private Vector2 m_Position;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ReloadTime());
    }

    IEnumerator ReloadTime()
    {
        while (m_IsShooting == true)
        {
            yield return new WaitForSeconds(Random.Range(m_MinFireRate, m_MaxFireRate));
            m_Position = transform.position;
            Instantiate(m_Bullet, m_Position, Quaternion.identity);
        }
    }
}
