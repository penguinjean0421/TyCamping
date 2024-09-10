using System.Collections;
using DG.Tweening;
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

    [Header("[Images]")]
    public Image map;
    public Image mapContentsMask;
    public Image title;
    public Image character;
    public RectTransform characterInitialPoint;

    private bool isOptionMenuEnabled = false;
    private Sequence animateSequence;

    void Start()
    {
        Initialize();
        Animate();
    }

    private void Animate()
    {
        animateSequence = DOTween.Sequence();

        var characterTargetPosition = character.rectTransform.localPosition;
        map.transform.localScale = Vector3.up;
        mapContentsMask.rectTransform.sizeDelta = Vector2.zero;
        title.transform.localScale = Vector3.zero;

        startButton.transform.localScale = Vector3.zero;
        optionButton.transform.localScale = Vector3.zero;
        exitButton.transform.localScale = Vector3.zero;
        character.rectTransform.anchoredPosition = characterInitialPoint.anchoredPosition;

        animateSequence.Append(map.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack));
        animateSequence.Append(mapContentsMask.rectTransform.DOSizeDelta(map.rectTransform.sizeDelta*2, 2.0f).SetEase(Ease.InOutCubic));
        
        animateSequence.Append(character.transform.DOLocalJump(characterTargetPosition, 50,5,2));
        animateSequence.Append(title.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic));
        //Button
        animateSequence.Append(startButton.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutElastic));
        animateSequence.Join(optionButton.transform.DOScale(Vector3.one, 1f).SetDelay(0.1f).SetEase(Ease.OutElastic));
        animateSequence.Join(exitButton.transform.DOScale(Vector3.one, 1f).SetDelay(0.2f).SetEase(Ease.OutElastic));
    }

    private void Initialize()
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
