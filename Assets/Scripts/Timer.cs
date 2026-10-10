using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private int m_startTime = 5;

    private int m_time = 0;
    private Coroutine m_timerCoroutine;

    [HideInInspector] public UnityEvent OnStartTimer;
    [HideInInspector] public UnityEvent OnStopTimer;
    [HideInInspector] public UnityEvent<int> OnChangeTime;
    [HideInInspector] public UnityEvent OnTimeOut;

    public void StartTimer()
    {
        m_time = m_startTime;
        m_timerCoroutine = StartCoroutine(WaitTime());

        OnStartTimer?.Invoke();
    }

    public void StopTimer()
    {
        if (m_timerCoroutine != null) StopCoroutine(m_timerCoroutine);

        OnStopTimer?.Invoke();
    }

    private IEnumerator WaitTime()
    {
        while (m_time > 0)
        {
            OnChangeTime?.Invoke(m_time);

            yield return new WaitForSeconds(1);
            m_time--;
        }

        OnTimeOut?.Invoke();
    }
}