using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    //Player input variables
    [SerializeField] private float m_Speed = 0f;
    [SerializeField] private float m_MouseSpeed = 0f;
    [SerializeField] Rigidbody2D m_Rigid;

    Movement m_Movement;

    //Creating Padding
    [Space]
    [Header("Padding")]
    [SerializeField] private float m_PaddingTop;
    [SerializeField] private float m_PaddingBottom;
    [SerializeField] private float m_PaddingLeft;
    [SerializeField] private float m_PaddingRight;


    private void Start()
    {
        GameManager.Instance.RegisterPlayer(this);
        m_Movement = new Movement(m_Speed, m_Rigid);
    }

    void Update()
    {
        m_Movement.Move(m_MouseSpeed);
        ClampPositionToCameraViewport();
    }

    //User-defined Methods
    private void ClampPositionToCameraViewport()
    {
        var cam = Camera.main;
        Vector2 minPosition = cam.ViewportToWorldPoint(Vector2.zero);
        Vector2 maxPosition = cam.ViewportToWorldPoint(Vector2.one);

        var position = transform.position;
        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
        position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);
        transform.position = position;
    }

}
