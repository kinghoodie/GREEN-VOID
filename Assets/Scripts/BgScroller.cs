using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    [SerializeField] private Vector2 m_MoveSpeed;

    private Vector2 m_Offset;
    private Material m_Material;

    // Start is called before the first frame update
    void Awake()
    {
        m_Material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        m_Offset = m_MoveSpeed * Time.deltaTime;
        m_Material.mainTextureOffset += m_Offset;

        if (m_Material.mainTextureOffset.y >= 1)
        {
            m_Material.mainTextureOffset = new Vector2 (0,0);
        }
    }
}
