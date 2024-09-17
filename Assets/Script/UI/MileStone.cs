using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class MileStone : MonoBehaviour
    {
        [SerializeField] private Image character;
        [SerializeField] private MileStoneNode[] nodes;
        [SerializeField] private int beginIndex;

        public void Initialize()
        {
            gameObject.SetActive(true);
            character.rectTransform.anchoredPosition = nodes[beginIndex].origin.anchoredPosition;
            for (int i = 0; i <= beginIndex - 1; i++)
            {
                if (nodes[i].stamp)
                {
                    nodes[i].stamp.gameObject.SetActive(true);
                }
            }
        }
        public Tween Animate()
        {
            return character.rectTransform.DOAnchorPos(nodes[beginIndex + 1].origin.anchoredPosition, 1);
        }
        public Tween Stamp()
        {
            if (nodes[beginIndex].stamp)
            {
                nodes[beginIndex].stamp.gameObject.SetActive(true);
                nodes[beginIndex].stamp.rectTransform.localScale = Vector3.zero;
                return nodes[beginIndex].stamp.rectTransform.DOScale(1, 1).SetEase(Ease.InOutBack);
            }

            return null;
        }
    }
}
