using UnityEngine;
using PrimeTween;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject Window;
    [SerializeField] private GameObject RIOverlay;
    [SerializeField] private GameObject GOScale;

    private bool _isOpened = false;
    private bool _isVisible;

    void Start()
    {
        // Tween.Scale
        // (
        //     GOScale.transform,
        //     endValue: 0.001f,
        //     duration: 2,
        //     endDelay: 0.5f
        // );
    }

    public void SetWindowOpened()
    {
        _isOpened = !_isOpened;

        ToggleFade(RIOverlay);

        Tween.UIAnchoredPositionX(
            Window.GetComponent<RectTransform>(),
            endValue: _isOpened ? 0 : -1080,
            duration: 1f,
            ease: Ease.InOutSine
        );
    }

    private void ToggleFade(GameObject targetGO)
    {
        var image = targetGO.GetComponent<RawImage>();
        float startAlpha = image.color.a;
        float endAlpha = _isVisible ? 0f : 0.75f;

        _isVisible = !_isVisible;

        Tween.Custom(
            target: image,
            startValue: startAlpha,
            endValue: endAlpha,
            duration: 1f,
            onValueChange: (img, newAlpha) =>
            {
                Color c = img.color;
                c.a = newAlpha;
                img.color = c;
            },
            ease: Ease.InOutSine
        );
    }
}
