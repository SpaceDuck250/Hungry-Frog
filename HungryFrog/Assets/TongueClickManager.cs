using UnityEngine;


public class TongueClickManager : MonoBehaviour
{
    public Camera cam;

    public Vector3 mousePos;

    public GameObject tongueParent;
    public GameObject tongue;

    private void Update()
    {
       

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            mousePos = cam.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                ShootTongue(mousePos);
            }
        }
    }

    private void ShootTongue(Vector3 destination)
    {
        Vector2 angleVector = destination - tongueParent.transform.position;
        float turnAngle = Mathf.Atan2(angleVector.y, angleVector.x) * Mathf.Rad2Deg;

        float offset = 90;
        turnAngle += offset;

        Quaternion qAngle = Quaternion.Euler(0, 0, turnAngle);

        tongueParent.transform.localRotation = qAngle;

        float distance = Vector2.Distance(destination, tongueParent.transform.position);

        float baseLength = 2.82f;
        float scaleFactorY = distance / baseLength;

        tongueParent.transform.localScale = new Vector3(tongueParent.transform.localScale.x, scaleFactorY, tongueParent.transform.localScale.z);



    }
}
