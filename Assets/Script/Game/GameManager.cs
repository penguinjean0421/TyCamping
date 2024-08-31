using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Assets.Script.Game;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextAnimationPrinter _printer;
    [SerializeField] private TMP_Text _clearCountText;
    [SerializeField] private RectTransform finishUI;
    [SerializeField] private StageBase _stage;

    public static List<SNode> snodeList;
    public int clearCount=0;


    private string currentInputText;

    public UnityEvent onWrongEvent;
    public UnityEvent onCorrectEvent;

    private void Awake()
    {
        Initialize();
    }

    private void LateUpdate()
    {
        currentInputText = _inputField.text;
        CheckInput();
        _inputField.ActivateInputField();
        if (_stage.snodeList.Count == clearCount)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(_stage.nextCutScene);
            }
        }

        _clearCountText.text = clearCount + "/" +_stage.snodeList.Count;

    }
    public void Initialize()
    {
        snodeList = new List<SNode>();
        finishUI.gameObject.SetActive(false);
    }


    public static void PushTarget(SNode snode)
    {
        snodeList.Add(snode);
        snode.hint.gameObject.SetActive(true);
        snode.hint.color = new Vector4(0, 0, 0, 0);
        snode.hint.DOColor(Color.white, 0.2f);
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.EnterHit);

            Debug.Log(">" + _inputField.text);
            Debug.Log(">>" + _inputField.textComponent.text);
            Debug.Log(">>>" + _inputField.textComponent.GetParsedText());
            bool isCorrect = false;
            foreach (var snode in snodeList)
            {
                if (!ValidationExtension.IsCorrect(snode.target, currentInputText))
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
                    _inputField.transform.DOMoveY(-5, 0.5f).SetRelative().OnComplete(() =>
                    {
                        _inputField.transform.DOMoveY(5, 1f).SetRelative();
                    });
                    clearCount++;
                    if (_stage.snodeList.Count == clearCount)
                    {
                        finishUI.gameObject.SetActive(true);
                    }

                    break;
                }
            }
            if (!isCorrect)
            {
                OnWrong();
            }

            ClearInputField();
        }

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
