using UnityEngine;

public class DifficultyIncreaser : MonoBehaviour
{
    public int countGoal;
    public ScoreTrackerScript scoreTrackerScript;

    public int amountOfTimesRampedUp;

    public HungerScript hungerScript;

    public float hungerSpeedUpAmount;

    public GameObject poisonBug;
    public Transform spawnPos;
    public Transform container;

    private void Start()
    {
        countGoal = 20;
        amountOfTimesRampedUp = 0;

        InsectCatcherScript.OnInsectEaten += OnInsectEaten;

    }

    private void OnDestroy()
    {
        InsectCatcherScript.OnInsectEaten -= OnInsectEaten;

    }

    private void OnInsectEaten()
    {
        int currentCount = scoreTrackerScript.bugsEatenCount;
        if (currentCount >= countGoal)
        {
            IncreaseGoal();
            RampUpDifficulty();
        }
    }

    private void IncreaseGoal()
    {
        amountOfTimesRampedUp++;

        int currentCount = scoreTrackerScript.bugsEatenCount;
        int increaseAmount = amountOfTimesRampedUp * 30;
        countGoal = currentCount + increaseAmount;
    }

    private void RampUpDifficulty()
    {
        IncreaseHungerSpeed();
        TrySpawningPoisonousBug();
    }

    private void TrySpawningPoisonousBug()
    {
        if (amountOfTimesRampedUp == 3)
        {
            Instantiate(poisonBug, spawnPos.position, Quaternion.identity, container);
        }
    }

    private void IncreaseHungerSpeed()
    {
        hungerScript.decreaseRate *= hungerSpeedUpAmount;
        if (hungerScript.decreaseRate >= 2.4f)
        {
            hungerScript.decreaseRate = 2.4f;
        }
    }
}
