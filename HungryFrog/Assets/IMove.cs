using UnityEngine;

public abstract class Moveable : MonoBehaviour
{
    public bool canMove = true;

    public abstract void Move();

    public virtual void StopMoving()
    {
        canMove = false;
    }

    
}
