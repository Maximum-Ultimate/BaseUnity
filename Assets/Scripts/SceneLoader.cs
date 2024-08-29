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
        StartCoroutine(waitForSFX(name));
    }

    private IEnumerator waitForSFX(string name)
    {
        SFXBtn.Play();
        yield return new WaitForSeconds(TimeSFX);
        ChangeScene(name);
    }

    public void ChangeSceneWithTransition(string name)
    {
        StartCoroutine(waitforTransition(name));
    }

    private IEnumerator waitforTransition(string name)
    {
        SFXBtn.Play();
        fc.transitionOut();
        yield return new WaitForSeconds(TimeTransition);
        GetComponent<SceneLoader>().ChangeScene(name);
    }
}
