using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int m_HealthPack;

    public int GetHealthPack()
    {
        return m_HealthPack;
    }
}
