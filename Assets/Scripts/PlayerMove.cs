using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //Player input variables
    private Vector2 m_RawInput;
    private int m_BulletSwitch;
    private Shooter m_Shooter;
    [SerializeField] private float m_Speed = 0f;

    //Player clamping variables
    private Vector2 m_MinBound;
    private Vector2 m_MaxBound;

    //Creating Padding
    [Space]
    [Header("Padding")]
    [SerializeField] private float m_PaddingTop;
    [SerializeField] private float m_PaddingBottom;
    [SerializeField] private float m_PaddingLeft;
    [SerializeField] private float m_PaddingRight;

    private void Awake()
    {
        m_Shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        SetBounds();
    }

    void Update()
    {
        Move();
    }

    //User-defined Methods
    private void Move()
    {
        Vector3 delta = m_RawInput * m_Speed * Time.deltaTime;
        Vector2 playerPos = new Vector2();

        //Clamping the Player
        playerPos.x = Mathf.Clamp(transform.position.x + delta.x, m_MinBound.x + m_PaddingLeft, m_MaxBound.x - m_PaddingRight);
        playerPos.y = Mathf.Clamp(transform.position.y + delta.y, m_MinBound.y + m_PaddingBottom, m_MaxBound.y - m_PaddingTop);

        transform.position = playerPos;
    }

    private void SetBounds()
    {
        Camera cam = Camera.main;
        m_MinBound = cam.ViewportToWorldPoint(new Vector2(0,0));
        m_MaxBound = cam.ViewportToWorldPoint(new Vector2(1,1));
    }

    //Input Functions
    void OnMove (InputValue value)
    {
        m_RawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (m_Shooter != null)
        {
            m_Shooter.isFiring = value.isPressed;
        }
    }
}
