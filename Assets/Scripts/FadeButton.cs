using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FadeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isPointerOverUI;

    private Vector3 currentVelocity = Vector3.zero;
    private float smoothTime = 0.9f;

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
        if (isPointerOverUI && transform.localScale.x < .12f)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, transform.localScale * 1.25f, ref currentVelocity, smoothTime);
        } else if (!isPointerOverUI && transform.localScale.x > .1f) {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, transform.localScale / 1.25f, ref currentVelocity, smoothTime);
        }
    }

    
}
