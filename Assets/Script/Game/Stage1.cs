using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Script.Game
{
    public class Stage1 : StageBase
    {
        private bool cut8flag1 = false;
        private bool cut8flag2 = false;
        private bool cut9flag1 = false;
        private bool cut9flag2 = false;
        public override void Initialize()
        {
            snodeList[0].action = OnCutActive0;
            snodeList[1].action = OnCutActive1;
            snodeList[2].action = OnCutActive2;

            snodeList[3].action = OnCutActive3;
            snodeList[4].action = OnCutActive4;
            snodeList[5].action = OnCutActive5;
            snodeList[6].action = OnCutActive6;
            snodeList[7].action = OnCutActive7;
            snodeList[8].action = OnCutActive8;
            snodeList[9].action = OnCutActive9;
        }

        public void OnCutActive0()
        {
            Debug.Log("두근두근 첫 캠핑 돗자리");
            GameManager.PushTarget(snodeList[1]);
        }
        public void OnCutActive1()
        {
            Debug.Log("화르륵 모닥불");
            GameManager.PushTarget(snodeList[2]);
            GameManager.PushTarget(snodeList[3]);
        }
        public void OnCutActive2()
        {
            Debug.Log("맑은 한낮의 하늘");
            GameManager.PushTarget(snodeList[4]);
        }
        public void OnCutActive3()
        {
            Debug.Log("푸르른 새싹의 들판");
            GameManager.PushTarget(snodeList[5]);
            
        }
        public void OnCutActive4()
        {
            Debug.Log("뭉게 뭉게 구름");
            cut9flag2 = true;
            if (cut9flag1)
            {
                GameManager.PushTarget(snodeList[9]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }
        }

        public void OnCutActive5()
        {
            Debug.Log("높디높은 속리산 봉우리");
            GameManager.PushTarget(snodeList[6]);
            GameManager.PushTarget(snodeList[7]);
        }

        public void OnCutActive6()
        {
            Debug.Log("울창한 푸른 소나무");
            cut8flag1 = true;
            if (cut8flag2)
            {
                GameManager.PushTarget(snodeList[8]);
            }

        }
        public void OnCutActive7()
        {
            Debug.Log("앙증맞은 낮은 덤불");
            cut8flag2 = true;
            if (cut8flag1)
            {
                
                GameManager.PushTarget(snodeList[8]);
            }

        }

        public void OnCutActive8()
        {
            Debug.Log("깜찍하고 귀여운 흰토끼");
            cut9flag1 = true;
            if (cut9flag2)
            {
                GameManager.PushTarget(snodeList[9]);
            }

        }

        public void OnCutActive9()
        {
            Debug.Log("우리가족의 첫 캠핑");
        }
    }
}