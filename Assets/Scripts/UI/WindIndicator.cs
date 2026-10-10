using TMPro;
using UnityEngine;

public class WindIndicator : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Wind m_wind;

    [SerializeField] private GameObject m_indicatorArrow;
    [SerializeField] private TMP_Text m_displayWindDirection;

    private void Update()
    {
        m_indicatorArrow.transform.eulerAngles = new Vector3(0, 0, m_wind.Direction - Camera.main.gameObject.transform.eulerAngles.z);
        m_displayWindDirection.text = m_wind.Direction.ToString();
    }
}
