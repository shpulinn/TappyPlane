using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour {

    [SerializeField] private GameObject _mainMenuScreen;
    [Space]
    [SerializeField] private Toggle _soundsToggle;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Dropdown _languageDropdown;

    private GameObject _optionsScreen;
    // if sounds is on value = 1, else it = 0
    private int _isSoundsOn;
    private int _currentSoundsOn;
    private float _currentVolume;
    private int _currentLanguageIndex;
    private int _languageIndex;

    private void Awake() {
        _optionsScreen = gameObject;
        _isSoundsOn = PlayerPrefs.GetInt("Sounds", 1);
        if (_isSoundsOn.Equals(1)) {
            _soundsToggle.isOn = true;
        }
        else _soundsToggle.isOn = false;
        _currentSoundsOn = _isSoundsOn;
        _volumeSlider.value = PlayerPrefs.GetFloat("Volume", .5f);
        _currentVolume = _volumeSlider.value;
        _languageDropdown.value = PlayerPrefs.GetInt("Language", 0);
        _currentLanguageIndex = _languageDropdown.value;
    }

    public void SetVolume(float value) {
        _volumeSlider.value = value;
    }

    public void SetLanguage() {
        //switch (_languageDropdown.value) {
        //    case 0:
        //    Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
        //    break;
        //    case 1:
        //    Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
        //    break;
        //    case 2:
        //    Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Chinese");
        //    break;
        //    case 3:
        //    Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Arabic");
        //    break;
        //    case 4:
        //    Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Spanish");
        //    break;
        //}
        _languageIndex = _languageDropdown.value;
    }

    public void ApplyButtonClick() {
        PlayerPrefs.SetInt("Sounds", _isSoundsOn);
        PlayerPrefs.SetFloat("Volume", _volumeSlider.value);
        PlayerPrefs.SetInt("Language", _languageDropdown.value);
        _currentVolume = _volumeSlider.value;
        _optionsScreen.SetActive(false);
        _mainMenuScreen.SetActive(true);
    }

    public void CancelButtonClick() {
        _isSoundsOn = PlayerPrefs.GetInt("Sounds");
        if (_currentSoundsOn.Equals(1)) {
            _soundsToggle.isOn = true;
        }
        else _soundsToggle.isOn = false;
        _volumeSlider.value = _currentVolume;
        _languageDropdown.value = _currentLanguageIndex;
        _optionsScreen.SetActive(false);
        _mainMenuScreen.SetActive(true);
    }

}
