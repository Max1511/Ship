using UnityEngine;

[CreateAssetMenu(menuName = "Weather System/Weather Preset")]
public class WeatherPreset : ScriptableObject
{
    [SerializeField] private string m_name;
    [SerializeField] private float m_intensity;
    [SerializeField] private float m_fogDensity;
    [SerializeField] private float m_windMultiplier;

    public string Name => m_name;
    public float Intensity => m_intensity;
    public float FogDensity => m_fogDensity;
    public float WindMultiplier => m_windMultiplier;
}