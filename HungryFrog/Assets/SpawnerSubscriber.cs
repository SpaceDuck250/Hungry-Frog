using UnityEngine;

public class SpawnerSubscriber : MonoBehaviour
{
    public BugSpawnerScript bugSpawner;

    private void Start()
    {
        InsectCatcherScript.OnInsectEaten += OnInsectEaten;
        BugKiller.OnBugKilledByWall += OnBugKilledByWall;
    }


    private void OnDestroy()
    {
        InsectCatcherScript.OnInsectEaten -= OnInsectEaten;
        BugKiller.OnBugKilledByWall -= OnBugKilledByWall;

    }

    private void OnInsectEaten()
    {
        bugSpawner.aliveBugs--;
    }

    private void OnBugKilledByWall()
    {
        bugSpawner.aliveBugs--;
    }
}
