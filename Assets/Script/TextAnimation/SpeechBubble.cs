using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[ExecuteAlways]
public class SpeechBubble : MonoBehaviour
{
    TextAnimationPrinter _printer;
    RectTransform _rectTransform;
    Image _image;

    [SerializeField]
    private Ease appearEase;
    [SerializeField]
    private float appearDuration;

    public void Awake()
    {
        _printer = GetComponentInChildren<TextAnimationPrinter>();
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    public void SetPosition(Vector3 position)
    {
        transform.localPosition = position;
    }

    public void SetSize(Vector2 size)
    {
        _rectTransform.sizeDelta = size;
    }

    public void SetAppearEase(Ease newEase)
    {
        appearEase = newEase;
    }

    public void SetAppearDuration(float duration)
    {
        appearDuration = duration;
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void Print(string text)
    {
        _printer.SetText(text);
        _printer.StopPrinting(); 
        StartCoroutine(_printer.Print());
    }

    public void PrintImmediate(string text)
    {
        transform.localScale = Vector3.one;
        _printer.SetText(text);
        _printer.PrintImmediate();
    }

    public void Skip()
    {
        _printer.Skip();
    }

    public bool IsPrinting()
    {
        return _printer.IsPrinting();
    }

    public TextAnimationAsset.SerializedSpeechBubble Serialize()
    {
        TextAnimationAsset.SerializedSpeechBubble data = new TextAnimationAsset.SerializedSpeechBubble
        {
            position = _rectTransform.localPosition,
            size = _rectTransform.sizeDelta,
            //sprite = _image.sprite,
            appearEase = appearEase,
            appearDuration = appearDuration
        };
        return data;
    }

    public void Deserialize(ref TextAnimationAsset.SerializedSpeechBubble data)
    {
        _rectTransform.localPosition = data.position;
        _rectTransform.sizeDelta = data.size;
        //_image.sprite = data.sprite;
        appearEase = data.appearEase;
        appearDuration = data.appearDuration;
    }
}
