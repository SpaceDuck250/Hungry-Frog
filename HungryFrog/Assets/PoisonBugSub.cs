using UnityEngine;

public class PoisonBugSub : MonoBehaviour
{
    public BugSpawnerScript bugSpawner;

    private void Start()
    {
        PoisonScript.OnPoisonBugKilled += OnPoisonBugKilled;
    }

    private void OnDestroy()
    {
        PoisonScript.OnPoisonBugKilled -= OnPoisonBugKilled;

    }

    private void OnPoisonBugKilled()
    {
        bugSpawner.aliveBugs--;
    }


}
