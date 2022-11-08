using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    private Vector3 worldPosition;

    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(worldPosition);

        if (-worldPosition.y > -3.1 && -worldPosition.y < 6.7 && worldPosition.x > -9.8 && worldPosition.x < 9.6)
        {
            transform.eulerAngles = new Vector3(-worldPosition.y, worldPosition.x, 0);
        }
    }
}
