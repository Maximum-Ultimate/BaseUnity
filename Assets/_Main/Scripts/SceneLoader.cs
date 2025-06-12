using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private FadeController fc;
    [SerializeField] private AudioSource SFXBtn;

    private const float TimeSFX = 0.25f;
    private const float TimeTransition = 1f;

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ChangeSceneWithSFX(string name)
    {
        SFXBtn.Play();
        Tween.Delay(TimeTransition, () => {
            ChangeScene(name);
        });
    }

    public void ChangeSceneWithTransition(string name)
    {
        SFXBtn.Play();
        fc.transitionOut();
        Tween.Delay(TimeTransition, () => {
            GetComponent<SceneLoader>().ChangeScene(name);
        });
    }
}
