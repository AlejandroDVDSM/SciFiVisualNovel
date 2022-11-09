using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterBreath : MonoBehaviour
{
    private Vector3 newPosition;

    private double scaleValue;
    private Vector3 originalScale, breathInScale, breathOutScale;

    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 1.5f;

    private bool timeToBreathIn = true;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;

        scaleValue = .02;
        originalScale = transform.localScale;
        breathInScale = new Vector3(originalScale.x - (float)scaleValue, originalScale.y + (float)scaleValue, 1);
        breathOutScale = new Vector3(originalScale.x + (float)scaleValue, originalScale.y - (float)scaleValue, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToBreathIn)
        {
            BreathIn();
        } else if (!timeToBreathIn)
        {
            BreathOut();
        }
    }

    private void BreathIn()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, breathInScale, ref velocity, smoothTime);
        newPosition.y = transform.position.y + .01f * Time.deltaTime;
        transform.position = newPosition;

        var  currentScaleX = Math.Round(transform.localScale.x, 2);
        var targetScaleX = originalScale.x - scaleValue;
        if (currentScaleX == targetScaleX)
        {
            timeToBreathIn = false;
        }
    }

    private void BreathOut()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, breathOutScale, ref velocity, smoothTime);
        newPosition.y = transform.position.y - .01f * Time.deltaTime;
        transform.position = newPosition;

        var currentScaleX = Math.Round(transform.localScale.x, 2);
        var targetScaleX = originalScale.x + scaleValue;

        if (currentScaleX == targetScaleX)
        {
            timeToBreathIn = true;
        }
    }
}
