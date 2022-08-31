using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Health Display")]
    [SerializeField] private Slider m_HealthGuage;
    PlayerHealth m_PlayerHealth;

    [SerializeField] TextMeshProUGUI m_ScoreUI;
    
    void Awake()
    {
        m_PlayerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Start()
    {
        m_HealthGuage.maxValue = m_PlayerHealth.GetHealth;
    }

    // Update is called once per frame
    void Update()
    {
        m_HealthGuage.value = m_PlayerHealth.GetHealth;

        if (m_PlayerHealth.GetHealth <= 0)
        {
            m_HealthGuage.value = 0;
        }
        //Display Score
        m_ScoreUI.text = ScoreKeeper.HasInstance ? ScoreKeeper.Instance.Score.ToString() : "--";
    }
}
