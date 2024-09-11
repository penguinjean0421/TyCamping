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
        }

        public void OnCutActive0()
        {
            Debug.Log("따스한 햇살이 비추는 언덕");
            snodeList[0].spriteGroup.SetActive(true);
            var group = snodeList[0].spriteGroup.transform;
            group.GetChild(0).position = group.GetChild(0).position + Vector3.down * 15;
            group.GetChild(0).DOMoveY(15,0.5f).SetRelative();
            group.GetChild(1).position = group.GetChild(1).position + Vector3.down * 15;
            group.GetChild(1).DOMoveY(15, 0.5f).SetRelative().SetDelay(0.3f);
            GameManager.PushTarget(snodeList[1]);
        }
        public void OnCutActive1()
        {
            Debug.Log("한걸음 한걸음 오솔길");
            snodeList[1].spriteGroup.SetActive(true);
            var group = snodeList[1].spriteGroup.transform;
            group.GetChild(0).position = group.GetChild(0).position + Vector3.down * 10;
            group.GetChild(0).DOMoveY(10, 0.7f).SetRelative().SetEase(Ease.OutBounce);
            GameManager.PushTarget(snodeList[2]);
            GameManager.PushTarget(snodeList[3]);
        }
        public void OnCutActive2()
        {
            Debug.Log("아름다운 금수강산");
        
            snodeList[2].spriteGroup.SetActive(true);
            var group = snodeList[2].spriteGroup.transform;
            group.GetChild(0).position = group.GetChild(0).position + Vector3.left * 15;
            group.GetChild(0).DOMoveX(15, 0.5f).SetRelative();
            group.GetChild(1).position = group.GetChild(1).position + Vector3.left * 15;
            group.GetChild(1).DOMoveX(15, 0.5f).SetRelative().SetDelay(0.5f);

            GameManager.PushTarget(snodeList[4]);
            //불꽃 올라오기
        }
        public void OnCutActive3()
        {
            Debug.Log("푸른빛 가을 하늘");
            GameManager.PushTarget(snodeList[5]);
            snodeList[3].spriteGroup.SetActive(true);
            snodeList[3].spriteGroup.transform.position = snodeList[3].spriteGroup.transform.position + Vector3.up * 15f;
            snodeList[3].spriteGroup.transform.DOMoveY(-15f, 1f).SetRelative();
            snodeList[3].spriteGroup.GetComponentInChildren<SpriteRenderer>().color = new Vector4();
            snodeList[3].spriteGroup.GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 1f);
        }


        public void OnCutActive4()
        {
            Debug.Log("수줍은 꽃잎의 코스모스밭");
            snodeList[4].spriteGroup.SetActive(true);
            var group = snodeList[4].spriteGroup.transform;
            group.GetChild(2).DOScaleX(0,1.0f);
            group.GetChild(0).position = group.GetChild(0).position + Vector3.down * 15;
            group.GetChild(0).DOMoveY(15, 0.5f).SetRelative().SetDelay(0.7f).SetEase(Ease.OutBounce);
            group.GetChild(1).position = group.GetChild(1).position + Vector3.down * 15;
            group.GetChild(1).DOMoveY(15, 0.5f).SetRelative().SetDelay(1f).SetEase(Ease.OutBounce);
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
            var group = snodeList[5].spriteGroup.transform;
            group.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f);
            group.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f);

            cut7flag2 = true;
            if (cut7flag1)
            {
                GameManager.PushTarget(snodeList[6]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }
        }

        public void OnCutActive6()
        {
            Debug.Log("살랑살랑 향기롤운 꽃잎바람");

            snodeList[6].spriteGroup.SetActive(true);
            var group = snodeList[6].spriteGroup.transform;
            group.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f);
            group.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f).SetDelay(0.3f);
            group.GetChild(2).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(2).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f).SetDelay(0.5f);
            group.GetChild(3).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(3).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f).SetDelay(0.9f);
            GameManager.PushTarget(snodeList[7]);

        }
        public void OnCutActive7()
        {
            Debug.Log("가을에도 아름다운 청주 가덕면");

            snodeList[7].spriteGroup.SetActive(true);
            var group = snodeList[7].spriteGroup.transform;
            group.GetChild(0).transform.position = group.GetChild(0).position + Vector3.up;
            group.GetChild(0).transform.DOMoveY(-2f, 0.1f).SetRelative().SetLoops(7, LoopType.Yoyo).SetEase(Ease.InBounce);
            group.GetChild(0).transform.position = group.GetChild(0).transform.position + Vector3.right * 15;
            group.GetChild(0).transform.DOMoveX(-15f, 0.5f).SetRelative();
            group.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f).SetDelay(0.4f);
        }
    }
}
