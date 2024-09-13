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

#if UNITY_EDITOR
    public bool testMode = true;
#endif

    public static List<StepNode> stepNodeList;
    public int clearCount = 0;
    private bool checkable = true;

    private void Awake()
    {
        Initialize();
    }
    private void LateUpdate()
    {
        CheckInput();
        UpdateClearCount();
    }

    private void UpdateClearCount()
    {
        _clearCountText.text = clearCount + "/" + _stage.snodeList.Count;
    }

    public void Initialize()
    {
        stepNodeList = new List<StepNode>();
    }

    public static void PushTarget(Sequence sequence, StepNode stepNode)
    {
        stepNodeList.Add(stepNode);
        stepNode.targetTextImage.gameObject.SetActive(true);
        stepNode.targetTextImage.color = new Vector4(0, 0, 0, 0);
        sequence.Append(stepNode.targetTextImage.DOColor(Color.white, 0.8f));
        sequence.AppendCallback(()=>
        {
            stepNode.targetTextImage.transform.DOShakeScale(2.0f, Vector3.one * 0.1f, 1)
                .SetLoops(int.MaxValue, LoopType.Yoyo);
        });
    }

    public void CheckInput()
    {
        if (checkable && Input.GetKeyDown(KeyCode.Return))
        {

            bool isCorrect = false;

            foreach (var stepNode in stepNodeList)
            {
#if UNITY_EDITOR
                if (testMode)
                {
                    OnCorrect(stepNode);
                    isCorrect = true;
                    break;
                }
#endif
                if (ValidationExtension.IsCorrect(stepNode.target, _inputField.text))
                {
                    OnCorrect(stepNode);
                    isCorrect = true;
                    break;
                }
            }
            if (!isCorrect)
            {
                OnWrong();
            }
            ClearInputField();
        }

        if (checkable)
        {
            _inputField.ActivateInputField();
        }
        else
        {
            _inputField.DeactivateInputField();
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
        characterManager.FailureAction();
#if UNITY_EDITOR
        //Debug.Log("part worng");
#endif
    }
    private void OnCorrect(StepNode stepNode)
    {
        stepNodeList.Remove(stepNode);
        stepNode.targetTextImage.DOColor(new Vector4(1, 1, 1, 0), 1.0f).OnComplete(() =>
        {
            stepNode.targetTextImage.gameObject.SetActive(false);
        });

        stepNode.spriteGroup.SetActive(true);
        stepNode.action.Invoke(stepNode.spriteGroup.transform);
        
        AnimateCorrect();
        clearCount++;
        if (_stage.snodeList.Count == clearCount)
        {
            StartCoroutine(Finish());
        }
        characterManager.SuccessAction();
    }

    private void AnimateCorrect()
    {
        checkable = false;
        var sequence = DOTween.Sequence();
        sequence.Append(_clearCountText.transform.DOShakeScale(0.1f, Vector3.one * 0.5f));
        sequence.Join(_inputField.transform.DOMoveY(-5, 0.5f).SetRelative());
        sequence.Append(_inputField.transform.DOMoveY(5, 1f).SetDelay(2.2f).SetRelative().OnComplete(() => { checkable = true; }));
    }
}
