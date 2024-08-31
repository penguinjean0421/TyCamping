using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Util;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public class TextAnimationPrinter : MonoBehaviour
{
    public TMP_Text textComponent;
    private string _originalText;
    [SerializeField]
    private List<string> _usableText;
    private StringBuilder _currentText;
    private int _usableTextIndex;

    private Vector3[] _textMeshPosition;
    private Vector3[] _textMeshScale;
    private Vector3[] _textMeshRotation;
    private Color[] _textMeshColor;

    private Tween[] _textMeshScaleAppearTween;
    private Tween[] _textMeshPositionAppearTween;
    private Tween[] _textMeshRotationAppearTween;
    private Tween[] _textMeshColorAppearTween;

    private Tween[] _textMeshScaleRepeatTween;
    private Tween[] _textMeshPositionRepeatTween;
    private Tween[] _textMeshRotationRepeatTween;
    private Tween[] _textMeshColorRepeatTween;

    private List<TextAnimationStyle> _dialogStyle;

    private bool _isPrinting;

    private void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public bool IsPrinting()
    {
        return _isPrinting;
    }

    public void SetText(string newText)
    {
        _originalText = newText;
        _usableText = new List<string>();
        _dialogStyle = new List<TextAnimationStyle>();

        string pattern = @"<(?<tag>\w+)>(?<value>.*?)<\/\w+>|([^<>]+)";
        string pattern1 = @"<(?<tag>\w+)>(?<value>.*?)<\/\w+>";
        MatchCollection matches = Regex.Matches(_originalText, pattern);
        foreach (Match match in matches)
        {
            var realMatch = Regex.Match(match.Value, pattern1);
            if (realMatch.Success)
            {
                string sytleName = match.Groups["tag"].Value;
                string value = match.Groups["value"].Value;
                Debug.Log(sytleName);
                TextAnimationStyle style = GlobalTextAnimationSetting.instance.FindDialogStyle(sytleName);
                _usableText.Add(value);
                if (style != null)
                {
                    _dialogStyle.Add(style);
                }
                else
                {
                    _dialogStyle.Add(GlobalTextAnimationSetting.instance.defaultTextAnimationStyle);
                }
            }
            else
            {
                _usableText.Add(match.Value);
                _dialogStyle.Add(GlobalTextAnimationSetting.instance.defaultTextAnimationStyle);
            }
        }

        ResetText();
    }

    public int GetUsableTextLength()
    {
        int sum = 0;
        foreach (var x in _usableText)
        {
            sum += x.Count();
        }
        return sum;
    }
    /// <summary>
    /// 텍스트 리셋
    /// </summary>
    public void ResetText()
    {
        int count = GetUsableTextLength();
        _currentText = new StringBuilder(count);
        textComponent.SetText(_currentText);

        _textMeshPosition = new Vector3[count];
        _textMeshScale = new Vector3[count];
        _textMeshRotation = new Vector3[count];
        _textMeshColor = new Color[count];
        for (int i = 0; i < count; i++)
        {
            _textMeshScale[i] = Vector3.one;
            _textMeshColor[i] = Color.black;
        }

        _textMeshScaleAppearTween = new Tween[count];
        _textMeshPositionAppearTween = new Tween[count];
        _textMeshRotationAppearTween = new Tween[count];
        _textMeshColorAppearTween = new Tween[count];

        _textMeshScaleRepeatTween = new Tween[count];
        _textMeshPositionRepeatTween = new Tween[count];
        _textMeshRotationRepeatTween = new Tween[count];
        _textMeshColorRepeatTween = new Tween[count];
    }

    public void PrintCurrentLetter(char c)
    {
        _currentText.Append(c);
        textComponent.SetText(_currentText);
    }

    public Tween AppearScaleTween(int index, Vector3 startScale, Vector3 endScale, float duration, Ease ease)
    {
        _textMeshScale[index] = startScale;
        return DOTween.To(() => _textMeshScale[index], x => _textMeshScale[index] = x, endScale, duration).SetEase(ease);
    }

    public Tween AppearPositionTween(int index, Vector3 startPosition, Vector3 endPosition, float duration, Ease ease)
    {
        _textMeshPosition[index] = startPosition;
        return DOTween.To(() => _textMeshPosition[index], x => _textMeshPosition[index] = x, endPosition, duration).SetEase(ease);
    }

    public Tween AppearRotationTween(int index, Vector3 startRotation, Vector3 endRotation, float duration, Ease ease)
    {
        _textMeshRotation[index] = startRotation;
        return DOTween.To(() => _textMeshRotation[index], x => _textMeshRotation[index] = x, endRotation, duration).SetEase(ease);
    }

    public Tween AppearColorTween(int index, Color startColor, Color endColor, float duration, Ease ease)
    {
        _textMeshColor[index] = startColor;
        return DOTween.To(() => _textMeshColor[index], x => _textMeshColor[index] = x, endColor, duration).SetEase(ease);
    }

    public Tween RepeatScaleTween(int index, Vector3 startScale, Vector3 endScale, float duration, Ease ease, LoopType loopType, int loopTime = -1)
    {
        _textMeshScale[index] = startScale;
        return DOTween.To(() => _textMeshScale[index], x => _textMeshScale[index] = x, endScale, duration).SetEase(ease).SetLoops(loopTime, loopType);
    }

    public Tween RepeatPositionTween(int index, Vector3 startPosition, Vector3 endPosition, float duration, Ease ease, LoopType loopType, int loopTime = -1)
    {
        _textMeshPosition[index] = startPosition;
        return DOTween.To(() => _textMeshPosition[index], x => _textMeshPosition[index] = x, endPosition, duration).SetEase(ease).SetLoops(loopTime, loopType);
    }

    public Tween RepeatRotationTween(int index, Vector3 startRotation, Vector3 endRotation, float duration, Ease ease, LoopType loopType, int loopTime = -1)
    {
        _textMeshRotation[index] = startRotation;
        return DOTween.To(() => _textMeshRotation[index], x => _textMeshRotation[index] = x, endRotation, duration).SetEase(ease).SetLoops(loopTime, loopType);
    }

    public Tween RepeatColorTween(int index, Color startColor, Color endColor, float duration, Ease ease, LoopType loopType, int loopTime = -1)
    {
        _textMeshColor[index] = startColor;
        return DOTween.To(() => _textMeshColor[index], x => _textMeshColor[index] = x, endColor, duration).SetEase(ease).SetLoops(loopTime, loopType);
    }

    private void Update()
    {
        if (textComponent.text.Length > 0)
        {
            textComponent.ForceMeshUpdate();
            var mesh = textComponent.mesh;
            var textInfo = textComponent.textInfo;
            Vector3[] vertices = mesh.vertices;
            Color[] colors = mesh.colors;
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                var characterInfo = textInfo.characterInfo[i];
                if (!characterInfo.isVisible)
                {
                    continue;
                }

                Vector3 center = Vector3.zero;
                float halfHeight, halfWidth;

                halfHeight = Vector3.Distance(vertices[characterInfo.vertexIndex], vertices[characterInfo.vertexIndex + 1]) / 2;
                halfWidth = Vector3.Distance(vertices[characterInfo.vertexIndex + 1], vertices[characterInfo.vertexIndex + 2]) / 2;

                for (int j = 0; j < 4; j++)
                {
                    var origin = vertices[characterInfo.vertexIndex + j];

                    center += origin;
                }
                center /= 4;


                vertices[characterInfo.vertexIndex] = center + _textMeshPosition[i] + Quaternion.Euler(_textMeshRotation[i]) * new Vector3(-halfWidth * _textMeshScale[i].x, -halfHeight * _textMeshScale[i].y, 0);
                vertices[characterInfo.vertexIndex + 1] = center + _textMeshPosition[i] + Quaternion.Euler(_textMeshRotation[i]) * new Vector3(-halfWidth * _textMeshScale[i].x, halfHeight * _textMeshScale[i].y, 0);
                vertices[characterInfo.vertexIndex + 2] = center + _textMeshPosition[i] + Quaternion.Euler(_textMeshRotation[i]) * new Vector3(halfWidth * _textMeshScale[i].x, halfHeight * _textMeshScale[i].y, 0);
                vertices[characterInfo.vertexIndex + 3] = center + _textMeshPosition[i] + Quaternion.Euler(_textMeshRotation[i]) * new Vector3(halfWidth * _textMeshScale[i].x, -halfHeight * _textMeshScale[i].y, 0);
                colors[characterInfo.vertexIndex] = _textMeshColor[i];
                colors[characterInfo.vertexIndex + 1] = _textMeshColor[i];
                colors[characterInfo.vertexIndex + 2] = _textMeshColor[i];
                colors[characterInfo.vertexIndex + 3] = _textMeshColor[i];
            }

            mesh.colors = colors;
            mesh.vertices = vertices;
            textComponent.canvasRenderer.SetMesh(mesh);
        }
    }

    public void AppearTween(TextAnimationStyle style, char letter, int letterCount)
    {
        PrintCurrentLetter(letter);
        if (style.useAppearAnimation)
        {
            _textMeshScaleAppearTween[letterCount] = AppearScaleTween(letterCount, style.appearBeginScale, style.appearEndScale, style.appearInterval / style.appearScaleSpeed, style.appearScaleEase);
            _textMeshPositionAppearTween[letterCount] = AppearPositionTween(letterCount, style.appearBeginPosition, style.appearEndPosition, style.appearInterval / style.appearPositionSpeed, style.appearPositionEase);
            _textMeshRotationAppearTween[letterCount] = AppearRotationTween(letterCount, style.appearBeginRotation, style.appearEndRotation, style.appearInterval / style.appearRotationSpeed, style.appearRotationEase);
            _textMeshColorAppearTween[letterCount] = AppearColorTween(letterCount, style.appearBeginColor, style.appearEndColor, style.appearInterval / style.appearColorSpeed, style.appearColorEase);
        }
    }
    public void RepeatTween(TextAnimationStyle style, int letterCount)
    {
        if (style.useRepeatAnimation)
        {
            _textMeshScaleRepeatTween[letterCount] = RepeatScaleTween(letterCount, style.repeatBeginScale, style.repeatEndScale, style.repeatInterval / style.repeatScaleSpeed,
                style.repeatScaleEase, style.repeatLoopType);
            _textMeshPositionRepeatTween[letterCount] = RepeatPositionTween(letterCount, style.repeatBeginPosition, style.repeatEndPosition, style.repeatInterval / style.repeatPositionSpeed,
                style.repeatPositionEase, style.repeatLoopType);
            _textMeshRotationRepeatTween[letterCount] = RepeatRotationTween(letterCount, style.repeatBeginRotation, style.repeatEndRotation, style.repeatInterval / style.repeatRotationSpeed,
                style.repeatRotationEase, style.repeatLoopType);
            _textMeshColorRepeatTween[letterCount] = RepeatColorTween(letterCount, style.repeatBeginColor, style.repeatEndColor, style.repeatInterval / style.repeatColorSpeed,
                style.repeatColorEase, style.repeatLoopType);
        }
    }

    public void StopPrinting()
    {
        int length = GetUsableTextLength();
        for (int i = 0; i < length; i++)
        {
            _textMeshScaleAppearTween[i].Kill();
            _textMeshPositionAppearTween[i].Kill();
            _textMeshColorAppearTween[i].Kill();
            _textMeshRotationAppearTween[i].Kill();
            _textMeshScaleRepeatTween[i].Kill();
            _textMeshPositionRepeatTween[i].Kill();
            _textMeshRotationRepeatTween[i].Kill();
            _textMeshColorRepeatTween[i].Kill();
        }
        StopAllCoroutines();
        _isPrinting = false;
    }
    public void Skip()
    {

        int letterCount = 0;
        while (_usableTextIndex < _usableText.Count)
        {
            for (int i = 0; i < _usableText[_usableTextIndex].Length; i++)
            {
                AppearTween(GlobalTextAnimationSetting.instance.skipTextAnimationStyle, _usableText[_usableTextIndex][i], letterCount);
            }
        }
        StartCoroutine(RepeatAnimation());
    }

    /// <summary>
    /// 출력 함수
    /// </summary>
    public IEnumerator RepeatAnimation()
    {
        _usableTextIndex = 0;
        int letterCount = 0;
        while (_usableTextIndex < _usableText.Count)
        {
            for (int i = 0; i < _usableText[_usableTextIndex].Length; i++)
            {
                TextAnimationStyle style = _dialogStyle[_usableTextIndex];
                switch (style.appearUnit)
                {
                    case TextAnimationStyle.Unit.Letter:
                        RepeatTween(style, letterCount);
                        yield return new WaitForSeconds(style.appearInterval);
                        break;
                    case TextAnimationStyle.Unit.Word:
                        while (i < _usableText[_usableTextIndex].Length && _usableText[_usableTextIndex][i] != ' ')
                        {
                            RepeatTween(style, letterCount);
                            i++;
                        }
                        yield return new WaitForSeconds(style.appearInterval);
                        break;
                    case TextAnimationStyle.Unit.Sentence:
                        RepeatTween(style, letterCount);
                        yield return new WaitForSeconds(style.appearInterval);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                letterCount++;
            }
            _usableTextIndex++;
        }
        yield return null;
    }

    public void PrintImmediate()
    {
        _isPrinting = true;
        _usableTextIndex = 0;
        while (_usableTextIndex < _usableText.Count)
        {
            foreach (var letter in _usableText[_usableTextIndex])
            {
                PrintCurrentLetter(letter);
            }
            _usableTextIndex++;
        }

        if (_usableTextIndex == 0)
        {
            textComponent.text = "";
        }
        _isPrinting = false;
    }

    public IEnumerator Print()
    {
        _isPrinting = true;
        int letterCount = 0;
        _usableTextIndex = 0;
        while (_usableTextIndex < _usableText.Count)
        {
            for (int i = 0; i < _usableText[_usableTextIndex].Length; i++)
            {
                TextAnimationStyle style = _dialogStyle[_usableTextIndex];
                switch (style.appearUnit)
                {
                    case TextAnimationStyle.Unit.Letter:
                        AppearTween(style, _usableText[_usableTextIndex][i], letterCount);
                        yield return new WaitForSeconds(style.appearInterval);
                        break;
                    case TextAnimationStyle.Unit.Word:
                        while (i < _usableText[_usableTextIndex].Length && _usableText[_usableTextIndex][i] != ' ')
                        {
                            AppearTween(style, _usableText[_usableTextIndex][i], letterCount);
                            i++;
                        }
                        yield return new WaitForSeconds(style.appearInterval);
                        break;
                    case TextAnimationStyle.Unit.Sentence:
                        AppearTween(style, _usableText[_usableTextIndex][i], letterCount);
                        yield return new WaitForSeconds(style.appearInterval);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                letterCount++;
            }
            _usableTextIndex++;
        }

        _isPrinting = false;
        StartCoroutine(RepeatAnimation());
    }
}
