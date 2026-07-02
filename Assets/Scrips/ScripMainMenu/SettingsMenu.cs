using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Toggle _fullscreenToggle;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;

    private Resolution[] _resolutions;

    void Start()
    {
        // Load Volume
        float volume = PlayerPrefs.GetFloat("volume", 1f);
        _volumeSlider.value = volume;
        AudioListener.volume = volume;

        // Fullscreen
        bool fullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        _fullscreenToggle.isOn = fullscreen;
        Screen.fullScreen = fullscreen;

        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        int currentIndex = 0;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            _resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(option));

            if (_resolutions[i].width == Screen.currentResolution.width &&
                _resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }

        _resolutionDropdown.value = currentIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("volume", value);
    }

    public void SetSensitivity(float value)
    {
        PlayerPrefs.SetFloat("sens", value);
    }

    public void SetFullscreen(bool value)
    {
        Screen.fullScreen = value;
        PlayerPrefs.SetInt("fullscreen", value ? 1 : 0);
    }

    public void SetResolution(int index)
    {
        Resolution res = _resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}