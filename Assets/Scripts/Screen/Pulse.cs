using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pulse : MonoBehaviour 
{
    [SerializeField] 
    private RectTransform m_Transform;

    [SerializeField]
    private float m_Length = 0.3f;

    [SerializeField]
    private float m_Speed = 0.5f;

    private Vector3 m_DefaultScale;

    void Awake()
    {
        m_Transform = GetComponent<RectTransform>();
    }

    void Start()
    {
        m_DefaultScale = m_Transform.localScale;
    }

	void FixedUpdate () 
    {
        m_Transform.localScale = m_DefaultScale + Vector3.one * Mathf.PingPong(Time.time * m_Speed, m_Length);
	}
}
