using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Script.Game
{
    public class Stage2_2 : StageBase
    {
        private bool cut7flag1 = false;
        private bool cut7flag2 = false;

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
            ;

            foreach (var snode in snodeList)
            {
                snode.spriteGroup.SetActive(false);
                snode.hint.gameObject.SetActive(false);
            }

            //사운드 BGM
            AudioManager.instance.PlayBGM(AudioManager.Bgm.Stage, true);

        }

        public void OnCutActive0()
        {
            Debug.Log("따스한 햇살이 비추는 언덕");
            snodeList[0].spriteGroup.SetActive(true);
            GameManager.PushTarget(snodeList[1]);
        }
        public void OnCutActive1()
        {
            Debug.Log("한걸음 한걸음 오솔길");
            snodeList[1].spriteGroup.SetActive(true);
            GameManager.PushTarget(snodeList[2]);
            GameManager.PushTarget(snodeList[3]);
        }
        public void OnCutActive2()
        {
            Debug.Log("아름다운 금수강산");
            GameManager.PushTarget(snodeList[4]);
            snodeList[2].spriteGroup.SetActive(true);

            //불꽃 올라오기
        }
        public void OnCutActive3()
        {
            Debug.Log("푸른빛 가을 하늘");
            GameManager.PushTarget(snodeList[5]);
            snodeList[3].spriteGroup.SetActive(true);
           
        }
        public void OnCutActive4()
        {
            Debug.Log("수줍은 꽃잎의 코스모스밭");
            snodeList[4].spriteGroup.SetActive(true);
            cut7flag1 = true;
            if (cut7flag2)
            {
                GameManager.PushTarget(snodeList[6]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }

        }

        public void OnCutActive5()
        {
            Debug.Log("윙윙 빨간 고추잠자리");
            snodeList[5].spriteGroup.SetActive(true);
            GameManager.PushTarget(snodeList[6]);
            GameManager.PushTarget(snodeList[7]);
            cut7flag2 = true;
            if (cut9flag1)
            {
                GameManager.PushTarget(snodeList[6]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }
        }

        public void OnCutActive6()
        {
            Debug.Log("살랑살랑 향기롤운 꽃잎바람");
            snodeList[6].spriteGroup.SetActive(true);
            GameManager.PushTarget(snodeList[7]);

        }
        public void OnCutActive7()
        {
            Debug.Log("가을에도 아름다운 청주 가덕면");
            snodeList[7].spriteGroup.SetActive(true);

        }
    }
}
