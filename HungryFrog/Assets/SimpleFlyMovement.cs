using UnityEngine;

public class SimpleFlyMovement : Moveable
{
    public float yRange;
    public float xRange;

    public float timer;
    public float waitTime;

    public float smoothValue;

    private Vector3 destination;

    private void Update()
    {
        if (!canMove)
        {
            return;
        }

        Move();
    }

    public override void Move()
    {
        MoveAboutRandomly();
    }

    private void MoveAboutRandomly()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0;
            Vector3 randomOffset = GetNewPositionOffset();
            destination = transform.position + randomOffset;
        }

        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * smoothValue);
    }

    private Vector3 GetNewPositionOffset()
    {
        float x = Random.Range(-xRange, xRange);
        x = Mathf.Round(x * 100f) / 100f;
        float y = Random.Range(-yRange, yRange);
        y = Mathf.Round(y * 100f) / 100f;

        Vector3 positionOffset = new Vector3(x, y, 0);
        return positionOffset; 
    }
}
