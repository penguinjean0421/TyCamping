using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Script.Game;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextAnimationPrinter _printer;
    [SerializeField] private TMP_Text _clearCountText;
    [SerializeField] private RectTransform finishUI;
    [SerializeField] private StageBase _stage;
    [SerializeField] private CharacterManager characterManager;

    public static List<SNode> snodeList;
    public int clearCount = 0;


    private string currentInputText;

    public UnityEvent onWrongEvent;
    public UnityEvent onCorrectEvent;
    private bool checkable = true;

    private void Awake()
    {
        Initialize();
    }


    private void LateUpdate()
    {
        currentInputText = _inputField.text;
        CheckInput();
        _inputField.ActivateInputField();
        _clearCountText.text = clearCount + "/" + _stage.snodeList.Count;

    }
    public void Initialize()
    {
        snodeList = new List<SNode>();
    }


    public static void PushTarget(SNode snode)
    {
        snodeList.Add(snode);
        snode.hint.gameObject.SetActive(true);
        snode.hint.color = new Vector4(0, 0, 0, 0);
        snode.hint.DOColor(Color.white, 0.8f).SetDelay(2.5f).OnComplete(() =>
        {
            snode.hint.transform.DOShakeScale(2.0f, Vector3.one * 0.1f,1).SetLoops(-1, LoopType.Yoyo);
        });   // 댄븨띿뒪섑
    }

    public void CheckInput()
    {
        if (checkable && Input.GetKeyDown(KeyCode.Return))
        {
            bool isCorrect = false;
            foreach (var snode in snodeList)
            {
                if (ValidationExtension.IsCorrect(snode.target, currentInputText))
                {
                    snodeList.Remove(snode);
                    snode.hint.DOColor(new Vector4(1, 1, 1, 0), 1.0f).OnComplete(() =>
                    {
                        snode.hint.gameObject.SetActive(false);
                    });

                    snode.action.Invoke();
                    OnCorrect();
                    isCorrect = true;
                    _clearCountText.transform.DOShakeScale(0.1f, Vector3.one * 0.5f);
                    checkable = false;
                    _inputField.transform.DOMoveY(-5, 0.5f).SetRelative().OnComplete(() =>
                    {
                        _inputField.transform.DOMoveY(5, 1f).SetDelay(2.2f).SetRelative().OnComplete(() => { checkable = true; });
                    });
                    clearCount++;
                    if (_stage.snodeList.Count == clearCount)
                    {
                        StartCoroutine(Finish());
                    }

                    // 罹먮┃깃났 ≪뀡
                    characterManager.SuccessAction();

                    break;
                }
            }
            if (!isCorrect)
            {
                OnWrong();

                // 罹먮┃ㅽ뙣 ≪뀡
                characterManager.FailureAction();

            }

            ClearInputField();
        }

    }

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(2f);
        finishUI.gameObject.SetActive(true);
        yield return null;
    }

    private void ClearInputField()
    {
        _inputField.text = "";
    }
    private void OnWrong()
    {
        onWrongEvent.Invoke();
#if UNITY_EDITOR
        //Debug.Log("part worng");
#endif
    }
    private void OnCorrect()
    {
        onCorrectEvent.Invoke();
#if UNITY_EDITOR
        //Debug.Log("correct");
#endif
    }
}
