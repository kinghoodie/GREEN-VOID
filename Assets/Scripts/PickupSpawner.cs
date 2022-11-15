using System.Collections;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_Pickup;
    [SerializeField] private float m_SpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropThePickup());
    }

    IEnumerator DropThePickup()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(m_SpawnTime);
            SpawnPickup();
            m_SpawnTime += m_SpawnTime;
        }
    }

    private void SpawnPickup()
    {
        Instantiate(m_Pickup, transform.position, Quaternion.identity);
    }
}
