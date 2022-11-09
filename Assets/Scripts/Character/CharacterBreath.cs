using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterBreath : MonoBehaviour
{
    private Vector3 newPosition;

    private double scaleValue;
    private Vector3 originalScale, breathScale;

    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 1.5f;

    private bool timeToBreathIn = true;

    private HighlightCharacter highlightCharacter;

    private double targetScaleX;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;

        scaleValue = .02;
        originalScale = transform.localScale;

        highlightCharacter = GetComponent<HighlightCharacter>();
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
        if (IsAlreadyHighlighted())
        {
            var x = originalScale.x * 1.25f - (float)scaleValue;
            var y = originalScale.y * 1.25f + (float)scaleValue;
            targetScaleX = originalScale.x * 1.25f - scaleValue;
            SetBreathScale(x, y);
        }
        else
        {
            var x = originalScale.x - (float)scaleValue;
            var y = originalScale.y + (float)scaleValue;
            targetScaleX = originalScale.x - scaleValue;
            SetBreathScale(x, y);
        }

        transform.localScale = Vector3.SmoothDamp(transform.localScale, breathScale, ref velocity, smoothTime);
        newPosition.y = transform.position.y + .01f * Time.deltaTime;
        transform.position = newPosition;

        var  currentScaleX = Math.Round(transform.localScale.x, 2);


        if (currentScaleX == targetScaleX)
        {
            timeToBreathIn = false;
        }
    }

    private void BreathOut()
    {
        if (IsAlreadyHighlighted())
        {
            var x = originalScale.x * 1.25f + (float)scaleValue;
            var y = originalScale.y * 1.25f - (float)scaleValue;
            targetScaleX = originalScale.x * 1.25f + scaleValue;
            SetBreathScale(x, y);
        } else
        {
            var x = originalScale.x + (float)scaleValue;
            var y = originalScale.y - (float)scaleValue;
            targetScaleX = originalScale.x + scaleValue;
            SetBreathScale(x, y);
        }

        transform.localScale = Vector3.SmoothDamp(transform.localScale, breathScale, ref velocity, smoothTime);
        newPosition.y = transform.position.y - .01f * Time.deltaTime;
        transform.position = newPosition;

        var currentScaleX = Math.Round(transform.localScale.x, 2);

        if (currentScaleX == targetScaleX)
        {
            timeToBreathIn = true;
        }
    }

    private bool IsAlreadyHighlighted()
    {
        if (highlightCharacter.IsAlreadyHighlighted) return true;

        return false;
    }

    private void SetBreathScale(float x, float y)
    {
        breathScale = new Vector3(x, y, 1);
    }
}
