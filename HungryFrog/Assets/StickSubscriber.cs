using UnityEngine;

public class StickSubscriber : MonoBehaviour
{
    public StickingScript stickScript;
    public Moveable moveScript;


    private void Start()
    {
        stickScript.OnStick += OnStick;
    }

    private void OnDestroy()
    {
        stickScript.OnStick -= OnStick;
    }

    private void OnStick()
    {
        moveScript.StopMoving();
    }
}
