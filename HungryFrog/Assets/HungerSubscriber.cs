using UnityEngine;

public class HungerSubscriber : MonoBehaviour
{
    public HungerScript hungerScript;

    private void Start()
    {
        InsectCatcherScript.OnInsectEaten += OnInsectEaten;
    }

    private void OnDestroy()
    {
        InsectCatcherScript.OnInsectEaten -= OnInsectEaten;
    }

    private void OnInsectEaten()
    {
        hungerScript.AddToHungerBar(1.5f);
    }
}
