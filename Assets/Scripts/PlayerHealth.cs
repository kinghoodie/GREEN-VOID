using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int m_Health;
    [SerializeField] private int m_MaxHealth;
    [SerializeField] private ParticleSystem m_DeathSpark;

    private CameraShake m_CameraShake;
    private GameManager m_GameManager;

    private SpriteRenderer m_Sprite;

    //Getting the Health Value
    public int GetHealth
    {
        get { return m_Health; }
    }

    private void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        m_CameraShake = FindObjectOfType<CameraShake>();
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
        m_CameraShake.Play();
        m_GameManager.PlayerDead();
    }

    private IEnumerator ShowDamageEffect()
    {
        m_Sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        m_Sprite.color = Color.white;
    }
}
