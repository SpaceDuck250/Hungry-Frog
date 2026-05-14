using UnityEngine;

public class SoundPlayerScript : MonoBehaviour
{
    public SoundManagerScript soundManager;

    private void Start()
    {
        soundManager = SoundManagerScript.instance;

        InsectCatcherScript.OnInsectEaten += OnInsectEaten;
        InsectCatcherScript.OnInsectCaught += OnInsectCaught;
    }

    private void OnDestroy()
    {
        InsectCatcherScript.OnInsectEaten -= OnInsectEaten;
        InsectCatcherScript.OnInsectCaught -= OnInsectCaught;

    }

    private void OnInsectEaten()
    {
        if (soundManager == null)
        {
            return;
        }

        soundManager.PlayEffect(soundManager.crunchClip);
    }

    private void OnInsectCaught(GameObject insect)
    {
        if (soundManager == null)
        {
            return;
        }

        soundManager.PlayEffect(soundManager.stickClip);
    }
}
