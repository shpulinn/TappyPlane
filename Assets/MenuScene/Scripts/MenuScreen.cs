using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour {

    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _optionsScreen;

    public void PlayButtonClick() {

    }

    public void OptionsButtonClick() {
        _mainMenuScreen.SetActive(false);
        _optionsScreen.SetActive(true);
    }

    public void QuitButtonClick() {
        Application.Quit();
    }

}
