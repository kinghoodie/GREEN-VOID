using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private int m_Health;
    [SerializeField] private ParticleSystem m_DeathSpark;

    [SerializeField] private int m_ScoreValue = 100;
    private ScoreKeeper m_ScoreKeeper;

    private SpriteRenderer m_Sprite;

    private void Start()
    {
        m_ScoreKeeper = FindObjectOfType<ScoreKeeper>();
        m_Sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Die();
        }

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
        m_ScoreKeeper.ScoreModifier(m_ScoreValue);
        Destroy(gameObject);
        Instantiate(m_DeathSpark, transform.position, Quaternion.identity);
    }

    private IEnumerator ShowDamageEffect()
    {
        var originalColor = m_Sprite.color;
        m_Sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        m_Sprite.color = originalColor;
    }
}
