using Assets.Script.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishUI : MonoBehaviour
{
    public Button nextButton;
    public string nextScene;
    public MileStone mileStone;
    void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    // Update is called once per frame
    void OnNextButtonClicked()
    {
        mileStone.Initialize();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(mileStone.Stamp());
        sequence.Append(mileStone.Animate());
        sequence.AppendInterval(3.0f);
        sequence.AppendCallback(() =>
        {
            SceneManager.LoadScene(nextScene);
        });
        sequence.Play();
    }
}
