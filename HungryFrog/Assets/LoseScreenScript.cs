using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenScript : MonoBehaviour
{
    public GameObject loseScreen;

    private void Start()
    {
        loseScreen = transform.Find("LoseScreen").gameObject;
        HungerScript.OnPlayerLose += OnPlayerLose;
    }

    private void OnDestroy()
    {
        HungerScript.OnPlayerLose += OnPlayerLose;
    }

    private void OnPlayerLose()
    {
        ShowLoseScreen();
    }

    private void ShowLoseScreen()
    {
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
