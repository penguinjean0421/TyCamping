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
using UnityEngine.UI;
using Util;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TextAnimationPrinter _printer;
    [SerializeField] private TMP_Text _preview;
    [SerializeField] private TMP_Text _clearCountText;

    public static List<SNode> snodeList;
    public int clearCount=0;

    [SerializeField] private StageBase _stage;

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
        _preview.text = "";
        foreach (var snode in snodeList)
        {
            _preview.text += snode.target + "\n";
        }

        _clearCountText.text = clearCount + "/" +_stage.snodeList.Count;

    }
    public void Initialize()
    {
        snodeList = new List<SNode>();
    }


    public static void PushTarget(SNode snode)
    {
        snodeList.Add(snode);
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(">" + _inputField.text);
            Debug.Log(">>" + _inputField.textComponent.text);
            Debug.Log(">>>" + _inputField.textComponent.GetParsedText());
            bool isCorrect = false;
            foreach (var snode in snodeList)
            {
                if (!ValidationExtension.IsCorrect(snode.target, currentInputText))
                {
                    snodeList.Remove(snode);
                    snode.action.Invoke();
                    OnCorrect();
                    isCorrect = true;
                    _clearCountText.transform.DOShakeScale(0.1f, Vector3.one * 0.5f);
                    _inputField.transform.DOMoveY(-5, 0.5f).SetRelative().OnComplete(() =>
                    {
                        _inputField.transform.DOMoveY(5, 1f).SetRelative();
                    });
                    clearCount++;
                    break;
                }

                if (isCorrect)
                {
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
