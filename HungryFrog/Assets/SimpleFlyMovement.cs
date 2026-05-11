using UnityEngine;

public class SimpleFlyMovement : MonoBehaviour
{
    public float yRange;
    public float xRange;

    public float timer;
    public float waitTime;

    public float smoothValue;

    private Vector3 destination;

    private void Update()
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
        float y = Random.Range(-yRange, yRange);

        Vector3 positionOffset = new Vector3(x, y, transform.position.z);
        return positionOffset; 
    }
}
