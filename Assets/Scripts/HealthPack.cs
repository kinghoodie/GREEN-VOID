using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private PlayerHealth m_PlayerHealth;
    [SerializeField] private int m_HealthGain;
    [SerializeField] private ParticleSystem m_CollectedEffect;
    [SerializeField] private Vector3 m_Rotation;
    [SerializeField] private float m_RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        Spin();
        Fall();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_PlayerHealth.GainHealth(m_HealthGain);
            Instantiate(m_CollectedEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Spin()
    {
        transform.Rotate(m_RotationSpeed * m_Rotation * Time.deltaTime);
        Destroy(this.gameObject, 20);
    }

    void Fall()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime);
    }
}
