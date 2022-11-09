using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    private float lastValueRotationX;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (IsInBoundsX() && IsInBoundsY())
        {
            transform.eulerAngles = new Vector3(-mousePosition.y, mousePosition.x, 0);
            lastValueRotationX = transform.eulerAngles.x;
        } else if (!IsInBoundsX() && IsInBoundsY())
        {
            transform.eulerAngles = new Vector3(-mousePosition.y, lastValueRotationX, 0);
        } else if (IsInBoundsX() && !IsInBoundsY())
        {
            transform.eulerAngles = new Vector3(-2.5f, mousePosition.x, 0);
        }
    }

    private bool IsInBoundsX()
    {
        if (mousePosition.x > -9.8 && mousePosition.x < 9.6) return true;

        return false;
    }

    private bool IsInBoundsY()
    {
        if (-mousePosition.y > -2.5 && -mousePosition.y < 6.7) return true;

        return false;
    }
}
