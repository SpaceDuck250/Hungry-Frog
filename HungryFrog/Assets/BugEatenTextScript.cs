using UnityEngine;
using TMPro;

public class BugEatenTextScript : MonoBehaviour
{
    public TextMeshProUGUI bugEatenText;
    public int bugEatenCounter;

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
        bugEatenCounter++;
        bugEatenText.text = "Bugs Eaten: " + bugEatenCounter.ToString();
    }
}
