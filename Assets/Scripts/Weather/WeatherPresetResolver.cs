using System.Linq;
using UnityEngine;

public class WeatherPresetResolver : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private WeatherPreset[] m_weatherPresets;

    [Header("Parameter")]
    [SerializeField] private WeatherState m_weatherState;

    private WeatherPreset m_currentWeatherPreset;

    private float m_intensity;
    private float m_fogDensity;
    private float m_windMultiplier;

    public float Intensity => m_intensity;
    public float FogDensity => m_fogDensity;
    public float WindMultiplier => m_windMultiplier;

    private void Update()
    {
        m_currentWeatherPreset = m_weatherPresets.FirstOrDefault(preset => preset.Name == m_weatherState.ToString());

        if (m_currentWeatherPreset == null) return;

        m_intensity = m_currentWeatherPreset.Intensity;
        m_fogDensity = m_currentWeatherPreset.FogDensity;
        m_windMultiplier = m_currentWeatherPreset.WindMultiplier;
    }

    private enum WeatherState
    {
        Clear, Rain, Storm, Fog
    }
}