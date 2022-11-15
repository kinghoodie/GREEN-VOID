using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static event System.Action OnGameStart;
    public static event System.Action OnGameOver;

    private PlayerMove Player = null;

    public bool m_GameHasEnded = false;
    [SerializeField] private int m_DelayTime;

    private void Awake()
    {
        ManageSingleton();
    }

    private void Start()
    {
        OnGameStart?.Invoke();
    }

    private void ManageSingleton()
    {
        if(Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void EndGame()
    {
        OnGameOver?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        m_GameHasEnded = false;
        OnGameStart?.Invoke();
    }

    public void PlayerDead()
    {
        if (!m_GameHasEnded)
        {
            m_GameHasEnded = true;
            Invoke("EndGame", m_DelayTime);
            Player = null;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Start");
        m_GameHasEnded = true;
    }

    public void RegisterPlayer(PlayerMove playerMove)
    {
        Player = playerMove;
    }

    public Vector2 GetPlayerPosition()
    {
        if(Player != null)
        {
             return Player.transform.position;
        }
        else return Vector2.zero;
    }
}
