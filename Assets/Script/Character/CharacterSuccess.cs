using UnityEngine;

public class CharacterSuccess : MonoBehaviour
{
    private Animator animator;
    private static readonly int ActionIndex = Animator.StringToHash("ActionIndex");
    private static readonly int SuccessTrigger = Animator.StringToHash("Success");

    public CharacterSuccess(Animator _animator)
    {
        this.animator = _animator;
    }

    public void PerformAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, 3);
        animator.SetInteger("ActionIndex", randomIndex);
        animator.SetTrigger("Success");
    }
}
