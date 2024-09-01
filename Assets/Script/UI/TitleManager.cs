using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button startButton;
    public Button optionButton;
    public Button exitButton;
    public RectTransform titleMenu;
    public RectTransform optionMenu;
    private bool isOptionMenuEnabled = false;
    void Start()
    {
        titleMenu.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(false);
        startButton.onClick.AddListener(OnStartButtonClicked);
        optionButton.onClick.AddListener(OnOptionButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        //AudioManager.instance.PlayBGM(AudioManager.Bgm.Menu,true);
    }


    void OnStartButtonClicked()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        SceneManager.LoadScene("IntroCutScene");
    }

    void OnOptionButtonClicked()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        optionMenu.gameObject.SetActive(true);
        titleMenu.gameObject.SetActive(false);
        isOptionMenuEnabled=true;
        StartCoroutine(OptionMenuRoutine());
    }

    private IEnumerator OptionMenuRoutine()
    {
        while (isOptionMenuEnabled)
        {

            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void OnExitButtonClicked()
    {
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
