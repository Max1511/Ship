using TMPro;
using UnityEngine;

public class WarningOfDestruction : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject m_panel;
    [SerializeField] private TMP_Text m_displayTime;
    [SerializeField] private Timer m_timer;

    [Header("Parameter")]
    [SerializeField] private float m_timeUntilWarningAppears = 1;
    
    private bool m_isWaitingForWarning = false;
    private float m_waitTime = 0;

    private void Awake()
    {
        m_panel.SetActive(false);

        m_timer.OnTimeOut.AddListener(HidePanel);
        m_timer.OnChangeTime.AddListener(ChangeText);
    }

    private void OnDestroy()
    {
        m_timer.OnTimeOut.RemoveListener(HidePanel);
        m_timer.OnChangeTime.RemoveListener(ChangeText);
    }

    private void ChangeText(int time)
    {
        m_displayTime.text = time.ToString();
    }

    private void Update()
    {
        if (m_isWaitingForWarning)
        {
            m_waitTime -= Time.deltaTime;

            if (m_waitTime <= 0)
            {
                m_panel.SetActive(true);
                m_timer.StartTimer();

                m_isWaitingForWarning = false;
            }
        }
    }

    private void HidePanel()
    {
        m_panel.SetActive(false);
    }

    public void Show()
    {
        m_isWaitingForWarning = true;
        m_waitTime = m_timeUntilWarningAppears;
    }

    public void Hide()
    {
        m_timer.StopTimer();

        m_isWaitingForWarning = false;
        m_panel.SetActive(false);
    }
}