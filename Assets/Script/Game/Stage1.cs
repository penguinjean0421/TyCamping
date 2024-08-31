using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Game
{
    public class Stage1 : StageBase
    {

        public override void Initialize()
        {
            actionList.Add(OnCutActive1_1);
            actionList.Add(OnCutActive1_2);
            actionList.Add(OnCutActive1_3);
            actionList.Add(OnCutActive1_3);
            actionList.Add(OnCutActive1_3);
            actionList.Add(OnCutActive1_3);
        }

        public void OnCutActive1_1()
        {
            Debug.Log("Action1");
            
        }
        public void OnCutActive1_2()
        {
            Debug.Log("Action2");
        }
        public void OnCutActive1_3()
        {
            Debug.Log("Action3");
        }

    }
}