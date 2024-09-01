using System.Collections;
using System.Linq;
using DG.Tweening;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using System.Text;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(TMP_InputField))]
public class TextAnimationInputFieldHighlighter : MonoBehaviour
{
    private TMP_InputField _inputField;
    private TextAnimationPrinter _printer;
    private string currentText = "";
    private string currentParsedText = "";
    private string previousText = "";
    private string previousParsedText = "";
    private bool _isHighlighting = false;

    private Tween scaleHandler;
    private Tween rotationHandler;
    public void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _printer = GetComponentInChildren<TextAnimationPrinter>();
        //_inputField.onValueChanged.AddListener(Highlight);
    }

    public void LateUpdate()
    {
        previousText = currentText;
        currentText = _inputField.textComponent.text;
        previousParsedText = currentParsedText;
        currentParsedText = _inputField.textComponent.GetParsedText();
        if (!currentParsedText.Equals(previousParsedText))
        {
            if (currentParsedText.Length > previousParsedText.Length)
            {
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Typing);
            }
            else
            {
                AudioManager.instance.PlaySfx(AudioManager.Sfx.BackSpaceHit);
            }
            Highlight(currentParsedText);
        }
    }

    public void Highlight(string text)
    {
        _printer.textComponent.ClearMesh();
        _printer.SetText(text);
        _printer.PrintImmediate();
        if (text.Length > 1)
        {
           
            if (scaleHandler != null)
            {
                scaleHandler.Rewind();
            }
            if (rotationHandler != null)
            {
                rotationHandler.Rewind();
            }
            scaleHandler = _printer.RepeatScaleTween(text.Length - 2, Vector3.one, Vector3.one * 2f, 0.1f, Ease.InBounce, LoopType.Yoyo, 2);
            rotationHandler = _printer.RepeatRotationTween(text.Length - 2, Vector3.zero, Vector3.forward * 25, 0.1f, Ease.InOutBounce, LoopType.Yoyo, 2);
        }
    }
    public void RematchText()
    {
        _printer.SetText(_inputField.text);
        _printer.PrintImmediate();
    }

    public static int GetStringLength(string STR)
    {
        string s = STR;
        byte[] temp = Encoding.Unicode.GetBytes(s);
        return temp.Length;
    }

}
