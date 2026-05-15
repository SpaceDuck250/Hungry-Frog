using UnityEngine;
using System;
using UnityEngine.UI;

public class HungerScript : MonoBehaviour
{
    [SerializeField]
    private float hungerLeft;
    public float maxHunger;

    public static Action OnPlayerLose;

    public Image hungerBar;

    public float decreaseRate = 1;

    private void Start()
    {
        hungerLeft = maxHunger;
    }

    private void Update()
    {
        DecreaseHungerOverTime();
    }

    private void DecreaseHungerOverTime()
    {
        hungerLeft -= Time.deltaTime * decreaseRate;
        if (hungerLeft <= 0)
        {
            hungerLeft = 0;
            OnPlayerLose?.Invoke();
            return;
        }

        hungerBar.fillAmount = hungerLeft / maxHunger;
    }

    public void AddToHungerBar(float amount)
    {
        hungerLeft += amount;
        if (hungerLeft >= maxHunger)
        {
            hungerLeft = maxHunger;
        }

        hungerBar.fillAmount = hungerLeft / maxHunger;
    }
}
