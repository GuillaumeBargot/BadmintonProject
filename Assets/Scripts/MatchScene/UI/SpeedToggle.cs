using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedToggle : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    MatchPreferences preferences;

    private void Awake() {
        slider.SetValueWithoutNotify(preferences.speedx10?1:0);
    }
    public void LoadFromPreferences(){
        slider.value = preferences.speedx10?1:0;
    }
    public void OnSliderValueChanged(float value){
        preferences.speedx10 = value==1;
    }
}
