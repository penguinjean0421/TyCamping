using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    public Button nextButton;
    public string nextScene;
    void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    // Update is called once per frame
    void OnNextButtonClicked()
    {
        SceneManager.LoadScene(nextScene);
    }
}
