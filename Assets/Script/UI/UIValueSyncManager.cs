using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIValueSyncManager : MonoBehaviour
{
    [System.Serializable]
    public class SliderTextPair
    {
        public Slider slider;
        public TextMeshProUGUI text;
    }

    [System.Serializable]
    public class ToggleTextPair
    {
        public Toggle toggle;
        public TextMeshProUGUI text;
    }

    public SliderTextPair[] sliderTextPairs;
    public ToggleTextPair[] toggleTextPairs;


    private void Start()
    {
        // 각 슬라이더에 대해 이벤트 리스너를 추가하고 초기 텍스트를 설정합니다.
        foreach (var pair in sliderTextPairs)
        {
            UpdateSliderText(pair.slider, pair.text);
            pair.slider.onValueChanged.AddListener(value => UpdateSliderText(pair.slider, pair.text));
        }

        // Toggle 초기화 및 이벤트 리스너 등록
        foreach (var pair in toggleTextPairs)
        {
            UpdateToggleText(pair.toggle,pair.text);
            pair.toggle.onValueChanged.AddListener(isOn => UpdateToggleText(pair.toggle, pair.text));

        }
    }

    // 슬라이더 값이 변경될 때 호출되는 매서드
    private void UpdateSliderText(Slider _slider, TextMeshProUGUI _text)
    {
        float percent = (_slider.value - _slider.minValue) / (_slider.maxValue - _slider.minValue) * 100;
        _text.text = percent.ToString("0") + "%";
    }

    private void UpdateToggleText(Toggle _toggle, TextMeshProUGUI _text)
    {
        _text.text = _toggle.isOn ? "ON" : "OFF";
    }
}
