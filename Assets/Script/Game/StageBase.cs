using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Game
{
    public class StageBase : MonoBehaviour
    {

        public List<StepNode> snodeList = new List<StepNode>();

        public void Start()
        {
            Initialize();
            var sequence = DOTween.Sequence();
            GameManager.PushTarget(sequence,snodeList[0]);
            sequence.Play();
        }

        public virtual void Initialize()
        {

        }
    }
}