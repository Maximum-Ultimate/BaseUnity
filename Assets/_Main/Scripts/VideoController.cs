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
    [Tooltip("Set 0 to use video's duration, set to use fixed duration.\nTesting default value is 2 Secs")]
    [SerializeField] private float fixedDuration = 0f;
    private float time = 0f;

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
            float duration = fixedDuration == 0 ? 2f : fixedDuration;
            Tween.Delay(duration, () => OnVideoEndEvent?.Invoke());
            _rawImage.color = Color.white;
        }
        else
        {
            _rawImage.color = Color.clear;
        }
    }

    private void Update()
    {
        if (_videoPlayer.isLooping && _videoPlayer.playOnAwake)
        {
            time += Time.deltaTime;
            if (time > 5 && _videoPlayer.isLooping)
            {
                time = 0;
                if (!_videoPlayer.isPlaying)
                {
                    _videoPlayer.Play();
                }
            }
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

        if (fixedDuration > 0)
        {
            Tween.Delay(fixedDuration, () => {
                videoPlayer.Stop();
            });
        }
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