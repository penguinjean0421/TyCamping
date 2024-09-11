using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private CharacterIdle       characterIdle;
    private CharacterSuccess    characterSuccess;
    private CharacterFailure    characterFailure;

    private void Start()
    {
        Animator animator = GetComponent<Animator>();

        characterIdle = new CharacterIdle(animator);
        characterSuccess = new CharacterSuccess(animator);
        characterFailure = new CharacterFailure(animator);
    }

    private void Update()
    {
        
    }

    public void IdleAction()
    {
        Debug.Log("CharacterIdleAction!!");
        characterIdle.PerformAction();
    }

    public void SuccessAction()
    {
        Debug.Log("CharacterSuccessAction!!");
        characterSuccess.PerformAction();
    }

    public void FailureAction()
    {
        Debug.Log("CharacterFailureAction!!");
        characterFailure.PerformAction();
    }


}
