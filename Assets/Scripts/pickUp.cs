using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Vector3 startPosition;

    void Start()
    {
        // get the startiting position of the pick up
        startPosition = transform.position;
    }
}
