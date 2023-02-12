using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCollision : MonoBehaviour
{
    [SerializeField]
    EnlargePlant parentPlant;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.pickUpTag))
        {
            PickUp pickUpScript = collision.gameObject.GetComponent<PickUp>();

            if (pickUpScript!= null && parentPlant.growthLevel == Mathf.Pow(pickUpScript.number, 2))
            {
                Debug.Log("You Win");
            }
            else
            {
                Debug.Log("You Lose");
            }
        }
    }
}
