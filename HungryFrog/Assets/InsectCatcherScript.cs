using UnityEngine;
using System.Collections.Generic;
using System;

public class InsectCatcherScript : MonoBehaviour
{
    public static Action<GameObject> OnInsectCaught;
    public static Action OnInsectEaten;

    public List<GameObject> caughtInsectList = new List<GameObject>();

    private void Start()
    {
        OnInsectCaught += OnInsectCaughtFunction;
    }

    private void OnDestroy()
    {
        OnInsectCaught += OnInsectCaughtFunction;

    }

    private void OnInsectCaughtFunction(GameObject insect)
    {
        caughtInsectList.Add(insect);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Frog")
        {
            EatAllInsects();
        }
    }

    private void EatAllInsects()
    {
        if (caughtInsectList.Count == 0)
        {
            return;
        }

        foreach (GameObject insect in caughtInsectList)
        {
            Destroy(insect);
            OnInsectEaten?.Invoke();
        }
    }
}
