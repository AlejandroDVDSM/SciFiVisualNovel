using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float maxScaleLimit;
    [SerializeField] private float minScaleLimit;

    private bool isPointerOverUI;

    private Vector3 currentVelocity = Vector3.zero;
    private float smoothTime = 0.6f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOverUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOverUI = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (isPointerOverUI && transform.localScale.x < maxScaleLimit)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, transform.localScale * 1.25f, ref currentVelocity, smoothTime);
        } else if (!isPointerOverUI && transform.localScale.x > minScaleLimit) {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, transform.localScale / 1.25f, ref currentVelocity, smoothTime);
        }
    }

    
}
