using UnityEngine;
using System;

public class BugKiller : MonoBehaviour
{
    public static event Action OnBugKilledByWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            OnBugKilledByWall?.Invoke();
            Destroy(gameObject);
        }
    }
}
