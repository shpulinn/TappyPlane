using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour {

    [SerializeField] private GameObject _levelChoseScreen;
    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _optionsScreen;

    private void Awake() {
        var languageIndex = PlayerPrefs.GetInt("Language", 0);
        switch (languageIndex) {
            case 0:
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
            break;
            case 1:
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");
            break;
            //case 2:
            //Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Chinese");
            //break;
            //case 3:
            //Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Arabic");
            //break;
            //case 4:
            //Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Spanish");
            //break;
        }
    }

    public void QuitButtonClick() {
        Application.Quit();
    }

}
