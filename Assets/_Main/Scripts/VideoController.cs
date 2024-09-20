using PrimeTween;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private RawImage _rawImage;

    public bool hideOnEnd = true;
    public UnityEvent OnVideoStartEvent;
    public UnityEvent OnVideoEndEvent;

    [SerializeField] private bool isTesting = false;

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _rawImage = GetComponent<RawImage>();

        _videoPlayer.loopPointReached += OnEndVideo;
        _videoPlayer.started += OnStartVideo;
        
        isTesting = _videoPlayer.clip == null;
    }

    private void OnEnable()
    {
        if (isTesting && _videoPlayer.playOnAwake)
        {
            Tween.Delay(2f, () => OnVideoEndEvent?.Invoke());
            _rawImage.color = Color.white;
        }
        else
        {
            _rawImage.color = Color.clear;
        }
    }


    public void Play()
    {
        _videoPlayer.Play();
    }

    public void Stop()
    {
        _videoPlayer.Stop();
    }

    public void Pause()
    {
        _videoPlayer.Pause();
    }

    public void OnStartVideo(VideoPlayer videoPlayer)
    {
        _rawImage.color = Color.white;
        OnVideoStartEvent?.Invoke();
    }

    public void OnEndVideo(VideoPlayer videoPlayer)
    {
        if (!_videoPlayer.isLooping && hideOnEnd)
        {
            _rawImage.color = Color.clear;
        }
        OnVideoEndEvent?.Invoke();
    }

    public void SkipTutorial()
    {
        _videoPlayer.time = _videoPlayer.length;
    }
}