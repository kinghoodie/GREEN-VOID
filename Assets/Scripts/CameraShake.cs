using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float m_ShakeDuration = 1f;
    [SerializeField] private float m_ShakeMagnitude = 1f;
    private Vector3 m_InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_InitialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < m_ShakeDuration)
        {
            transform.position = m_InitialPosition + (Vector3)Random.insideUnitCircle * m_ShakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = m_InitialPosition;
    }
}
