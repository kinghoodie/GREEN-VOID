using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Health Display")]
    [SerializeField] private Slider m_HealthGuage;
    PlayerHealth m_PlayerHealth;
    [SerializeField] Image m_LifeGuageColor;

    [Header("Pause Menu Items")]
    [SerializeField] GameObject m_PauseMenu;
    [SerializeField] GameObject m_PauseMainMenu;
    [SerializeField] GameObject m_AreYouSureMenu;

    [Header("Score UI Items")]
    [SerializeField] TextMeshProUGUI m_ScoreUI;
    [SerializeField] GameObject m_FlybyText;

    [Header("Animation")]
    [SerializeField] float m_AnimateSpeed;
    [SerializeField] Vector3 m_TargetPosition;

    TextMeshProUGUI m_FlyingText;
    
    void Awake()
    {
        m_PlayerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Start()
    {
        m_HealthGuage.maxValue = m_PlayerHealth.GetMaxHealth;
        m_FlyingText = m_FlybyText.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealth();
        ChangeLifeGuageColor();

        //Display Score
        m_ScoreUI.text = ScoreKeeper.HasInstance ? ScoreKeeper.Instance.Score.ToString() : "--";
    }

    void UpdatePlayerHealth()
    {
        m_HealthGuage.value = m_PlayerHealth.GetHealth;

        if (m_PlayerHealth.GetHealth <= 0)
        {
            m_HealthGuage.value = 0;
        }
    }

    void ChangeLifeGuageColor()
    {
        if (m_PlayerHealth.GetHealth <= 80 && m_PlayerHealth.GetHealth > 40)
        {
            m_LifeGuageColor.color = Color.yellow;
        }

        if (m_PlayerHealth.GetHealth <= 40)
        {
            m_LifeGuageColor.color = Color.red;
        }
    }

    public void PauseMenu()
    {
        m_PauseMenu.SetActive(true);
        m_PauseMainMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnClickResumeButton()
    {
        m_PauseMenu.SetActive(false);
        m_AreYouSureMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickMainMenuButton()
    {
        m_PauseMainMenu.SetActive(false);
        m_AreYouSureMenu.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        GameManager.Instance.ReturnToMenu();
        Time.timeScale = 1;
    }
}

