using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    private Vector3 worldPosition;

    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.eulerAngles = new Vector3(worldPosition.y, worldPosition.x, 0);
    }
}
