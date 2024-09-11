using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(TextAnimationAsset))]
public class TextAnimationAssetInspector : Editor
{
    public void OnValidate()
    {
        TextAnimationAsset asset = (TextAnimationAsset)target;
#if UNITY_EDITOR
        EditorUtility.SetDirty(asset);
#endif
    }

    public override void OnInspectorGUI()
    {
        TextAnimationAsset asset = (TextAnimationAsset)target;
        base.OnInspectorGUI();

        if (GUILayout.Button("Generate All Dialog Text From Resource File"))
        {
            asset.GeneratePhrasesTextFromFile(asset.resourceFile);
        }
        if (GUILayout.Button("Reset Speech Bubbles"))
        {
            asset.ResetSpeechBubbles();
        }
    }
}
#endif


[CreateAssetMenu(fileName = "new DialogAsset", menuName = "Dialog System/Dialog Asset")] 
public class TextAnimationAsset : ScriptableObject
{
    [Serializable]
    public class SerializedSpeechBubble
    {
        public SerializedSpeechBubble()
        {
            
            size = new Vector2(300,300);
            appearDuration = 0.3f;
        }
        public Sprite sprite;
        public Vector3 position;
        public Vector2 size;
        public float appearDuration;
        public Ease appearEase;
    }

    public TextAsset resourceFile; //한글 깨질시 UTF-8로
    public List<SerializedSpeechBubble> speechBubbles = new List<SerializedSpeechBubble>();
    public List<string> phrases;

    public void ResetSpeechBubbles()
    {
        speechBubbles=new List<SerializedSpeechBubble>();
        foreach (var phrase in phrases)
        {
            var instance= new SerializedSpeechBubble();
            speechBubbles.Add(instance);
        }
    }

    public void GeneratePhrasesTextFromFile(TextAsset file)
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
        string[] lines = file.text.Split('\n');
        phrases = new List<string>();
        for (int i = 0; lines.Length > i; i++)
        {
            if (i > speechBubbles.Count)
            {
                speechBubbles.Add(new SerializedSpeechBubble());
            }
            phrases.Add(lines[i]);
        }
    }
}
