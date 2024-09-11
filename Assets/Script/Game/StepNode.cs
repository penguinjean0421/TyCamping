using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Game
{
    [Serializable]
    public class StepNode
    {
        public string target;
        public UnityAction action;
        public GameObject spriteGroup;
        public SpriteRenderer targetTextImage;
    }
}