using UnityEngine;
using System.Collections.Generic;

public class BugSpawnerScript : MonoBehaviour
{
    public List<GameObject> spawnableBugsList = new List<GameObject>();

    public float timer;
    public float waitTime;

    public int aliveBugs;
    public int maxBugs;

    public Transform spawnOrigin;

    public float offsetX;
    public float offsetY;

    public Transform container;

    private void Update()
    {
        if (TooManyBugs())
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0;
            SpawnRandomBug();
        }
    }

    private bool TooManyBugs()
    {
        if (aliveBugs >= maxBugs)
        {
            return true;
        }

        return false;
    }

    private void SpawnRandomBug()
    {
        aliveBugs++;

        int randomBugIndex = Random.Range(0, spawnableBugsList.Count);
        GameObject randomBug = spawnableBugsList[randomBugIndex];

        float x = Random.Range(-offsetX, offsetX);
        float y = Random.Range(-offsetY, offsetY);

        Vector3 spawnOffset = new Vector3(x, y, 0);
        Vector3 spawnPosition = spawnOrigin.position + spawnOffset;

        Instantiate(randomBug, spawnPosition, Quaternion.identity, container);
    }
}
