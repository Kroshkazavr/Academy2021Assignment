using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class which contains method for turning an obstacle.
/// </summary>

public class Rotator : MonoBehaviour 
{
    public float rotationSpeed = 100f;

    void Update() 
    {        
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);      
    }

}
