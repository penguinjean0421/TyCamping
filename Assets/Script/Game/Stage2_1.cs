using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Script.Game
{
    public class Stage2_1 : StageBase
    {
        private bool cut3flag1 = false;
        private bool cut3flag2 = false;
        private bool cut4flag1 = false;
        private bool cut4flag2 = false;
        public override void Initialize()
        {
            snodeList[0].action = OnCutActive0;
            snodeList[1].action = OnCutActive1;
            snodeList[2].action = OnCutActive2;
            snodeList[3].action = OnCutActive3;
            snodeList[4].action = OnCutActive4;
            snodeList[5].action = OnCutActive5;

            foreach (var snode in snodeList)
            {
                snode.spriteGroup.SetActive(false);
                snode.hint.gameObject.SetActive(false);
            }

            //사운드 BGM
            AudioManager.instance.PlayBGM(AudioManager.Bgm.Stage, true);
            AudioManager.instance.PlayEnvirBgm(AudioManager.EnvirBgm.Stage21, true);

        }

        public void OnCutActive0()
        {
            Debug.Log("따스한 햇살이 비추는 언덕");
            snodeList[0].spriteGroup.SetActive(true);
            snodeList[0].spriteGroup.transform.GetChild(1).localScale = new Vector3(0.1f, 0.5f, 0f);
            snodeList[0].spriteGroup.transform.GetChild(1).DOScale(Vector3.one, 0.5f);
            //돗자리 펼치기

            snodeList[0].spriteGroup.transform.GetChild(0).localScale = new Vector3(0.1f, 0.5f, 0f);
            snodeList[0].spriteGroup.transform.GetChild(0).DOScale(Vector3.one, 0.5f);
            snodeList[0].spriteGroup.transform.GetChild(0).position = snodeList[0].spriteGroup.transform.GetChild(0).position + Vector3.up * 2;
            snodeList[0].spriteGroup.transform.GetChild(0).DOMoveY(-2, 0.5f).SetRelative().SetDelay(0.5f);
            //바구니 내려오기

            GameManager.PushTarget(snodeList[1]);
        }
        public void OnCutActive1()
        {
            Debug.Log("화르륵 모닥불");
            snodeList[1].spriteGroup.SetActive(true);
            snodeList[1].spriteGroup.transform.GetChild(0).localScale = new Vector3(0.5f, 0.1f, 0f);
            snodeList[1].spriteGroup.transform.GetChild(0).DOScale(Vector3.one, 0.5f).SetDelay(0.5f);
            snodeList[1].spriteGroup.transform.GetChild(0).position = snodeList[1].spriteGroup.transform.GetChild(0).position - Vector3.up * 0.5f;
            snodeList[1].spriteGroup.transform.GetChild(0).DOMoveY(0.5f, 0.5f).SetRelative().SetDelay(0.5f);
            //불꽃 올라오기


            snodeList[1].spriteGroup.transform.GetChild(1).localScale = new Vector3(0.1f, 0.1f, 0f);
            snodeList[1].spriteGroup.transform.GetChild(1).DOScale(Vector3.one, 0.5f);
            //나무 생성

            // 이펙트 플레이...

            GameManager.PushTarget(snodeList[3]);
        }
        public void OnCutActive2()
        {
            Debug.Log("맑은 한낮의 하늘");
            GameManager.PushTarget(snodeList[4]);
            snodeList[2].spriteGroup.SetActive(true);
            snodeList[2].spriteGroup.transform.position = snodeList[2].spriteGroup.transform.position + Vector3.up * 15f;
            snodeList[2].spriteGroup.transform.DOMoveY(-15f, 0.5f).SetRelative();
            snodeList[2].spriteGroup.GetComponentInChildren<SpriteRenderer>().color = new Vector4();
            snodeList[2].spriteGroup.GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 0.5f);
            //불꽃 올라오기
        }
        public void OnCutActive3()
        {
            Debug.Log("푸르른 새싹의 들판");
            GameManager.PushTarget(snodeList[2]);
            GameManager.PushTarget(snodeList[5]);
            snodeList[3].spriteGroup.SetActive(true);
            snodeList[3].spriteGroup.GetComponentInChildren<SpriteRenderer>().color = new Vector4();
            snodeList[3].spriteGroup.GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 0.5f);
            snodeList[3].spriteGroup.GetComponentInChildren<SpriteMask>().transform.DOScaleX(0,0.5f);
        }
        public void OnCutActive4()
        {
            Debug.Log("뭉게 뭉게 구름");
            snodeList[4].spriteGroup.SetActive(true);
            snodeList[4].spriteGroup.transform.GetChild(0).localScale=Vector3.one*0.1f;
            snodeList[4].spriteGroup.transform.GetChild(0).DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
            snodeList[4].spriteGroup.transform.GetChild(1).localScale = Vector3.one * 0.1f;
            snodeList[4].spriteGroup.transform.GetChild(1).DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce).SetDelay(0.3f);
     
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
            snodeList[5].spriteGroup.SetActive(true);
            snodeList[5].spriteGroup.transform.GetChild(0).position = snodeList[5].spriteGroup.transform.GetChild(0).position - Vector3.up * 15f;
            snodeList[5].spriteGroup.transform.GetChild(0).DOMoveY(15f, 0.5f).SetRelative();
            snodeList[5].spriteGroup.transform.GetChild(1).position = snodeList[5].spriteGroup.transform.GetChild(1).position - Vector3.up * 15f;
            snodeList[5].spriteGroup.transform.GetChild(1).DOMoveY(15f, 0.5f).SetRelative().SetDelay(0.3f);
            snodeList[5].spriteGroup.transform.GetChild(2).position = snodeList[5].spriteGroup.transform.GetChild(2).position - Vector3.up * 15f;
            snodeList[5].spriteGroup.transform.GetChild(2).DOMoveY(15f, 0.5f).SetRelative().SetDelay(0.5f);
            GameManager.PushTarget(snodeList[6]);
            GameManager.PushTarget(snodeList[7]);
        }
    }
}