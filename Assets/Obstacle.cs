using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour 
{
    public float rotationSpeed = 100f;

    void Update() 
    {        
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);        
    }

}
