using UnityEngine;

public class CharacterTest : MonoBehaviour
{
    private CharacterManager characterManager;

    private void Start()
    {
        // CharacterManager 컴포넌트를 가져옵니다.
        characterManager = GetComponent<CharacterManager>();

        if (characterManager == null)
        {
            Debug.LogError("CharacterManager가 이 오브젝트에 연결되어 있지 않습니다.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // a 키를 눌렀을 때 Success 애니메이션 플레이
            characterManager.SuccessAction();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // s 키를 눌렀을 때 Failure 애니메이션 플레이
            characterManager.FailureAction();
        }
    }
}
