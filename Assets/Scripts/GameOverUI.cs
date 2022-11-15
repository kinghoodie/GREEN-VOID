using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_ScoreUI;
    [SerializeField] GameObject m_MainHolder;

    // Update is called once per frame
    void Start()
    {
        GameManager.OnGameOver += OnPlayerDie;
    }

    private void OnDestroy()
    {
        GameManager.OnGameOver -= OnPlayerDie;
    }

    private void OnPlayerDie()
    {
        GameManager.OnGameOver -= OnPlayerDie;

        //Display Score
        m_ScoreUI.text = ScoreKeeper.HasInstance ? ScoreKeeper.Instance.Score.ToString() : "--";
        m_MainHolder.SetActive(true);
    }

    public void OnRetryButtonClicked()
    {
        GameManager.Instance.RestartGame();
        m_MainHolder.SetActive(false);
    }

    public void OnQuitButtonClicked()
    {
        GameManager.Instance.ReturnToMenu();
        Time.timeScale = 1;
        m_MainHolder.SetActive(false);
    }
}