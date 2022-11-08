using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    private Vector3 worldPosition;

    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (IsInBoundsX() && IsInBoundsY())
        {
            transform.eulerAngles = new Vector3(-worldPosition.y, worldPosition.x, 0);
        } else if (!IsInBoundsX() && IsInBoundsY())
        {
            transform.eulerAngles = new Vector3(-worldPosition.y, transform.rotation.x, 0);
        } else if (IsInBoundsX() && !IsInBoundsY())
        {
            transform.eulerAngles = new Vector3(-transform.rotation.y, worldPosition.x, 0);

        }
    }

    private bool IsInBoundsX()
    {
        if (worldPosition.x > -9.8 && worldPosition.x < 9.6)
        {
            return true;
        }

        return false;
    }

    private bool IsInBoundsY()
    {
        if (-worldPosition.y > -3.1 && -worldPosition.y < 6.7)
        {
            return true;
        }

        return false;
    }

}
