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

    public void IdleAction()
    {
        characterIdle.PerformAction();
    }

    public void SuccessAction()
    {
        characterSuccess.PerformAction();
    }

    public void FailureAction()
    {
        characterFailure.PerformAction();
    }


}
