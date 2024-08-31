using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
[CustomEditor(typeof(TextAnimationEditor))]
public class TextAnimationInspector : Editor
{
    public void OnValidate()
    {
        var editor = (TextAnimationEditor)target;
        editor.ShowCurrent();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var editor = (TextAnimationEditor)target;
        if (GUILayout.Button("Save Current SpeechBubble"))
        {
            editor.SaveAsset();
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Previous"))
        {
            editor.PreviousPhrase();
        }
        if (GUILayout.Button("Next"))
        {
            editor.NextPhrase();
        }
        GUILayout.EndHorizontal();
        UnityEditor.SceneView.RepaintAll();
    }
}
#endif

[ExecuteInEditMode]
public class TextAnimationEditor : MonoBehaviour
{
    [Header("다이얼로그 에셋")]

    [SerializeField] private TextAnimationAsset target;
    [SerializeField] private SpeechBubble speechBubble;
    [SerializeField] private int currentIndex;

    public void SaveAsset()
    {
        target.speechBubbles[currentIndex] = speechBubble.Serialize();
    }

    public int GetPhraseLength()
    {
        return target.phrases.Count;
    }

    public TextAnimationAsset.SerializedSpeechBubble GetSpeechBubbleData(int index)
    {
        return target.speechBubbles[index];
    }

    public string GetPhrase(int index)
    {
        return target.phrases[index];
    }

    public void ShowCurrent()
    {
        var data = GetSpeechBubbleData(currentIndex);
        speechBubble.Deserialize(ref data);
        speechBubble.PrintImmediate(GetPhrase(currentIndex));
    }
    public void PreviousPhrase()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ShowCurrent();
        }
    }

    public void NextPhrase()
    {
        if (currentIndex < GetPhraseLength() - 1)
        {
            currentIndex++;
            ShowCurrent();
        }
    }
}
