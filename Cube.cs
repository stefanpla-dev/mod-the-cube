using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Quaternion initialRotation;
    private float spinAngle;
    private Vector3 startPosition;
    public float riseAmplitude = 0.7f; // Height of rise/fall.
    public float riseFrequency = 2.0f; // How often the rise/fall happens.
    public float baseSpinSpeed = 180.0f; 
    public float apexSpinMultiplier = 5.0f; // Increase speed at apex.
    public float apexThreshold = 0.1f; // How close to the apex to apply the multiplier.

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        startPosition = transform.position;
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.material;
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);

        //Set initial rotation.
        initialRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        transform.rotation = initialRotation;

        //Initialize spin angle.
        spinAngle = 0.0f;
    }

    void Update()
    {
        //Calculate the rise offset using sine for rise/fall.
        float riseOffset = Mathf.Sin(Time.time * Mathf.PI*2.0f*riseFrequency)*riseAmplitude;

        //Determine how close we are to the apex (normalized to a range of -1 to 1).
        float normalizedHeight = Mathf.Sin(Time.time*Mathf.PI*2.0f*riseFrequency);
        float currentSpinSpeed = baseSpinSpeed;

        //Check if near top of the movement.
        if (normalizedHeight >= (1.0f - apexThreshold))
        {
            currentSpinSpeed *= apexSpinMultiplier; // Increase speed at apex.
        }

        //Increment spin angle over time.
        spinAngle += currentSpinSpeed * Time.deltaTime;

        //Apply spinning 
        transform.rotation = initialRotation * Quaternion.Euler(0.0f, spinAngle, 0.0f);


        transform.position = new Vector3(startPosition.x, startPosition.y+riseOffset, startPosition.z);
    }
}
