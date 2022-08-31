using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    public static bool HasInstance => Instance != null;

    private int m_KillScore;
    private int m_Score;

    private float nextScoreTime;
    private bool m_IsAlive;

    public int Score
    {
        get { return m_Score + m_KillScore; }
    }

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            GameManager.OnGameStart += ResetScore;
            GameManager.OnGameOver += OnGameOver;
        }
    }

    public void ScoreModifier (int value)
    {
        m_KillScore += value;
    }

    public void ResetScore()
    {
        m_Score = 0;
        m_IsAlive = true;
    }

    private void OnGameOver()
    {
        m_IsAlive = false;
    }

    void Update()
    {
        //int distanceTraveled = m_Distance.GetDistance;
        //m_Score = distanceTraveled + m_KillScore;
        if (m_IsAlive)
        {
            UpdateScoreByTime();
        }
        else
        {
            return;
        }
    }

    private void UpdateScoreByTime()
    {
        if(Time.time > nextScoreTime)
        {
            m_Score += 10;
            nextScoreTime = Time.time + 1;
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameStart -= ResetScore;
        GameManager.OnGameOver -= OnGameOver;
    }
}
