using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform playerDot;

    void Update()
    {
        if (playerDot.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, playerDot.position.y, transform.position.z);
        }

    }
}
