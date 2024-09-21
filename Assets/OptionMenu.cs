using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public TMP_Text typingEffectText;
    public TMP_Text bgmText;
    public TMP_Text sfxText;

    public Toggle typingEffect;
    public Slider bgm;
    public Slider sfx;

    private void Awake()
    {
        sfx.value = 1f;
        bgm.value = 1f;
        typingEffect.isOn = true;
    }
    public void Start()
    {
        if (PlayerPrefs.HasKey("SFX"))
        {
            var sfxValue = PlayerPrefs.GetFloat("SFX");
            sfx.value = sfxValue;
            SetSfxText(sfxValue);
        }

        if (PlayerPrefs.HasKey("BGM"))
        {
            var bgmValue = PlayerPrefs.GetFloat("BGM");
            bgm.value = bgmValue;
            SetBgmText(bgmValue);
        }

        if (PlayerPrefs.HasKey("TypingEffect"))
        {
            var typingEffectValue = PlayerPrefs.GetInt("TypingEffect");
            typingEffect.isOn = typingEffectValue == 1;
            SetEffectText(typingEffectValue == 1);
        }
    }

    public void SetEffectText(bool value)
    {
        if (value)
        {
            typingEffectText.SetText("ON");
        }
        else
        {
            typingEffectText.SetText("OFF");
        }
        PlayerPrefs.SetInt("TypingEffect", value ? 1 : 0);
    }

    public void SetBgmText(float value)
    {
        int text =  (int)(100 * value);
        bgmText.SetText(text+"%");
        PlayerPrefs.SetFloat("BGM",value);
    }

    public void SetSfxText(float value)
    {
        int text = (int)(100 * value);
        sfxText.SetText(text + "%");
        PlayerPrefs.SetFloat("SFX", value);
    }
}
