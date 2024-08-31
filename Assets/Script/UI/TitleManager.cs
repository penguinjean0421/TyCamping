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
    }


    void OnStartButtonClicked()
    {
        SceneManager.LoadScene("IntroCutScene");
    }

    void OnOptionButtonClicked()
    {
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
