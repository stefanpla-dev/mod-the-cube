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
        //Increment spin angle over time.
        spinAngle += 360.0f * Time.deltaTime;

        //Apply spinning 
        transform.rotation = initialRotation * Quaternion.Euler(0.0f, spinAngle, 0.0f);

        float riseOffset = Mathf.Sin(Time.time * Mathf.PI*2.0f*riseFrequency)*riseAmplitude;

        transform.position = new Vector3(startPosition.x, startPosition.y+riseOffset, startPosition.z);
    }
}
