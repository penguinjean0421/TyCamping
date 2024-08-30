using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CutAsset",menuName = "Stage/Cut Asset")]
public class StageAsset : ScriptableObject
{
    public List<string> targetTexts;
}
