using DG.Tweening;
using Unity.VisualScripting;
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
                snode.targetTextImage.gameObject.SetActive(false);
            }


        }

        public void OnCutActive0(Transform spriteGroup)
        {
            //Debug.Log("하트모양 물길은 어디에");
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.right*15;
            spriteGroup.GetChild(0).localScale = Vector3.right;

            sequence.Append(spriteGroup.GetChild(0).DOMoveX(-15, 0.5f).SetRelative());
            sequence.Append(spriteGroup.GetChild(0).DOScale(Vector3.one, 0.7f));

            GameManager.PushTarget(sequence, snodeList[1]);
            sequence.Play();
        }
        public void OnCutActive1(Transform spriteGroup) // n번 문장 치고 엔터
        {
            //Debug.Log("옥화9경 옥화대에 있대요");
            var sequence = DOTween.Sequence();
         
            spriteGroup.GetChild(1).localScale=Vector3.zero;

            sequence.Append(spriteGroup.GetChild(1).DOScaleX(1, 0.5f).SetEase(Ease.OutBounce));
            sequence.Append(spriteGroup.GetChild(1).DOScaleY(1, 0.3f).SetEase(Ease.OutBounce));
            
            //레이어마스크
            GameManager.PushTarget(sequence, snodeList[2]);
            GameManager.PushTarget(sequence,snodeList[3]);
            sequence.Play();
        }
        public void OnCutActive2(Transform spriteGroup)
        {
            //Debug.Log("찾았따 졸졸졸 미원천");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            //레이어마스크
            cut3flag = true;
            if (cut4flag)
            {
                GameManager.PushTarget(sequence, snodeList[4]);
                Debug.Log("en");
            }
            sequence.Play();
        }
        public void OnCutActive3(Transform spriteGroup)
        {
            //Debug.Log("푸르른 새싹의 들판");
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(2).GetComponent<SpriteRenderer>().color = new Vector4();
            sequence.Append(spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f));
            sequence.Append(spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f).SetDelay(0.25f));
            sequence.Append(spriteGroup.GetChild(2).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f).SetDelay(0.5f));

            cut4flag = true;
            if (cut3flag)
            {
                GameManager.PushTarget(sequence, snodeList[4]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }
            sequence.Play();
        }
        public void OnCutActive4(Transform spriteGroup)
        {
            //Debug.Log("뭉게 뭉게 구름");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.one * 15;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.one * 15;

            sequence.Append(spriteGroup.GetChild(0).DOMove(-Vector3.one * 15, 0.5f).SetRelative());
            sequence.Append(spriteGroup.GetChild(1).DOMove(-Vector3.one * 15, 1f).SetRelative().SetDelay(0.5f));
            sequence.Append(spriteGroup.GetChild(1).DORotate(new Vector3(0,0,5), 3f).SetLoops(int.MaxValue, LoopType.Yoyo).SetEase(Ease.Linear));
            GameManager.PushTarget(sequence, snodeList[5]);
            sequence.Play();
        }

        public void OnCutActive5(Transform spriteGroup)
        {
            //Debug.Log("높디높은 속리산 봉우리");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).localScale = Vector3.zero;
            sequence.Append(spriteGroup.GetChild(0).DOScale(Vector3.one, 0.7f).SetEase(Ease.InOutBounce));
            sequence.Play();
        }
    }
}
