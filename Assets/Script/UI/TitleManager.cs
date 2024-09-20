using System.Collections;
using Default.Scripts.Sound;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button startButton;
    public Button optionButton;
    public Button optionBackButton;
    public Button exitButton;
    public RectTransform titleMenu;
    public RectTransform optionMenu;

    [Header("[Images]")]
    public Image map;
    public Image mapContentsMask;
    public Image[] title;
    public Image character;
    public Image tent;
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

        title[0].transform.localScale=Vector3.zero;
        title[1].transform.localScale=Vector3.zero;
        title[2].transform.localScale=Vector3.zero;
        title[3].transform.localScale=Vector3.zero;
        title[4].transform.localScale=Vector3.up;
        tent.transform.localScale=Vector3.zero;



        startButton.transform.localScale = Vector3.zero;
        optionButton.transform.localScale = Vector3.zero;
        exitButton.transform.localScale = Vector3.zero;
        character.rectTransform.anchoredPosition = characterInitialPoint.anchoredPosition;

        animateSequence.Append(map.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack));
        animateSequence.Append(mapContentsMask.rectTransform.DOSizeDelta(map.rectTransform.sizeDelta*2, 1.0f).SetEase(Ease.InOutCubic));
        
        animateSequence.Append(character.transform.DOLocalJump(characterTargetPosition, 50,5,1));
        animateSequence.Append(title[0].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutElastic));
        animateSequence.Join(title[1].transform.DOScale(Vector3.one, 0.5f).SetDelay(0.1f).SetEase(Ease.OutElastic));
        animateSequence.Join(title[2].transform.DOScale(Vector3.one, 0.5f).SetDelay(0.2f).SetEase(Ease.OutElastic));
        animateSequence.Join(title[3].transform.DOScale(Vector3.one, 0.5f).SetDelay(0.3f).SetEase(Ease.OutElastic));
        animateSequence.Append(tent.transform.DOScaleY(1, 0.5f).SetEase(Ease.OutBack));
        animateSequence.Join(tent.transform.DOScaleX(1, 0.7f).SetEase(Ease.OutBack));
        animateSequence.Append(title[4].transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack));
        animateSequence.AppendCallback(() =>
        {
            title[0].transform.DOShakeRotation(3, 3, 1).SetLoops(int.MaxValue,LoopType.Yoyo);
            title[1].transform.DOShakeRotation(3, 3, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            title[2].transform.DOShakeRotation(3, 3, 1).SetLoops(int.MaxValue, LoopType.Yoyo); ;
            title[3].transform.DOShakeRotation(3, 3,1).SetLoops(int.MaxValue, LoopType.Yoyo);
            tent.transform.DOShakeScale(3, 0.1f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
        });


        //Button
        animateSequence.Append(startButton.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutElastic));
        animateSequence.Join(optionButton.transform.DOScale(Vector3.one, 0.5f).SetDelay(0.1f).SetEase(Ease.OutElastic));
        animateSequence.Join(exitButton.transform.DOScale(Vector3.one, 0.5f).SetDelay(0.2f).SetEase(Ease.OutElastic));
    }

    private void Initialize()
    {
        titleMenu.gameObject.SetActive(true);
        optionMenu.gameObject.SetActive(false);
        startButton.onClick.AddListener(OnStartButtonClicked);
        optionButton.onClick.AddListener(OnOptionButtonClicked);
        optionBackButton.onClick.AddListener(OnOptionBackButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        SoundManager.Play("Menu",1);
    }


    void OnStartButtonClicked()
    {
        SceneManager.LoadScene("IntroCutScene");
        SoundManager.PlayOneShot("Button");
    }

    void OnOptionButtonClicked()
    {
        optionMenu.gameObject.SetActive(true);
        titleMenu.gameObject.SetActive(false);
        isOptionMenuEnabled=true;
        StartCoroutine(OptionMenuRoutine());
        SoundManager.PlayOneShot("Button");
    }

    void OnOptionBackButtonClicked()
    {
        optionMenu.gameObject.SetActive(false);
        titleMenu.gameObject.SetActive(true);
        isOptionMenuEnabled = false;
        SoundManager.PlayOneShot("Button");
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
