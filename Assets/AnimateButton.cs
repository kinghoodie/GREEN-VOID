using UnityEngine;

public class AnimateButton : MonoBehaviour
{
    [SerializeField] private Vector2 m_EndPos;
    private Rigidbody2D m_Rigid;
    [SerializeField] private float m_Freq;
    [SerializeField] private float m_Amplitude;
    [SerializeField] private float m_Speed;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //MovingTowards();
        ZigZagMove();
    }

    void MovingTowards()
    {
        float speed = m_Freq * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, m_EndPos, speed);

        if (transform.position.y == m_EndPos.y)
        {
            Debug.Log("I'm Finally Here");
            gameObject.SetActive(false);
        }
    }

    void ZigZagMove()
    {
        float xMove = Mathf.Sin(m_Freq * Time.time) * m_Amplitude;
        float yMove = m_Speed * Time.deltaTime;

        m_Rigid.velocity = new Vector2(xMove, yMove);

    }
}
