using UnityEngine;
using UnityEngine.UI;
using PrimeTween;
using TMPro;

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

        Tween.Delay(TimeTransition, () =>
        {
            ri.enabled = false;
        });
    }

    public void transitionOut()
    {
        ri.enabled = true;
        animator.SetBool("IsFadingIn", true);
    }

    public void ChangeTextVisibility(TMP_Text txt, bool isVisible, float duration)
    {
        // Get the current alpha of the text color
        float startAlpha = txt.color.a;
        float endAlpha = isVisible ? 0f : 1f;

        Tween.Custom(
            target: txt,
            startValue: startAlpha,
            endValue: endAlpha,
            duration: duration,
            onValueChange: (txt, newAlpha) =>
            {
                Color c = txt.color;
                c.a = newAlpha;
                txt.color = c;
            },
            ease: Ease.InOutSine
        );
    }
}
