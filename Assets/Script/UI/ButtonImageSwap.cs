using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageSwap : MonoBehaviour
{
    [SerializeField] private Sprite normalImage;
    [SerializeField] private Sprite pressedImage;

    private Image buttonImage;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        button.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(button.GetComponent<RectTransform>(), Input.mousePosition, null))
        {
            buttonImage.sprite = pressedImage;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            buttonImage.sprite = normalImage;
        }
    }


    public void OnButtonClick()
    {
        buttonImage.sprite = pressedImage;
    }

    public void OnButtonRelease()
    {
        buttonImage.sprite = normalImage;
    }

    
}
