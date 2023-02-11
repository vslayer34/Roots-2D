using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Vector3 touchPos;

    Collider2D pickUp;
    Transform originalPosition;

    bool isFound;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touchInput = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touchInput.position);
            touchPos.z = 0;

            if (touchInput.phase == TouchPhase.Began) 
            {
                SendTouchToGame();
            }

            // make the object follow the player touch
            else if (touchInput.phase == TouchPhase.Moved && isFound)
            {
                // follow the player movement
                pickUp.transform.position = touchPos;
            }

            else if (touchInput.phase == TouchPhase.Ended && isFound)
            {
                // clear is Found
                isFound = false;
                
                // get the script component and return the pick up to its original position
                PickUp pickUpScript = pickUp.GetComponent<PickUp>();
                pickUp.transform.position = new Vector3(pickUpScript.startPosition.x, pickUpScript.startPosition.y);

                // clear the pick up
                pickUp = null;
            }
        }
    }

    void SendTouchToGame()
    {
        Collider2D hit = Physics2D.OverlapPoint(touchPos);
        if (hit == null)
        {
            return;
        }
        else if (hit.CompareTag(Tags.pickUpTag))
        {
            // pick up is found
            Debug.Log("touched the object");
            isFound = true;
            // referance the pick up in the update function
            pickUp = hit;
        }

    }
}

