using DG.Tweening;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
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
                snode.targetTextImage.gameObject.SetActive(false);
            }
        }

        public void OnCutActive0(Transform spriteGroup)
        {
            Debug.Log("따스한 햇살이 비추는 언덕");
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.down * 15;
            spriteGroup.GetChild(0).DOMoveY(15, 0.5f).SetRelative();
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.down * 15;
            spriteGroup.GetChild(1).DOMoveY(15, 0.5f).SetRelative().SetDelay(0.3f);
            GameManager.PushTarget(sequence, snodeList[1]);
        }
        public void OnCutActive1(Transform spriteGroup)
        {
            Debug.Log("한걸음 한걸음 오솔길");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.down * 10;

            sequence.Append(spriteGroup.GetChild(0).DOMoveY(10, 0.7f).SetRelative().SetEase(Ease.OutBounce));
            GameManager.PushTarget(sequence, snodeList[2]);
            GameManager.PushTarget(sequence, snodeList[3]);
        }
        public void OnCutActive2(Transform spriteGroup)
        {
            Debug.Log("아름다운 금수강산");

            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.left * 15;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.left * 15;

            sequence.Append(spriteGroup.GetChild(0).DOMoveX(15, 0.5f).SetRelative());
            sequence.Append(spriteGroup.GetChild(1).DOMoveX(15, 0.5f).SetRelative().SetDelay(0.5f));

            GameManager.PushTarget(sequence, snodeList[4]);
            //불꽃 올라오기
            sequence.Play();
        }
        public void OnCutActive3(Transform spriteGroup)
        {
            Debug.Log("푸른빛 가을 하늘");
            var sequence = DOTween.Sequence();
            snodeList[3].spriteGroup.transform.position = snodeList[3].spriteGroup.transform.position + Vector3.up * 15f;
            snodeList[3].spriteGroup.GetComponentInChildren<SpriteRenderer>().color = new Vector4();
            sequence.Append(snodeList[3].spriteGroup.transform.DOMoveY(-15f, 1f).SetRelative());
            sequence.Append(snodeList[3].spriteGroup.GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 1f));
            sequence.Play();
        }


        public void OnCutActive4(Transform spriteGroup)
        {
            Debug.Log("수줍은 꽃잎의 코스모스밭");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.down * 15;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.down * 15;
            sequence.Append(spriteGroup.GetChild(2).DOScaleX(0, 1.0f));
            sequence.Append(spriteGroup.GetChild(0).DOMoveY(15, 0.5f).SetRelative().SetDelay(0.7f).SetEase(Ease.OutBounce));
            sequence.Append(spriteGroup.GetChild(1).DOMoveY(15, 0.5f).SetRelative().SetDelay(1f).SetEase(Ease.OutBounce));
            cut7flag1 = true;
            if (cut7flag2)
            {
                GameManager.PushTarget(sequence, snodeList[6]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }
            sequence.Play();
        }

        public void OnCutActive5(Transform spriteGroup)
        {
            Debug.Log("윙윙 빨간 고추잠자리");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            sequence.Append(spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f));
            sequence.Append(spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f));

            cut7flag2 = true;
            if (cut7flag1)
            {
                GameManager.PushTarget(sequence, snodeList[6]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }
            sequence.Play();
        }

        public void OnCutActive6(Transform spriteGroup)
        {
            Debug.Log("살랑살랑 향기롤운 꽃잎바람");

            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(2).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(3).GetComponent<SpriteRenderer>().color = new Vector4();

            sequence.Append(spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f));
            sequence.Append(spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f).SetDelay(0.3f));
            sequence.Append(spriteGroup.GetChild(2).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f).SetDelay(0.5f));
            sequence.Append(spriteGroup.GetChild(3).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f).SetDelay(0.9f));
            GameManager.PushTarget(sequence, snodeList[7]);
            sequence.Play();

        }
        public void OnCutActive7(Transform spriteGroup)
        {
            Debug.Log("가을에도 아름다운 청주 가덕면");
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).transform.position = spriteGroup.GetChild(0).position + Vector3.up;
            spriteGroup.GetChild(0).transform.position = spriteGroup.GetChild(0).transform.position + Vector3.right * 15;
            spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();

            sequence.Append(spriteGroup.GetChild(0).transform.DOMoveY(-2f, 0.1f).SetRelative().SetLoops(7, LoopType.Yoyo).SetEase(Ease.InBounce));
            sequence.Append(spriteGroup.GetChild(0).transform.DOMoveX(-15f, 0.5f).SetRelative());
            sequence.Append(spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f).SetDelay(0.4f));
            sequence.Play();
        }
    }
}
