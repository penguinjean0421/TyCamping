using Default.Scripts.Sound;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;
using Vector3 = UnityEngine.Vector3;

namespace Assets.Script.Game
{
    public class Stage1_1 : StageBase
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

            foreach (var snode in snodeList)
            {
                snode.spriteGroup.SetActive(false);
                snode.targetTextImage.gameObject.SetActive(false);
            }
            SoundManager.Play("Stage1", 1);
            SoundManager.Play("Stage11", 2);
        }

        public void OnCutActive0(Transform spriteGroup)
        {
            //돗자리
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).localScale = Vector3.zero;
            spriteGroup.GetChild(1).localScale = Vector3.zero;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.up * 2;

            sequence.Append(spriteGroup.GetChild(0).DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack));
            sequence.Append(spriteGroup.GetChild(1).DOScale(Vector3.one, 1.0f).SetEase(Ease.OutElastic));
            sequence.Join(spriteGroup.GetChild(1).DOMoveY(-2, 1.0f).SetEase(Ease.OutBounce).SetRelative().SetDelay(0.5f));

            GameManager.PushTarget(sequence, snodeList[1]);
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }
        public void OnCutActive1(Transform spriteGroup)
        {
            //모닥불
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).localScale = Vector3.zero;
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.up * 0.5f;
            spriteGroup.GetChild(1).localScale = Vector3.zero;

            sequence.Append(spriteGroup.GetChild(0).DOScale(Vector3.one, 1f).SetEase(Ease.OutExpo));
            sequence.Join(spriteGroup.GetChild(0).DOMoveY(-0.5f, 1f).SetRelative().SetEase(Ease.InBack));

            sequence.Append(spriteGroup.GetChild(1).DOScale(Vector3.one, 1f).SetEase(Ease.InQuint));
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(1).DOShakeRotation(0.5f, 10, 1).SetLoops(int.MaxValue, LoopType.Yoyo)
                    .SetEase(Ease.InBack);
                spriteGroup.GetChild(1).DOShakeScale(1f, 0.1f, 1).SetLoops(int.MaxValue, LoopType.Yoyo)
                    .SetEase(Ease.InBack);
            });
            GameManager.PushTarget(sequence, snodeList[3]);
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }
        public void OnCutActive2(Transform spriteGroup)
        {
            //Debug.Log("맑은 한낮의 하늘");
            var sequence = DOTween.Sequence();
            spriteGroup.position = spriteGroup.position + Vector3.up * 15f;
            spriteGroup.GetComponentInChildren<SpriteRenderer>().color = new Vector4();

            sequence.Append(spriteGroup.DOMoveY(-15f, 1f).SetRelative());
            sequence.Join(spriteGroup.GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 0.5f));

            GameManager.PushTarget(sequence, snodeList[4]);
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }
        public void OnCutActive3(Transform spriteGroup)
        {
            //Debug.Log("푸르른 새싹의 들판");
            var sequence = DOTween.Sequence();
            sequence.Append(spriteGroup.GetChild(1).DOMoveX(15f, 1f).SetRelative());
            GameManager.PushTarget(sequence, snodeList[2]);
            GameManager.PushTarget(sequence, snodeList[5]);
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }
        public void OnCutActive4(Transform spriteGroup)
        {
            //Debug.Log("뭉게 뭉게 구름");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).localScale = Vector3.zero;
            spriteGroup.GetChild(1).localScale = Vector3.zero;
            sequence.Append(spriteGroup.GetChild(0).DOScale(Vector3.one, 1).SetEase(Ease.OutElastic));
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(0).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.05f)
                    .SetLoops(int.MaxValue);
                spriteGroup.GetChild(0).DOShakeScale(3, 0.05f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });
            sequence.Append(spriteGroup.GetChild(1).DOScale(Vector3.one, 1).SetEase(Ease.OutElastic));
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(1).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.05f)
                    .SetLoops(int.MaxValue);
                spriteGroup.GetChild(1).DOShakeScale(3, 0.05f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });
            cut9flag2 = true;
            if (cut9flag1)
            {
                GameManager.PushTarget(sequence, snodeList[9]); // 캠핑
                Debug.Log("우리가족의 첫 캠핑");
            }
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }

        public void OnCutActive5(Transform spriteGroup)
        {
            //Debug.Log("높디높은 속리산 봉우리");
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position - Vector3.up * 15f;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position - Vector3.up * 15f;
            spriteGroup.GetChild(2).position = spriteGroup.GetChild(2).position - Vector3.up * 15f;

            sequence.Append(spriteGroup.GetChild(0).DOMoveY(15f, 1).SetRelative());
            sequence.Join(spriteGroup.GetChild(0).DOShakeScale(1.2f));
            sequence.Append(spriteGroup.GetChild(1).DOMoveY(15f, 1).SetRelative());
            sequence.Join(spriteGroup.GetChild(1).DOShakeScale(1.2f));
            sequence.Append(spriteGroup.GetChild(2).DOMoveY(15f, 1).SetRelative());
            sequence.Join(spriteGroup.GetChild(2).DOShakeScale(1.2f));
            GameManager.PushTarget(sequence, snodeList[6]);
            GameManager.PushTarget(sequence, snodeList[7]);
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }

        public void OnCutActive6(Transform spriteGroup)
        {
            //Debug.Log("울창한 푸른 소나무");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position - Vector3.up * 15f;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position - Vector3.up * 15f;
            spriteGroup.GetChild(2).localScale = Vector3.zero;
            spriteGroup.GetChild(3).localScale = Vector3.zero;

            sequence.Append(spriteGroup.GetChild(0).DOMoveY(15f, 1).SetRelative());
            sequence.Join(spriteGroup.GetChild(0).DOShakeScale(1.0f));
            sequence.Append(spriteGroup.GetChild(1).DOMoveY(15f, 1).SetRelative());
            sequence.Join(spriteGroup.GetChild(1).DOShakeScale(1.0f));

            sequence.Append(spriteGroup.GetChild(2).DOScale(Vector3.one, 1).SetRelative().SetEase(Ease.OutBack));
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(2).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.01f)
                    .SetLoops(int.MaxValue);
                spriteGroup.GetChild(2).DOShakeScale(3.5f, 0.01f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
                spriteGroup.GetChild(0).DOShakeRotation(3.5f, 1, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });
            sequence.Append(spriteGroup.GetChild(3).DOScale(Vector3.one, 1).SetRelative().SetEase(Ease.OutBack));
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(3).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.01f)
                    .SetLoops(int.MaxValue);
                spriteGroup.GetChild(3).DOShakeScale(3.5f, 0.01f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
                spriteGroup.GetChild(1).DOShakeRotation(3.5f, 1, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });
            cut8flag1 = true;
            if (cut8flag2)
            {
                GameManager.PushTarget(sequence, snodeList[8]);
            }
            sequence.Play();
            SoundManager.Play("Animation", 0);

        }
        public void OnCutActive7(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position - Vector3.up * 15f;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position - Vector3.up * 15f;

            sequence.Append(spriteGroup.GetChild(0).DOMoveY(15f, 1).SetRelative());
            sequence.Join(spriteGroup.GetChild(0).DOShakeScale(1.2f));
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(0).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.01f)
                    .SetLoops(int.MaxValue);
                spriteGroup.GetChild(0).DOShakeScale(3.5f, 0.01f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });
            sequence.Append(spriteGroup.GetChild(1).DOMoveY(15f, 1).SetRelative());
            sequence.Join(spriteGroup.GetChild(1).DOShakeScale(1.2f));
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(1).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.01f)
                    .SetLoops(int.MaxValue);
                spriteGroup.GetChild(1).DOShakeScale(3.5f, 0.01f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });


            cut8flag2 = true;
            if (cut8flag1)
            {
                GameManager.PushTarget(sequence, snodeList[8]);
            }
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }

        public void OnCutActive8(Transform spriteGroup)
        {
            //Debug.Log("깜찍하고 귀여운 흰토끼");
            var sequence = DOTween.Sequence();
            spriteGroup.position = spriteGroup.position + Vector3.right * 3;


            sequence.Append(spriteGroup.DOJump(spriteGroup.position-Vector3.right*3,1,4,1.0f));
            sequence.AppendCallback(() =>
            {
                spriteGroup.DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.01f)
                    .SetLoops(int.MaxValue);
                spriteGroup.DOShakeScale(3.5f, 0.01f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });

            cut9flag1 = true;
            if (cut9flag2)
            {
                GameManager.PushTarget(sequence, snodeList[9]);
            }
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }

        public void OnCutActive9(Transform spriteGroup)
        {
            //Debug.Log("우리가족의 첫 캠핑");
            var sequence = DOTween.Sequence();
            spriteGroup.transform.GetChild(0).localScale = new Vector3(0.5f, 0.1f, 0f);
            spriteGroup.transform.GetChild(0).position = spriteGroup.GetChild(0).position - Vector3.up * 0.5f;
            sequence.Append(spriteGroup.transform.GetChild(0).DOScale(Vector3.one, 0.5f));
            sequence.Join(spriteGroup.transform.GetChild(0).DOMoveY(0.5f, 0.5f).SetRelative());
            sequence.Play();
            SoundManager.Play("Animation", 0);
        }
    }
}