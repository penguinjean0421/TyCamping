using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Assets.Script.Game
{
    [Serializable]
    public class SNode
    {
        public string target;
        public UnityAction action;
    }
}