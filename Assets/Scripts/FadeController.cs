using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
        StartCoroutine(transitionIn());
    }

    private IEnumerator transitionIn()
    {
        ri.enabled = true;
        yield return new WaitForSeconds(TimeTransition);
        ri.enabled = false;
    }

    public void transitionOut()
    {
        ri.enabled = true;
        animator.SetBool("IsFadingIn", true);
    }
}
