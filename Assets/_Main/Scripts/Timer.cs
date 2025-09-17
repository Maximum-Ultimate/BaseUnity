using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    TMP_Text texttimer;

    [SerializeField] SceneLoader sl;
    [SerializeField] private bool IsCountdown;
    [SerializeField] private bool UseMilisecond;

    public static bool IsRunning = false;
    public static bool GameOver = false;
    public static string EndTime = "00:00:00";

    private double _totalTime = 60;
    private double _maxTime = 600;

    void Start()
    {
        texttimer = GetComponent<TMP_Text>();

        IsRunning = true;
        GameOver = false;
        EndTime = "01:00:00";
        if (IsCountdown)
        {
            _totalTime = 60;
        }
        else
        {
            _totalTime = 0;
        }

        texttimer.color = new Color(255, 255, 255, 1f);
        texttimer.enabled = true;
    }

    void Update()
    {
        if (IsRunning)
        {
            texttimer.enabled = true;

            if (IsCountdown)
            {
                if (_totalTime >= 0)
                {
                    _totalTime -= Time.deltaTime;
                    displayTime(_totalTime);
                }
                else
                {
                    IsRunning = false;
                    GameOver = true;
                    sl.ChangeScene("Message");
                }

                if (_totalTime <= 10)
                {
                    texttimer.color = new Color(225f, 0f, 0f, 1f);
                }
            }
            else
            {
                if (_totalTime < _maxTime)
                {
                    _totalTime += Time.deltaTime;
                    displayTime(_totalTime);
                }
                else
                {
                    IsRunning = false;
                    GameOver = true;
                    sl.ChangeScene("Message");
                }
            }
        }
    }

    public void SetTimer(bool condition)
    {
        IsRunning = condition;
    }

    private void displayTime(double timeToDisplay)
    {
        double timeUsed = 0;
        if (IsCountdown)
        {
            timeToDisplay -= 1;
            timeUsed = 0 + timeToDisplay;
        }
        else
        {
            timeToDisplay += 1;
            timeUsed = _maxTime - timeToDisplay;
        }

        double minutes = (int)Math.Floor(timeToDisplay / 60.0);
        double minutesUsed = (int)Math.Floor(timeUsed / 60.0);
        double seconds = (int)Math.Floor(timeToDisplay % 60.0);
        double secondsUsed = (int)Math.Floor(timeUsed % 60.0);
        double milliseconds = (int)Math.Floor(timeToDisplay % 1 * 100);
        double millisecondsUsed = (int)Math.Floor(timeToDisplay % 1 * 100);

        if (UseMilisecond)
        {
            texttimer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
            EndTime = string.Format("{0:00}:{1:00}:{2:00}", minutesUsed, secondsUsed, millisecondsUsed);
        }
        else
        {
            texttimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            EndTime = string.Format("{0:00}:{1:00}", minutesUsed, secondsUsed);
        }
    }
}
