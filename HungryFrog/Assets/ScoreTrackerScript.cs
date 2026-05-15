using UnityEngine;
using TMPro;

public class ScoreTrackerScript : MonoBehaviour
{
    public BugEatenTextScript bugEatenTextScript;

    public TextMeshProUGUI scoreText, highScoreText;

    public int bugsEatenCount;

    public bool lost = false;

    private void Start()
    {
        HungerScript.OnPlayerLose += OnPlayerLose;
        InsectCatcherScript.OnInsectEaten += OnInsectEaten;
    }

    private void OnDestroy()
    {
        HungerScript.OnPlayerLose -= OnPlayerLose;
        InsectCatcherScript.OnInsectEaten -= OnInsectEaten;

    }

    private void OnInsectEaten()
    {
        if (lost)
        {
            return;
        }

        bugsEatenCount++;
    }

    private void OnPlayerLose()
    {
        lost = true;

        TrySaveScore(bugsEatenCount);
        scoreText.text = "Score: " + bugsEatenCount;
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

