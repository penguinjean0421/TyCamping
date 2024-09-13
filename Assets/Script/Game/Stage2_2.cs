using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Core.PathCore;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Game
{
#if UNITY_EDITOR
    [CustomEditor(typeof(Stage2_2))]
    public class Stage2_2Inspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var stage = (Stage2_2)target;
            if (GUILayout.Button("Register All Path"))
            {
                stage.dragonFly1Path = new List<Transform>();
                stage.dragonFly2Path = new List<Transform>();
                foreach (var child in stage.dragonFly1PathParent.GetComponentsInChildren<Transform>())
                {
                    if (child != stage.dragonFly1PathParent)
                    {
                        stage.dragonFly1Path.Add(child);
                    }
                }
                foreach (var child in stage.dragonFly2PathParent.GetComponentsInChildren<Transform>())
                {
                    if (child != stage.dragonFly2PathParent)
                    {
                        stage.dragonFly2Path.Add(child);
                    }
                }
            }

        }



    }
#endif



    public class Stage2_2 : StageBase
    {
        private bool cut7flag1 = false;
        private bool cut7flag2 = false;

        public Transform dragonFly1PathParent;
        public Transform dragonFly2PathParent;

        public List<Transform> dragonFly1Path;
        public List<Transform> dragonFly2Path;

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

            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.down * 15;
            sequence.Append(spriteGroup.GetChild(0).DOMoveY(15, 1).SetRelative().SetEase(Ease.OutQuart));
            sequence.Append(spriteGroup.GetChild(1).DOMoveY(15, 1).SetRelative().SetEase(Ease.OutQuart));
            GameManager.PushTarget(sequence, snodeList[1]);
        }

        public void OnCutActive1(Transform spriteGroup)
        {
            Debug.Log("한걸음 한걸음 오솔길");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.down * 10;

            sequence.Append(spriteGroup.GetChild(0).DOMoveY(10, 0.7f).SetRelative().SetEase(Ease.OutQuart));
            GameManager.PushTarget(sequence, snodeList[2]);
            GameManager.PushTarget(sequence, snodeList[3]);
        }

        public void OnCutActive2(Transform spriteGroup)
        {
            Debug.Log("아름다운 금수강산");

            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.left * 15;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.left * 15;

            sequence.Append(spriteGroup.GetChild(0).DOMoveX(15, 1).SetRelative().SetEase(Ease.OutBack));
            //sequence.Join(spriteGroup.GetChild(0).DOShakeScale(1.2f, 0.1f));
            sequence.Append(spriteGroup.GetChild(1).DOMoveX(15, 1).SetRelative());
            //sequence.Join(spriteGroup.GetChild(1).DOShakeScale(1.2f, 0.1f));

            GameManager.PushTarget(sequence, snodeList[4]);
            //불꽃 올라오기
            sequence.Play();
        }

        public void OnCutActive3(Transform spriteGroup)
        {
            Debug.Log("푸른빛 가을 하늘");
            var sequence = DOTween.Sequence();
            snodeList[3].spriteGroup.transform.position =
                snodeList[3].spriteGroup.transform.position + Vector3.up * 15f;
            snodeList[3].spriteGroup.GetComponentInChildren<SpriteRenderer>().color = new Vector4();
            sequence.Append(snodeList[3].spriteGroup.transform.DOMoveY(-15f, 1f).SetRelative());
            sequence.Append(snodeList[3].spriteGroup.GetComponentInChildren<SpriteRenderer>().DOColor(Color.white, 1f));
            GameManager.PushTarget(sequence, snodeList[5]); // 캠핑
            sequence.Play();
        }


        public void OnCutActive4(Transform spriteGroup)
        {
            Debug.Log("수줍은 꽃잎의 코스모스밭");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).position = spriteGroup.GetChild(0).position + Vector3.down * 5;
            spriteGroup.GetChild(1).position = spriteGroup.GetChild(1).position + Vector3.down * 5;
            sequence.Append(spriteGroup.GetChild(2).DOMoveX(15, 1.0f).SetRelative());
            sequence.Append(spriteGroup.GetChild(0).DOMoveY(5, 0.5f).SetRelative().SetEase(Ease.OutElastic));
            sequence.JoinCallback(() =>
            {
                spriteGroup.GetChild(0).DOShakeRotation(2.0f, 10, 1).SetLoops(Int32.MaxValue, LoopType.Yoyo);
            });
            sequence.Append(spriteGroup.GetChild(1).DOMoveY(5, 0.5f).SetRelative().SetEase(Ease.OutElastic));
            sequence.JoinCallback(() =>
            {
                spriteGroup.GetChild(1).DOShakeRotation(2.0f, 10, 1).SetLoops(Int32.MaxValue, LoopType.Yoyo);
            });
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
            Vector3[] path1 = new Vector3[dragonFly1Path.Count];
            Vector3[] path2 = new Vector3[dragonFly2Path.Count];
            for (int i = 0; i < dragonFly1Path.Count; i++)
            {
                path1[i] = dragonFly1Path[i].position;
            }

            for (int i = 0; i < dragonFly2Path.Count; i++)
            {
                path2[i] = dragonFly2Path[i].position;
            }

            sequence.Append(spriteGroup.GetChild(0).DOPath(path1, 5, PathType.CatmullRom));
            sequence.Join(spriteGroup.GetChild(1).DOPath(path2, 5, PathType.CatmullRom));


            sequence.AppendCallback(() =>
            {
                spriteGroup.GetChild(0).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.1f)
                    .SetLoops(Int32.MaxValue);
                spriteGroup.GetChild(1).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.1f)
                    .SetLoops(Int32.MaxValue);
            });


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
            sequence.JoinCallback(() =>
            {
                spriteGroup.GetChild(0).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.1f)
                    .SetLoops(Int32.MaxValue);
            });

            sequence.Append(spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f));
            sequence.JoinCallback(() =>
            {
                spriteGroup.GetChild(1).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.1f)
                    .SetLoops(Int32.MaxValue);
            });
            sequence.Append(spriteGroup.GetChild(2).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f));
            sequence.JoinCallback(() =>
            {
                spriteGroup.GetChild(2).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.1f)
                    .SetLoops(Int32.MaxValue);
            });
            sequence.Append(spriteGroup.GetChild(3).GetComponent<SpriteRenderer>().DOColor(Color.white, 1f));
            sequence.JoinCallback(() =>
            {
                spriteGroup.GetChild(3).DOSpiral(3, Vector3.forward, SpiralMode.ExpandThenContract, 0.1f)
                    .SetLoops(Int32.MaxValue);
            });
            GameManager.PushTarget(sequence, snodeList[7]);
            sequence.Play();

        }

        public void OnCutActive7(Transform spriteGroup)
        {
            Debug.Log("가을에도 아름다운 청주 가덕면");
            var sequence = DOTween.Sequence();
            spriteGroup.GetChild(0).transform.position =
                spriteGroup.GetChild(0).transform.position + Vector3.right * 15;
            spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            spriteGroup.GetChild(1).localScale = Vector3.zero;

            sequence.Append(spriteGroup.GetChild(0).transform.DOJump(Vector3.left * 15, 1.0f, 7, 1).SetRelative());
            sequence.AppendInterval(1.0f);
            sequence.Append(spriteGroup.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 2));
            sequence.Join(spriteGroup.GetChild(1).DOScale(1, 2).SetEase(Ease.OutElastic));
            sequence.Play();
        }

        public void OnDrawGizmos()
        {

            if (dragonFly1Path.Count > 1)
            {
                Gizmos.color = Color.blue;
                for (int i = 1; i < dragonFly1Path.Count; i++)
                {
                    Gizmos.DrawLine(dragonFly1Path[i - 1].position, dragonFly1Path[i].position);
                }
            }

            if (dragonFly2Path.Count > 1)
            {
                Gizmos.color = Color.yellow;
                for (int i = 1; i < dragonFly2Path.Count; i++)
                {
                    Gizmos.DrawLine(dragonFly2Path[i - 1].position, dragonFly2Path[i].position);
                }
            }
        }
    }
}
