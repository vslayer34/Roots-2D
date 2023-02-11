using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.pickUpTag))
        {
            Debug.Log("collider");
        }
    }
}
