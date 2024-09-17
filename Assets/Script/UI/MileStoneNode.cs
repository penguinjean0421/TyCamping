using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class MileStoneNode : MonoBehaviour
    {
        [HideInInspector]
        public RectTransform origin;
        public Image stamp;

        public void Awake()
        {
            origin = GetComponent<RectTransform>();
        }
    }
}