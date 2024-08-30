using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderManager : MonoBehaviour
{
    [System.Serializable]
    public class SliderTextPair
    {
        public Slider slider;
        public TextMeshProUGUI text;
    }

    public SliderTextPair[] sliderTextPairs;

    private void Start()
    {
        // 각 슬라이더에 대해 이벤트 리스너를 추가하고 초기 텍스트를 설정합니다.
        foreach (var pair in sliderTextPairs)
        {
            UpdateText(pair.slider, pair.text);
            pair.slider.onValueChanged.AddListener(value => UpdateText(pair.slider, pair.text));
        }
    }

    // 슬라이더 값이 변경될 때 호출되는 매서드
    private void UpdateText(Slider _slider, TextMeshProUGUI _text)
    {
        float percent = (_slider.value - _slider.minValue) / (_slider.maxValue - _slider.minValue) * 100;
        _text.text = percent.ToString("0") + "%";
    }
}
