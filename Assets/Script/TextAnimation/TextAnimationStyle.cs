using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Util;

[CreateAssetMenu(fileName = "new TextAnimationStyle", menuName = "Dialog System/Dialog Style")]
public class TextAnimationStyle : ScriptableObject
{
    public enum Unit
    {
        Letter,
        Word,
        Sentence
    }
    public string name = "default";

    public float appearInterval = 0.1f;
    public float repeatInterval = 0.1f;

    private bool alwaysDisable = false;

    [Header("나타내기")]
    public bool useAppearAnimation;
#if UNITY_EDITOR
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Unit appearUnit;
    [Header("Scale")]
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public float appearScaleSpeed = 1;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Vector3 appearBeginScale = Vector3.one;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(alwaysDisable))]
    public Vector3 appearEndScale = Vector3.one;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Ease appearScaleEase;
    [Header("Position")]
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public float appearPositionSpeed = 1;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Vector3 appearBeginPosition;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(alwaysDisable))]
    public Vector3 appearEndPosition;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Ease appearPositionEase;

    [Header("Rotation")]
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public float appearRotationSpeed = 1;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Vector3 appearBeginRotation;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(alwaysDisable))]
    public Vector3 appearEndRotation;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Ease appearRotationEase;

    [Header("Color")]
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public float appearColorSpeed = 1;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Color appearBeginColor = Color.black;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Color appearEndColor = Color.black;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public Ease appearColorEase;


    [Header("반복")]
    public bool useRepeatAnimation;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Unit repeatUnit;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public LoopType repeatLoopType;

    [Header("Scale")]
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public float repeatScaleSpeed = 1;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Vector3 repeatBeginScale = Vector3.one;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Vector3 repeatEndScale = Vector3.one;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Ease repeatScaleEase;

    [Header("Position")]
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public float repeatPositionSpeed = 1;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Vector3 repeatBeginPosition;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Vector3 repeatEndPosition;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Ease repeatPositionEase;

    [Header("Rotation")]
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public float repeatRotationSpeed = 1;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Vector3 repeatBeginRotation;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Vector3 repeatEndRotation;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Ease repeatRotationEase;

    [Header("Color")]
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useAppearAnimation))]
    public float repeatColorSpeed = 1;
    public Color repeatBeginColor = Color.black;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Color repeatEndColor = Color.black;
    [ShowIf(ShowIfAttribute.ActionOnConditionFail.JustDisable, ShowIfAttribute.ConditionOperator.And, nameof(useRepeatAnimation))]
    public Ease repeatColorEase;
#else
    public Unit appearUnit;
    [Header("Scale")]
    public float appearScaleSpeed = 1;
    public Vector3 appearBeginScale = Vector3.one;
    public Vector3 appearEndScale = Vector3.one;
    public Ease appearScaleEase;
    [Header("Position")]
    public float appearPositionSpeed = 1;
    
    public Vector3 appearBeginPosition;
    public Vector3 appearEndPosition;
    
    public Ease appearPositionEase;

    [Header("Rotation")]
    
    public float appearRotationSpeed = 1;
    
    public Vector3 appearBeginRotation;
    public Vector3 appearEndRotation;
    
    public Ease appearRotationEase;

    [Header("Color")]
    
    public float appearColorSpeed = 1;
    
    public Color appearBeginColor = Color.black;
    
    public Color appearEndColor = Color.black;
    
    public Ease appearColorEase;


    [Header("반복")]
    public bool useRepeatAnimation;
    
    public Unit repeatUnit;
    
    public LoopType repeatLoopType;

    [Header("Scale")]
    
    public float repeatScaleSpeed = 1;
    
    public Vector3 repeatBeginScale = Vector3.one;
    
    public Vector3 repeatEndScale = Vector3.one;
    
    public Ease repeatScaleEase;

    [Header("Position")]
    
    public float repeatPositionSpeed = 1;
    
    public Vector3 repeatBeginPosition;
    
    public Vector3 repeatEndPosition;
    
    public Ease repeatPositionEase;

    [Header("Rotation")]
    
    public float repeatRotationSpeed = 1;
   
    public Vector3 repeatBeginRotation;
  
    public Vector3 repeatEndRotation;
 
    public Ease repeatRotationEase;

    [Header("Color")]
 
    public float repeatColorSpeed = 1;
    public Color repeatBeginColor = Color.black;
  
    public Color repeatEndColor = Color.black;
    
    public Ease repeatColorEase;

#endif
}
