using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class FadeController : MonoBehaviour
{
    RawImage ri;
    Animator animator;

    private const float TimeTransition = 1f;

    void Start()
    {
        ri = GetComponent<RawImage>();
        animator = GetComponent<Animator>();

        animator.SetBool("IsFadingIn", false);

        ri.enabled = true;

        Tween.Delay(TimeTransition, () => {
            ri.enabled = false;
        });
    }

    public void transitionOut()
    {
        ri.enabled = true;
        animator.SetBool("IsFadingIn", true);
    }
}
