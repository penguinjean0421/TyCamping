using System;
using System.Collections;
using Assets.Script.Game;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    public TMP_Text targetText;
    public string target;

    [SerializeField] private StageBase _stage;

    [SerializeField] private int _cutNum = 3;
    private int _targetIndex = 0;

    public UnityEvent onWrongEvent;
    public UnityEvent onCorrectEvent;

    private void Start()
    {
        Initialize();
    }
    private void Update()
    {
        CheckInput();
        _inputField.ActivateInputField();
        target = _stage.targetText.Trim('\r');
        targetText.text = target;//추후 삭제 필요
    }
    public void Initialize()
    {
        _targetIndex = 0;
    }


    public void Next()
    {

        _targetIndex++;
        _stage.Next();
    }

    public void CheckInput()
    {
        if (ValidationExtension.IsCorrect(target, _inputField.text))
        {
            Debug.Log("Correct");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnCorrect();
                ClearInputField();
                Next();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnWrong();
                ClearInputField();
            }
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
