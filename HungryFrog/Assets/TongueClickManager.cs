using UnityEngine;


public class TongueClickManager : MonoBehaviour
{
    public Camera cam;

    public Vector3 mousePos;

    public LineRenderer lineRenderer;

    public Transform tongueOrigin;

    private Vector3 destinationPoint;
    private bool canMove = false;
    private Vector3 lerpVector;
    public float smoothValue;

    public Transform stickyPart;

    public bool canShoot = true;

    private void Start()
    {
        lineRenderer.SetPosition(0, tongueOrigin.position);
        LerpTongueToDestination(tongueOrigin.position);
    }

    private void Update()
    {

        CheckInput();

        if (!canMove)
        {
            return;
        }

        lerpVector = Vector3.Lerp(lerpVector, destinationPoint, Time.deltaTime * smoothValue);
        SetTongueEndPointTo(lerpVector);
        SetObjectToDestination(stickyPart, lerpVector);
    }

    private void LerpTongueToDestination(Vector3 destination)
    {
        CancelInvoke("RetractTongue");

        lerpVector = tongueOrigin.position;


        destinationPoint = destination;
        canMove = true;

        Invoke("RetractTongue", 1);
    }

    private void CheckInput()
    {
        if (!canShoot)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            mousePos = cam.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                LerpTongueToDestination(mousePos);
                canShoot = false;
            }
        }
    }

    private void SetTongueEndPointTo(Vector3 destination)
    {
        destination.z = 0;

        int endpointIndex = 1;
        lineRenderer.SetPosition(endpointIndex, destination);
    }

    private void SetObjectToDestination(Transform obj, Vector3 destination)
    {
        destination.z = 0;
        obj.position = destination;
    }

    private void RetractTongue()
    {
        destinationPoint = tongueOrigin.position;
        canMove = true;

        canShoot = true;
    }

    //private bool CheckIfReachedDestination()
    //{
    //    float difference = (destinationPoint - lerpValue).magnitude;

    //    if (difference <= 0.01f)
    //    {
    //        return true;
    //    }

    //    return false;
    //}

}
