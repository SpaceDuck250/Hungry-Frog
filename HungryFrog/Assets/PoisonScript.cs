using UnityEngine;
using System;

public class PoisonScript : MonoBehaviour
{
    public static event Action OnPoisonBugKilled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sticky")
        {
            HungerScript.OnPlayerLose?.Invoke();
        }

        //if (collision.gameObject.tag == "Wall")
        //{
        //    OnPoisonBugKilled?.Invoke();
        //    Destroy(gameObject);
        //}
    }
}
