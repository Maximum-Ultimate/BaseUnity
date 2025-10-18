using UnityEngine;
using UnityEngine.SceneManagement;
using PrimeTween;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private FadeController fc;
    [SerializeField] private AudioSource SFXBtn;
    [SerializeField] private AudioSource SFXSlide;
    [SerializeField] private AudioSource SFXScale;
    [SerializeField] private GameObject GOSlider;
    [SerializeField] private GameObject GOScale;

    private const float TimeSFX = 0.25f;
    private const float TimeTransition = 1f;

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ChangeSceneWithSFX(string name)
    {
        SFXBtn.Play();
        ChangeSceneWithDelay(name);
    }

    public void ChangeSceneWithTransition(string name)
    {
        fc.transitionOut();
        ChangeSceneWithDelay(name);
    }

    public void ChangeSceneComplete(string name)
    {
        SFXBtn.Play();
        fc.transitionOut();
        ChangeSceneWithDelay(name);
    }

    public void ChangeSceneWithDelay(string name)
    {
        Tween.Delay
        (
            this,
            duration: TimeTransition,
            target =>
            {
                target.ChangeScene(name);
            }
        );
    }

    public void ChangeSceneWithSliderSFX(string name)
    {
        SFXSlide.Play();
        SFXSlide.Play();

        Tween.LocalPositionX
        (
            GOSlider.transform,
            endValue: 0,
            duration: 2,
            ease: Ease.InOutSine
        ).OnComplete
        (
            target: this,
            target => target.GetComponent<SceneLoader>().ChangeScene(name)
        );
    }

    public void ChangeSceneWithScaleSFX(string name)
    {
        SFXBtn.Play();
        SFXScale.Play();

        Tween.Scale
        (
            GOScale.transform,
            endValue: 1,
            duration: 2,
            endDelay: 0.5f
        ).OnComplete
        (
            target: this,
            target => target.GetComponent<SceneLoader>().ChangeScene(name)
        );
    }
}
