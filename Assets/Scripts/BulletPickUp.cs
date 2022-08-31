using UnityEngine;

public class BulletPickUp : MonoBehaviour
{
    private Shooter m_GunType;
    [SerializeField] private ParticleSystem m_CollectedEffect;
    [SerializeField] private Vector3 m_Rotation;
    [SerializeField] private float m_RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_GunType = FindObjectOfType<Shooter>();
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
            m_GunType.SwitchBullet();
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
