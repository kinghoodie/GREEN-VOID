using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int m_Health;
    [SerializeField] private int m_MaxHealth;
    [SerializeField] private ParticleSystem m_DeathSpark;

    private CameraShake m_Camera;
    private SpriteRenderer m_Sprite;

    //Getting the Health Value
    public int GetHealth
    {
        get { return m_Health; }
    }

    public int GetMaxHealth
    {
        get { return m_MaxHealth; }
    }

    private void Awake()
    {
        m_Camera = FindObjectOfType<CameraShake>();
        m_Sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Take Damage
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            StartCoroutine(ShowDamageEffect());
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        } 
    }

    private void TakeDamage(int damage)
    {
        m_Health -= damage;
        if (m_Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(m_DeathSpark, transform.position, Quaternion.identity);
        m_Camera.Play();
        GameManager.Instance.PlayerDead();
    }

    private IEnumerator ShowDamageEffect()
    {
        m_Sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        m_Sprite.color = Color.white;
    }

    //Health Pickup
    public void GainHealth(int healthPlus)
    {
        if (m_Health > m_MaxHealth)
        {
            m_Health = m_MaxHealth;
        }
        else if (m_Health < m_MaxHealth)
        {
            m_Health += healthPlus;
        }
    }
}
