using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

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
                snode.hint.gameObject.SetActive(false);
            }


        }

        public void OnCutActive0()
        {

            snodeList[0].spriteGroup.SetActive(true);
            var group = snodeList[0].spriteGroup.transform;
       
            group.GetChild(0).position = group.GetChild(0).position + Vector3.down * 15;
            group.GetChild(1).position = group.GetChild(1).position + Vector3.down * 15;
            group.GetChild(2).position = group.GetChild(2).position + Vector3.down * 15;
            group.GetChild(3).position = group.GetChild(3).position + Vector3.down * 15;
            group.GetChild(0).DOMoveY(15, 0.5f).SetRelative();
            group.GetChild(1).DOMoveY(15, 0.5f).SetRelative().SetDelay(0.2f);
            group.GetChild(2).DOMoveY(15, 0.5f).SetRelative().SetDelay(0.4f);
            group.GetChild(3).DOMoveY(15, 0.5f).SetRelative().SetDelay(0.6f);

            GameManager.PushTarget(snodeList[1]);
        }
        public void OnCutActive1()
        {
            snodeList[1].spriteGroup.SetActive(true);
            var group = snodeList[1].spriteGroup.transform;
            group.GetChild(0).position = group.GetChild(0).position + Vector3.left * 15;
            group.GetChild(0).DOMoveX(15, 0.5f).SetRelative();
            group.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f);
            GameManager.PushTarget(snodeList[2]);
            GameManager.PushTarget(snodeList[3]);
        }
        public void OnCutActive2()
        {
            snodeList[2].spriteGroup.SetActive(true);
            var group = snodeList[2].spriteGroup.transform;
            group.GetChild(0).position = group.GetChild(0).position + Vector3.down * 5;
            group.GetChild(1).position = group.GetChild(1).position + Vector3.down * 5;
            group.GetChild(0).DOMoveY(5, 0.5f).SetRelative();
            group.GetChild(1).DOMoveY(5, 0.5f).SetRelative().SetDelay(0.2f);
            group.GetChild(0).localScale = Vector3.zero;
            group.GetChild(1).localScale = Vector3.zero;
            group.GetChild(0).DOScale(1, 0.5f).SetRelative();
            group.GetChild(1).DOScale(1, 0.5f).SetRelative().SetDelay(0.2f);
            GameManager.PushTarget(snodeList[4]);
        }
        public void OnCutActive3()
        {
            snodeList[3].spriteGroup.SetActive(true);
            var group = snodeList[3].spriteGroup.transform;

            group.GetChild(0).position = group.GetChild(0).position + Vector3.down * 15;
            group.GetChild(0).DOMoveY(15, 0.5f).SetRelative();
            GameManager.PushTarget(snodeList[5]);
        }
        public void OnCutActive4()
        {
            snodeList[4].spriteGroup.SetActive(true);
            var group = snodeList[4].spriteGroup.transform;
            group.GetChild(0).position = group.GetChild(0).position + Vector3.left * 15;
            group.GetChild(0).DOMoveX(15, 0.5f).SetRelative();
            cut6flag1 = true;
            if (cut6flag2)
            {
                GameManager.PushTarget(snodeList[6]);
            }
        }

        public void OnCutActive5()
        {
            snodeList[5].spriteGroup.SetActive(true);
            var group = snodeList[5].spriteGroup.transform;
            group.GetChild(0).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(1).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(2).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(3).GetComponent<SpriteRenderer>().color = new Vector4();
            group.GetChild(0).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f);
            group.GetChild(1).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f).SetDelay(0.2f);
            group.GetChild(2).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f).SetDelay(0.4f);
            group.GetChild(3).GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f).SetDelay(0.6f);
            cut6flag2 = true;
            if (cut6flag1)
            {
                GameManager.PushTarget(snodeList[6]);
            }
        }

        public void OnCutActive6()
        {
            snodeList[6].spriteGroup.SetActive(true);
            var group = snodeList[6].spriteGroup.transform;
            group.GetChild(0).localScale = Vector3.zero;
            group.GetChild(0).DOScale(1, 0.5f).SetRelative().SetEase(Ease.OutBounce);
            GameManager.PushTarget(snodeList[7]);
        }
        public void OnCutActive7()
        {
            snodeList[7].spriteGroup.SetActive(true);
            var group = snodeList[7].spriteGroup.transform;
            group.GetChild(0).position = group.GetChild(0).position + Vector3.left * 15;
            group.GetChild(0).DOMoveX(15, 0.5f).SetRelative();
        }
    }
}