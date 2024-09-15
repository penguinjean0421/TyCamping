using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button titleButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject pauseMenuPrefab;

    private bool isPaused = false;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseMenuEnable();
            }
            else
            {
                PauseMenuDisable();
            }
        }
    }

    private void Init()
    {
        pauseMenuPrefab.SetActive(false);
        continueButton.onClick.AddListener(OnContinueButtonClicked);
        titleButton.onClick.AddListener(OnTitleButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void PauseMenuEnable()
    {
        Time.timeScale = 0f;
        pauseMenuPrefab.SetActive(true);
        isPaused = true;
    }

    private void PauseMenuDisable()
    {
        Time.timeScale = 1f;
        pauseMenuPrefab.SetActive(false);
        isPaused = false;
    }

    private void OnContinueButtonClicked()
    {
        PauseMenuDisable();
    }

    private void OnTitleButtonClicked()
    {
        PauseMenuDisable();
        SceneManager.LoadScene("Title");
    }

    private void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    private void OnDestroy()
    {
        continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        titleButton.onClick.RemoveListener(OnTitleButtonClicked);
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

}
