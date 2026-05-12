using UnityEngine;
using System;

public class StickingScript : MonoBehaviour
{
    public event Action OnStick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sticky")
        {
            OnStick?.Invoke();
        }
    }
}
