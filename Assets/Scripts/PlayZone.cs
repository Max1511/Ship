using UnityEngine;
using UnityEngine.Events;

public class PlayZone : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Timer m_destroyTimer;
    [SerializeField] private WarningOfDestruction m_warningOfDestruction;

    private bool m_isBeyondZone = false;

    [HideInInspector] public UnityEvent OnLocationExit;

    private void Start()
    {
        m_destroyTimer.OnTimeOut.AddListener(LocationExit);
    }

    private void OnDestroy()
    {
        m_destroyTimer.OnTimeOut.RemoveListener(LocationExit);
    }

    private void LocationExit()
    {
        OnLocationExit?.Invoke();
        Debug.Log("Location exited");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player") return;

        m_isBeyondZone = true;
        m_warningOfDestruction.Show();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player") return;

        if (m_isBeyondZone)
        {
            m_warningOfDestruction.Hide();
            m_isBeyondZone = false;
        }
    }
}