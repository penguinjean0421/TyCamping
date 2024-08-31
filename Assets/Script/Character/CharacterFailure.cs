using UnityEngine;

public class CharacterFailure : MonoBehaviour
{
    private Animator animator;
    private static readonly int ActionIndex = Animator.StringToHash("ActionIndex");
    private static readonly int SuccessTrigger = Animator.StringToHash("Failure");

    public CharacterFailure(Animator _animator)
    {
        this.animator = _animator;
    }

    public void PerformAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, 3);
        animator.SetInteger("ActionIndex", randomIndex);
        animator.SetTrigger("Failure");
    }
}
