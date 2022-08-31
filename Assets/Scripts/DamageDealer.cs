using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int m_DamageDealer;

    public int GetDamage()
    {
        return m_DamageDealer;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
