using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class ButtonAnimator : MonoBehaviour
{
    private Button myButton;

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private string sceneNameToLoad;

    private void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Tween.Scale(myButton.transform, endValue: Vector3.one * 1.1f, duration: 0.1f)
            .OnComplete(() =>
            {
                Tween.Scale(myButton.transform, endValue: Vector3.one, duration: 0.1f)
                    .OnComplete(() =>
                    {
                        sceneLoader.ChangeSceneWithTransition(sceneNameToLoad);
                    });
            });
    }
}
