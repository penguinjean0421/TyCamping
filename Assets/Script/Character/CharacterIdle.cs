using System;
using UnityEngine;

public class CharacterIdle : MonoBehaviour
{
    private Animator animator;
    private static readonly int ActionIndex = Animator.StringToHash("ActionIndex");
    private static readonly int IdleTrigger = Animator.StringToHash("Idle");

    public CharacterIdle(Animator _animator)
    {
        this.animator = _animator;
    }

    public void PerformAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, 3);
        animator.SetInteger("ActionIndex", randomIndex);
        animator.SetTrigger("Idle");
    }
}
