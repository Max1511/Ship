using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField, Range(0f, 360f)] private float m_direction = 0;
    [SerializeField, Range(0f, 1f)] private float m_force = 0;

    public float Direction => m_direction;
    public float Force => m_force;
}