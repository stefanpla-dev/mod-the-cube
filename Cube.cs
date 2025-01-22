﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float riseAmplitude = 0.7f; // Height of rise/fall.
    public float riseFrequency = 2.0f; // How often the rise/fall happens.
    public float baseSpinSpeed = 180.0f; 
    public float apexSpinMultiplier = 5.0f; // Increase speed at apex.
    public float apexThreshold = 0.1f; // How close to the apex to apply the multiplier.

    private float spinAngle;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        Renderer.material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

    }

    void Update()
    {
        //Calculate the rise offset using sine for rise/fall.
        //Determine how close we are to the apex (normalized to a range of -1 to 1).
        float normalizedHeight = Mathf.Sin(Time.time*Mathf.PI*2.0f*riseFrequency);
        float riseOffset = normalizedHeight*riseAmplitude;
        float currentSpinSpeed = baseSpinSpeed * (normalizedHeight >= (1.0f - apexThreshold) ? apexSpinMultiplier : 1.0f);

        //Update rotation and position.
        spinAngle += currentSpinSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0.0f, spinAngle, 0.0f);
        transform.position = startPosition + Vector3.up * riseOffset;
    }
}
