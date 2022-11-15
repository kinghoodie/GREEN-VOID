using UnityEngine;

public class Movement
{
    private float m_PlayerSpeed;
    private Rigidbody2D m_Rigid;
    private Vector2 m_LastMousePos;

    /// <summary>
    /// Construct a new instance of the Movement class, providing all relevant data.
    /// </summary>
    /// <param name="playerSpeed">The speed with which the player will move.</param>
    /// <param name="rigid">Reference to a rigidbody2D object.</param>
    /// <param name="mousePos"></param>
    public Movement(float playerSpeed, Rigidbody2D rigid)
    {
        m_PlayerSpeed = playerSpeed;
        m_Rigid = rigid;
    }

    /// <summary>
    /// Run movement logic.
    /// </summary>
    /// <param name="mouseFollowSpeed">The speed with which we will move towards mouse position.</param>
    public void Move(float mouseFollowSpeed)
    {
        if (!TryMoveWithMouse(mouseFollowSpeed))
        {
            //Keyboard Controls
            Vector2 movementAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movementAxis = Vector2.ClampMagnitude(movementAxis, 1f);
            m_Rigid.velocity = movementAxis * m_PlayerSpeed;
        }
    }

    //Checking to see if Mouse is active or not
    private bool TryMoveWithMouse(float mouseFollowSpeed)
    {
        if (TryUpdateMousePosition())
        {
            MoveThePlayerToMousePosition(mouseFollowSpeed);
            return true;
        }
        return false;
    }

    //Updation the last mouse position
    private bool TryUpdateMousePosition()
    {
        if (Input.GetMouseButton(0))
        {
            m_LastMousePos = Input.mousePosition;
            return true;
        }
        return false;
    }

    //On-Click Events
    private void MoveThePlayerToMousePosition(float mouseFollowSpeed)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(m_LastMousePos);
        m_Rigid.MoveTowardsWithVelocity(mousePosition, mouseFollowSpeed, true);
    }
}

