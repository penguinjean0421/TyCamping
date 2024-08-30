using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    [SerializeField]
    private TMP_Text _targetText;

    [SerializeField] private StageAsset _stageAsset;

    private int _targetIndex = 0;

    public UnityEvent onCheckPartCorrectEvent;
    public UnityEvent onCheckPartWrongEvent;
    public UnityEvent onCorrectEvent;

    private void Start()
    {
        Initialize();
    }
    private void Update()
    {
        CheckInput();
    }
    public void Initialize()
    {
        _targetIndex = 0;
        SetTargetInputField(_targetIndex);
    }


    public void Next()
    {
        _targetIndex++;
        SetTargetInputField(_targetIndex);
    }

    public void SetTargetInputField(int i)
    {
        _targetText.text = _stageAsset.targetTexts[i];
    }

    public void CheckInput()
    {
        if (ValidationExtension.IsCorrect(_targetText.text, _inputField.text))
        {
            OnCorrect();
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ClearInputField();
                Next();
            }
        }
        else if (ValidationExtension.CheckPart(_targetText.text, _inputField.text))
        {
            OnCheckPartCorrect();

        }
        else
        {
            OnCheckPartWrong();
        }
    }

    private void ClearInputField()
    {
        _inputField.text = "";
    }

    private void OnCheckPartWrong()
    {
        onCheckPartWrongEvent.Invoke();
#if UNITY_EDITOR
        Debug.Log("part worng");
#endif
    }

    private void OnCorrect()
    {
        onCorrectEvent.Invoke();
#if UNITY_EDITOR
        Debug.Log("correct");
#endif
    }

    private void OnCheckPartCorrect()
    {
        onCheckPartCorrectEvent.Invoke();
#if UNITY_EDITOR
        Debug.Log("part correct");
#endif
    }
}
