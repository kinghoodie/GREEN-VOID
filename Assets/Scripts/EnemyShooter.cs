using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject m_Bullet;
    [SerializeField] private float m_FireRate = 1f;
    private bool m_IsShooting = true;
    private Vector2 m_Position;

    // Update is called once per frame
    void Start()
    {
        IsShooting();
    }

    private void IsShooting()
    {
        StartCoroutine(ReloadTime());
    }

    IEnumerator ReloadTime()
    {
        while (m_IsShooting == true)
        {
            yield return new WaitForSeconds(m_FireRate);
            m_Position = transform.position;
            Instantiate(m_Bullet, m_Position, Quaternion.identity);
        }
    }
}
