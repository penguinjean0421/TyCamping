using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Pointer 관련 인터페이스 사용을 위해 필요

public class ButtonImageSwap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite normalImage;
    [SerializeField] private Sprite pressedImage;

    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = normalImage; // 처음에는 기본 이미지로 설정
    }

    // 버튼이 클릭(누른) 상태일 때 이미지 변경
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = pressedImage;
    }

    // 버튼을 눌렀다가 뗄 때 기본 이미지로 돌아옴
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = normalImage;
    }
}
