using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

using extDebug.Menu;
using UnityEngine.SceneManagement;


/// <summary>
/// Always put this script in the first scene of the game.
/// </summary>
/// <remarks>
/// This script is used to store the game settings and can be accessed from any scene by pressing the Q key.
/// </remarks>
// This is a example script to store the game settings
public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    // Button Animation
    public float buttonShakeStrength { get; private set; } = 0.05f;
    public float buttonShakeDuration { get; private set; } = 1f;
    public Ease buttonShakeEase { get; private set; } = Ease.OutCubic;

    // Fade Scene
    public bool fadeAtTitle { get; private set; } = false;
    public bool fadeAtTutorial { get; private set; } = false;
    public bool fadeAtCountdown { get; private set; } = true;
    public bool fadeAtQuiz { get; private set; } = false;
    public bool fadeAtFinish { get; private set; } = true;
    
    // Title Animation
    public float titleButtonDelay { get; private set; } = 1f;
    public float titleButtonShakeStrength { get; private set; } = 0.1f;
    public float titleButtonShakeDuration { get; private set; } = 1f;

    // Tutorial Animation
    public float tutorialPanelInDuration { get; private set; } = 0.8f;
    public Ease tutorialPanelInEase { get; private set; } = Ease.OutCirc;
    public float tutorialPanelShakeStrength { get; private set; } = 0.03f;
    public float tutorialPanelShakeDuration { get; private set; } = 1f;
    public Ease tutorialPanelShakeEase { get; private set; } = Ease.OutCubic;
    public float tutorialButtonDelay { get; private set; } = 0f;
    public float tutorialButtonShakeStrength { get; private set; } = 0.05f;
    public float tutorialButtonShakeDuration { get; private set; } = 1f;

    // Countdown Animation
    public float countdownDuration { get; private set; } = 13f;

    // Quiz Animation
    public float quizPanelInDuration { get; private set; } = 0.8f;
    public Ease quizPanelInEase { get; private set; } = Ease.OutCirc;
    public float answerPanelShakeStrength { get; private set; } = 0.05f;
    public float answerPanelShakeDuration { get; private set; } = 1f;
    public Ease answerPanelShakeEase { get; private set; } = Ease.OutCubic;
    public float answerPanelInDuration { get; private set; } = 0.8f;
    public float quizPanelFadeOutDuration { get; private set; } = 1f;
    public float quizPanelScaleOutTarget { get; private set; } = 0f;
    public Ease quizPanelScaleOutEase { get; private set; } = Ease.InBack;


    // Raport
    public float delayRaportText { get; private set; } = 4f;
    public readonly string[] raportTextModeOptions = new string[] { "Tombol", "Langsung" };
    public string raportTextMode { get; private set; } = "Langsung";



    // Game Settings
    public float quizDuration { get; private set; } = 15f;
    public int minimumScore { get; private set; } = 80;
    public string scoreSettings { get; private set; } = "Rata-rata";
    public readonly string[] scoreSettingsOptions = new string[] { "Rata-rata", "Jumlah" };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        var storage = new DMPlayerStorage(); // Class to store the value of the variable realtime

        DM.Add("Reset Game", action => { SceneManager.LoadScene(0);} );
        
        DM.Add("Goto Scene/Title", action => { SceneManager.LoadScene("Title"); });
        DM.Add("Goto Scene/Tutorial", action => { SceneManager.LoadScene("Tutorial"); });
        DM.Add("Goto Scene/Quiz", action => { SceneManager.LoadScene("Quiz"); });
        DM.Add("Goto Scene/Finish", action => { SceneManager.LoadScene("Finish"); });
        
        // Button
        DM.Add("Animation/Button/Shake Strength", () => buttonShakeStrength, v => buttonShakeStrength = v).SetStorage(storage);
        DM.Add("Animation/Button/Shake Duration", () => buttonShakeDuration, v => buttonShakeDuration = v).SetPrecision(1).SetStorage(storage);
        DM.Add("Animation/Button/Shake Ease", () => buttonShakeEase, v => buttonShakeEase = v).SetStorage(storage);

        // Title
        DM.Add("Animation/Title/Button Delay", () => titleButtonDelay, v => titleButtonDelay = v).SetStorage(storage);
        DM.Add("Animation/Title/Button Shake Strength", () => titleButtonShakeStrength, v => titleButtonShakeStrength = v).SetStorage(storage);
        DM.Add("Animation/Title/Button Shake Duration", () => titleButtonShakeDuration, v => titleButtonShakeDuration = v).SetPrecision(1).SetStorage(storage);

        // Tutorial
        DM.Add("Animation/Tutorial/Panel In Duration", () => tutorialPanelInDuration, v => tutorialPanelInDuration = v).SetPrecision(1).SetStorage(storage);
        DM.Add("Animation/Tutorial/Panel In Ease", () => tutorialPanelInEase, v => tutorialPanelInEase = v).SetStorage(storage);
        DM.Add("Animation/Tutorial/Panel Shake Strength", () => tutorialPanelShakeStrength, v => tutorialPanelShakeStrength = v).SetStorage(storage);
        DM.Add("Animation/Tutorial/Panel Shake Duration", () => tutorialPanelShakeDuration, v => tutorialPanelShakeDuration = v).SetPrecision(1).SetStorage(storage);
        DM.Add("Animation/Tutorial/Panel Shake Ease", () => tutorialPanelShakeEase, v => tutorialPanelShakeEase = v).SetStorage(storage);
        DM.Add("Animation/Tutorial/Button Delay", () => tutorialButtonDelay, v => tutorialButtonDelay = v).SetStorage(storage);
        DM.Add("Animation/Tutorial/Button Shake Strength", () => tutorialButtonShakeStrength, v => tutorialButtonShakeStrength = v).SetStorage(storage);
        DM.Add("Animation/Tutorial/Button Shake Duration", () => tutorialButtonShakeDuration, v => tutorialButtonShakeDuration = v).SetPrecision(1).SetStorage(storage);

        // Countdown
        DM.Add("Animation/Countdown/Countdown Duration", () => countdownDuration, v => countdownDuration = v).SetPrecision(1).SetStorage(storage);

        // Quiz
        DM.Add("Animation/Quiz/Quiz panel In Duration", () => quizPanelInDuration, v => quizPanelInDuration = v).SetPrecision(1).SetStorage(storage);
        DM.Add("Animation/Quiz/Quiz panel In Ease", () => quizPanelInEase, v => quizPanelInEase = v).SetStorage(storage);
        DM.Add("Animation/Quiz/Answer panel Shake Strength", () => answerPanelShakeStrength, v => answerPanelShakeStrength = v).SetStorage(storage);
        DM.Add("Animation/Quiz/Answer panel Shake Duration", () => answerPanelShakeDuration, v => answerPanelShakeDuration = v).SetPrecision(1).SetStorage(storage);
        DM.Add("Animation/Quiz/Answer panel Shake Ease", () => answerPanelShakeEase, v => answerPanelShakeEase = v).SetStorage(storage);
        DM.Add("Animation/Quiz/Answer panel In Duration", () => answerPanelInDuration, v => answerPanelInDuration = v).SetPrecision(1).SetStorage(storage);
        DM.Add("Animation/Quiz/Quiz panel Fade Out Duration", () => quizPanelFadeOutDuration, v => quizPanelFadeOutDuration = v).SetPrecision(1).SetStorage(storage);
        DM.Add("Animation/Quiz/Quiz panel Scale Out Target", () => quizPanelScaleOutTarget, v => quizPanelScaleOutTarget = v).SetStorage(storage);
        DM.Add("Animation/Quiz/Quiz panel Scale Out Ease", () => quizPanelScaleOutEase, v => quizPanelScaleOutEase = v).SetStorage(storage);

        // Raport
        DM.Add("Animation/Raport/Delay Raport Text", () => delayRaportText, v => delayRaportText = v).SetPrecision(1).SetStorage(storage);
        DM.Add("Animation/Raport/Raport Text Mode", () => raportTextMode, v => raportTextMode = v, raportTextModeOptions).SetStorage(storage);

        // Fade Scene
        DM.Add("Fade/Title", () => fadeAtTitle, v => fadeAtTitle = v).SetStorage(storage);
        DM.Add("Fade/Tutorial", () => fadeAtTutorial, v => fadeAtTutorial = v).SetStorage(storage);
        DM.Add("Fade/Quiz", () => fadeAtQuiz, v => fadeAtQuiz = v).SetStorage(storage);
        DM.Add("Fade/Finish", () => fadeAtFinish, v => fadeAtFinish = v).SetStorage(storage);

        // Game Settings
        DM.Add("Game Settings/Quiz answer duration", () => quizDuration, v => quizDuration = v).SetPrecision(0).SetStorage(storage);
        DM.Add("Game Settings/Raport minimum score", () => minimumScore, v => minimumScore = v).SetStorage(storage);
        DM.Add("Game Settings/Raport score settings", () => scoreSettings, v => scoreSettings = v, scoreSettingsOptions).SetStorage(storage);

        // Input
        // DM.Add("Test", () => easeEnum, v => easeEnum = v, storage); 
    }
}
