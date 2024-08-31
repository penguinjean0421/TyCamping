using UnityEngine;

public class AnimTest : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void ResetAnimation()
    {
        anim.SetBool("isSuccess", false);
        anim.SetBool("isFailure", false);
    }

    private void Success()
    {
        ResetAnimation();
        anim.SetBool("isSuccess", true);
    }
}
