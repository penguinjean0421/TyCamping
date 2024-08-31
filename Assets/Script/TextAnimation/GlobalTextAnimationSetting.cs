using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(GlobalTextAnimationSetting))]
public class GlobalTextAnimationSettingEditor : Editor
{
    public void OnValidate()
    {
        var setting = target as GlobalTextAnimationSetting;
#if UNITY_EDITOR
        EditorUtility.SetDirty(target);
#endif
    }
}
#endif

[CreateAssetMenu(fileName = "new GlobalTextAnimationSetting", menuName = "Dialog System/Global Dialog Setting")]
public class GlobalTextAnimationSetting : ScriptableSingleton<GlobalTextAnimationSetting>
{
    public Sprite defaultSpeechBubbleSprite;

    public TextAnimationStyle defaultTextAnimationStyle;

    public TextAnimationStyle skipTextAnimationStyle;

    public List<TextAnimationStyle> dialogStyles;

    public TextAnimationStyle FindDialogStyle(string name)
    {
        return dialogStyles.Find((x) => x.name == name);
    }
}
