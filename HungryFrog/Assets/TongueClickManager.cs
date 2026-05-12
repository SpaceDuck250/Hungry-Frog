using UnityEngine;


public class TongueClickManager : MonoBehaviour
{
    public Camera cam;

    public Vector3 mousePos;

    public LineRenderer lineRenderer;

    public Transform tongueOrigin;

    private Vector3 destinationPoint;
    private bool canMove = false;
    private Vector3 lerpValue;
    public float smoothValue;

    public Transform stickyPart;

    private void Start()
    {
        LerpTongueToDestination(tongueOrigin.position);
    }

    private void Update()
    {
        CheckInput();

        if (!canMove)
        {
            return;
        }

        lerpValue = Vector3.Lerp(lerpValue, destinationPoint, Time.deltaTime * smoothValue);
        SetTongueEndPointTo(lerpValue);
        SetStickyPartPositionTo(lerpValue);
    }

    private void LerpTongueToDestination(Vector3 destination)
    {
        CancelInvoke("RetractTongue");

        lerpValue = tongueOrigin.position;


        destinationPoint = destination;
        canMove = true;

        Invoke("RetractTongue", 1);
    }

    private void CheckInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            mousePos = cam.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                LerpTongueToDestination(mousePos);
            }
        }
    }

    private void SetTongueEndPointTo(Vector3 destination)
    {
        destination.z = 0;

        int endpointIndex = 1;
        lineRenderer.SetPosition(endpointIndex, destination);
    }

    private void SetStickyPartPositionTo(Vector3 destination)
    {
        destination.z = 0;
        stickyPart.position = destination;
    }

    private void RetractTongue()
    {
        destinationPoint = tongueOrigin.position;
        canMove = true;
    }



    private bool CheckIfReachedDestination()
    {
        float difference = (destinationPoint - lerpValue).magnitude;

        if (difference <= 0.01f)
        {
            return true;
        }

        return false;
    }

}
