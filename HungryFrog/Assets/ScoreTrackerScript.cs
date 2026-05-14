using UnityEngine;
using TMPro;

public class ScoreTrackerScript : MonoBehaviour
{
    public BugEatenTextScript bugEatenTextScript;

    public TextMeshProUGUI scoreText, highScoreText;

    private void Start()
    {
        HungerScript.OnPlayerLose += OnPlayerLose;
    }

    private void OnDestroy()
    {
        HungerScript.OnPlayerLose -= OnPlayerLose;
    }

    private void OnPlayerLose()
    {
        TrySaveScore(bugEatenTextScript.bugEatenCounter);
        scoreText.text = "Score: " + bugEatenTextScript.bugEatenCounter;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");

    }

    private void TrySaveScore(int newScore)
    {
        int highScore = PlayerPrefs.GetInt("HighScore");

        if (newScore >= highScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore);
        }
    }
}

