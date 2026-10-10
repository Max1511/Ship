using UnityEngine;

[RequireComponent(typeof(ShipMovement), typeof(Rigidbody2D))]
public class Ship : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private PlayZone m_playZone;

    [Header("Parameters")]
    [SerializeField] private float m_maxSpeed = 5;
    [SerializeField] private float m_speedStep = 2;
    [SerializeField] private float m_maxRotateSpeed = 60;
    [SerializeField] private float m_rotateSpeedStep = 30;
    [SerializeField] private float m_mainAngle = 90;

    private ShipMovement m_shipMovement;
    private Rigidbody2D m_rigidbody;

    private float m_speed = 0;
    private float m_rotateSpeed = 0;

    private void Awake()
    {
        m_shipMovement = GetComponent<ShipMovement>();
        m_rigidbody = GetComponent<Rigidbody2D>();

        m_playZone.OnLocationExit.AddListener(Destroy);
    }

    private void OnDestroy()
    {
        m_playZone.OnLocationExit.RemoveListener(Destroy);
    }

    private void Update()
    {
        if (m_shipMovement.IsMoveForward)
        {
            if (m_speed < m_maxSpeed)
            {
                m_speed += m_speedStep * Time.deltaTime;
            }
        }
        else if (m_speed > 0)
        {
            m_speed -= m_speedStep * Time.deltaTime;
        }
        else
        {
            m_speed = 0;
        }

        if (m_shipMovement.IsMoveLeft && !m_shipMovement.IsMoveRight)
        {
            if (Mathf.Abs(m_rotateSpeed) < m_maxRotateSpeed)
            {
                m_rotateSpeed += m_rotateSpeedStep * Time.deltaTime;
            }
        }
        else if (m_shipMovement.IsMoveRight && !m_shipMovement.IsMoveLeft)
        {
            if (Mathf.Abs(m_rotateSpeed) < m_maxRotateSpeed)
            {
                m_rotateSpeed -= m_rotateSpeedStep * Time.deltaTime;
            }
        }
        else if (m_rotateSpeed != 0)
        {
            if (m_rotateSpeed > 0) m_rotateSpeed -= m_rotateSpeedStep * Time.deltaTime;
            if (m_rotateSpeed < 0) m_rotateSpeed += m_rotateSpeedStep * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = EasyMath.PolarToCartesian(m_speed, m_rigidbody.rotation + m_mainAngle);

        m_rigidbody.MovePosition(m_rigidbody.position + direction * Time.deltaTime);
        m_rigidbody.SetRotation(m_rigidbody.rotation + m_rotateSpeed * Time.deltaTime);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}