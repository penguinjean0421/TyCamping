using DG.Tweening;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Game
{
    public class Stage1_2 : StageBase
    {
        private bool cut6flag1 = false;
        private bool cut6flag2 = false;

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

            foreach (var snode in snodeList)
            {
                snode.spriteGroup.SetActive(false);
                snode.targetTextImage.gameObject.SetActive(false);
            }
        }

        public void OnCutActive0(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.down * 15;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.down * 15;
            spriteGroup.GetChild(2).position = spriteGroup.GetChild(2).position + Vector3.down * 15;
            spriteGroup.GetChild(3).position = spriteGroup.GetChild(3).position + Vector3.down * 15;

            sequence.Append(spriteGroup.GetChild(0).DOMoveY(15, 0.5f).SetRelative());
            sequence.Append(spriteGroup.GetChild(1).DOMoveY(15, 0.5f).SetRelative());
            sequence.Append(spriteGroup.GetChild(2).DOMoveY(15, 0.5f).SetRelative());
            sequence.Append(spriteGroup.GetChild(3).DOMoveY(15, 0.5f).SetRelative());
          


            GameManager.PushTarget(sequence, snodeList[1]);
            sequence.Play();
        }
        public void OnCutActive1(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.left * 15;
            spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();

            sequence.Append(spriteGroup.GetChild(0).DOMoveX(15, 0.5f).SetRelative());
            sequence.Append(spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f));

            GameManager.PushTarget(sequence, snodeList[2]);
            GameManager.PushTarget(sequence, snodeList[3]);
            sequence.Play();
        }
        public void OnCutActive2(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.down * 5;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.down * 5;
            spriteGroup.GetChild(0).localScale = Vector3.zero;
            spriteGroup.GetChild(1).localScale = Vector3.zero;

            sequence.Append(spriteGroup.GetChild(0).DOMoveY(5, 0.5f).SetRelative());
            sequence.Join(spriteGroup.GetChild(0).DOScale(1, 0.5f).SetRelative());
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(0).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.05f)
                    .SetLoops(int.MaxValue);
                spriteGroup.GetChild(0).DOShakeScale(3.5f, 0.01f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });

            sequence.Append(spriteGroup.GetChild(1).DOMoveY(5, 0.5f).SetRelative().SetDelay(0.2f));
            sequence.Join(spriteGroup.GetChild(1).DOScale(1, 0.5f).SetRelative().SetDelay(0.2f));
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(1).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.05f)
                    .SetLoops(int.MaxValue);
                spriteGroup.GetChild(1).DOShakeScale(3.5f, 0.01f, 1).SetLoops(int.MaxValue, LoopType.Yoyo);
            });
            GameManager.PushTarget(sequence, snodeList[4]);
            sequence.Play();
        }
        public void OnCutActive3(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.down * 15;
            sequence.Append(spriteGroup.GetChild(0).DOMoveY(15, 1f).SetRelative().SetEase(Ease.InOutCirc));
            sequence.Join(spriteGroup.GetChild(0).DOShakeScale(1.2f));
            GameManager.PushTarget(sequence, snodeList[5]);
            sequence.Play();
        }
        public void OnCutActive4(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.left * 15;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.left * 15;
            sequence.Append(spriteGroup.GetChild(0).DOMoveX(15, 1).SetRelative());
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(0).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.02f)
                    .SetLoops(int.MaxValue);
            });
            sequence.Append(spriteGroup.GetChild(1).DOMoveX(15, 1).SetRelative());
            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(1).DOSpiral(4.2f, Vector3.forward, SpiralMode.ExpandThenContract, 0.03f)
                    .SetLoops(int.MaxValue);
            });

            cut6flag1 = true;
            if (cut6flag2)
            {
                GameManager.PushTarget(sequence, snodeList[6]);
            }
            sequence.Play();
        }

        public void OnCutActive5(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(2).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(3).GetComponent<SpriteRenderer>().color = new Vector4();
            sequence.Append(spriteGroup.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f));
            sequence.Append(spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f));
            sequence.Append(spriteGroup.GetChild(2).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f));
            sequence.Append(spriteGroup.GetChild(3).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f));
            cut6flag2 = true;
            if (cut6flag1)
            {
                GameManager.PushTarget(sequence, snodeList[6]);
            }
            sequence.Play();
        }

        public void OnCutActive6(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();

            spriteGroup.GetChild(0).localScale = Vector3.zero;

            sequence.Append(spriteGroup.GetChild(0).DOScale(1, 0.5f).SetRelative().SetEase(Ease.OutElastic));
            GameManager.PushTarget(sequence, snodeList[7]);
            sequence.Play();
        }
        public void OnCutActive7(Transform spriteGroup)
        {
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.left * 15;
            sequence.Append(spriteGroup.GetChild(0).DOMoveX(15, 0.5f).SetRelative().SetEase(Ease.OutBack));
            sequence.Play();
        }
    }
}