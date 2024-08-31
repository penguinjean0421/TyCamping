using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Game
{
#if UNITY_EDITOR
    [CustomEditor(typeof(StageBase),true)]
    public class StageBaseInspector : Editor
    {

        

        public override void OnInspectorGUI()
        {
            var obj = (StageBase)target;
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate Target Text From Asset"))
            {
                obj.GeneratePhrasesTextFromFile(obj.baseAsset);
            }
        }
    }
#endif
    public abstract class StageBase : MonoBehaviour
    {
        
        public List<string> targetTextList = new List<string>();
        public List<UnityAction> actionList = new List<UnityAction>();
        public int index = 0;
        public string targetText;
        public TextAsset baseAsset;
        public void Start()
        {
            Initialize();
            Excute();
        }

        public abstract void Initialize();

        public void Next()
        {
            index++;
            Excute();
        }

        public void Excute()
        {
            targetText = targetTextList[index];
            actionList[index].Invoke();
        }

        public void GeneratePhrasesTextFromFile(TextAsset file)
        {
            EditorUtility.SetDirty(this);
            string[] lines = file.text.Split('\n');
            targetTextList = new List<string>();
            for (int i = 0; lines.Length > i; i++)
            {
                targetTextList.Add(lines[i]);
            }
        }
    }
}