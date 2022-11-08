using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterBreath : MonoBehaviour
{
    private Vector3 newPosition;

    private Vector3 originalScale;
    private Vector3 breathInScale;
    private Vector3 breathOutScale;

    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 1.5f;

    private bool timeToBreathIn = true;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;

        originalScale = transform.localScale;
        breathInScale = new Vector3(originalScale.x - .02f, originalScale.y + .02f, 1);
        breathOutScale = new Vector3(originalScale.x + .02f, originalScale.y - .02f, 1);
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

        if(Math.Round(transform.localScale.x, 2) == 0.98)
        {
            timeToBreathIn = false;
        }
    }

    private void BreathOut()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, breathOutScale, ref velocity, smoothTime);
        newPosition.y = transform.position.y - .01f * Time.deltaTime;
        transform.position = newPosition;

        if (Math.Round(transform.localScale.x, 2) == 1.02)
        {
            timeToBreathIn = true;
        }
    }
}
