using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class TextAnimationInputFieldHighlighter : MonoBehaviour
{
    private TMP_InputField _inputField;
    private TextAnimationPrinter _printer;

    public void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _printer = GetComponentInChildren<TextAnimationPrinter>();
        _inputField.onValueChanged.AddListener(Highlight);
    }

    public void Highlight(string text)
    {
        Debug.Log(text);
        _printer.SetText(text);
        _printer.PrintImmediate();
        
        if (text.Length > 0)
        {
            _printer.RepeatScaleTween(text.Length - 1, Vector3.one, Vector3.one * 1.5f, 0.1f, Ease.Flash, LoopType.Yoyo, 2);
        }
    }

    public void RematchText()
    {
        _printer.SetText(_inputField.text);
        _printer.PrintImmediate();
    }
}
