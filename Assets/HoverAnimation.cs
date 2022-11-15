using UnityEngine;

public class HoverAnimation : MonoBehaviour
{
    [SerializeField] float m_FloatSpeed;
    [SerializeField] float m_Mangnitude;

    // Update is called once per frame
    void Update()
    {
        Hover();
    }

    void Hover()
    {
        transform.Translate(0, Mathf.Cos(m_FloatSpeed * Time.time) * m_Mangnitude, 0);
    }
}
