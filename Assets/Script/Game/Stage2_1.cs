using DG.Tweening;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Script.Game
{
    public class Stage2_1 : StageBase
    {
        private bool cut3flag = false;
        private bool cut4flag = false;
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
            //AudioManager.instance.PlayEnvirBgm(AudioManager.EnvirBgm.Stage21, true);

        }

        public void OnCutActive0()
        {
            Debug.Log("하트모양 물길은 어디에");
            snodeList[0].spriteGroup.SetActive(true);
            //바구니 내려오기
            var group = snodeList[0].spriteGroup.transform;

            group.GetChild(0).position = group.GetChild(0).position + Vector3.right*15;
            group.GetChild(0).DOMoveX(-15, 0.5f).SetRelative();
            group.GetChild(0).localScale = Vector3.right;
            group.GetChild(0).DOScale(Vector3.one, 0.7f);
            GameManager.PushTarget(snodeList[1]);
        }
        public void OnCutActive1() // n번 문장 치고 엔터
        {
            Debug.Log("옥화9경 옥화대에 있대요");
            snodeList[1].spriteGroup.SetActive(true);
            // 이펙트 플레이...
            var group = snodeList[1].spriteGroup.transform;
            //레이어 마스크
           
            group.GetChild(1).localScale=Vector3.zero;
            group.GetChild(1).DOScaleX(1, 0.5f).SetEase(Ease.OutBounce);
            group.GetChild(1).DOScaleY(1, 0.3f).SetEase(Ease.OutBounce);
            group.GetChild(2).DOScaleX(0, 1.5f).SetDelay(0.5f);
            GameManager.PushTarget(snodeList[2]);
            GameManager.PushTarget(snodeList[3]);

        }
        public void OnCutActive2()
        {
            Debug.Log("찾았따 졸졸졸 미원천");
            snodeList[2].spriteGroup.SetActive(true);
            snodeList[1].spriteGroup.transform.GetChild(0).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            var group = snodeList[2].spriteGroup.transform;
            //레이어 마스크
            group.GetChild(1).DOScaleX(0, 1.5f);
            cut3flag = true;
            if (cut4flag)
            {
                GameManager.PushTarget(snodeList[4]);
                Debug.Log("en");
            }
        }
        public void OnCutActive3()
        {
            Debug.Log("푸르른 새싹의 들판");
            snodeList[3].spriteGroup.SetActive(true);
            var group = snodeList[3].spriteGroup.transform;

            group.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(2).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f);
            group.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f).SetDelay(0.25f);
            group.GetChild(2).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f).SetDelay(0.5f);

            cut4flag = true;
            if (cut3flag)
            {
                GameManager.PushTarget(snodeList[4]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }
        }
        public void OnCutActive4()
        {
            Debug.Log("뭉게 뭉게 구름");
            snodeList[4].spriteGroup.SetActive(true);
            var group = snodeList[4].spriteGroup.transform;
            group.GetChild(0).position = group.GetChild(0).position + Vector3.one * 15;
            group.GetChild(0).DOMove(-Vector3.one * 15, 0.5f).SetRelative();
            
            group.GetChild(1).position = group.GetChild(1).position + Vector3.one * 15;
            group.GetChild(1).DOMove(-Vector3.one * 15, 1f).SetRelative().SetDelay(0.5f);
            group.GetChild(1).DORotate(new Vector3(0,0,5), 3f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
            GameManager.PushTarget(snodeList[5]);
        }

        public void OnCutActive5()
        {
            Debug.Log("높디높은 속리산 봉우리");
            var group = snodeList[5].spriteGroup.transform;
            snodeList[5].spriteGroup.SetActive(true);
            group.GetChild(0).localScale = Vector3.zero;
            group.GetChild(0).DOScale(Vector3.one, 0.7f).SetEase(Ease.InOutBounce);
        }
    }
}
