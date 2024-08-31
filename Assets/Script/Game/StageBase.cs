using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Game
{
    public class StageBase : MonoBehaviour
    {

        public List<SNode> snodeList = new List<SNode>();

        public int index = 0;
        public TextAsset baseAsset;
        public void Start()
        {
            Initialize();
            GameManager.PushTarget(snodeList[0]);
        }

        public virtual void Initialize()
        {

        }
    }
}