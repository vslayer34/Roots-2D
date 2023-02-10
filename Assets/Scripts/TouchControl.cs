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
                isFound = false;
                //pickUp.;
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
            pickUp = hit;

            // get the original position of the pickup
            originalPosition.position = hit.GetComponent<PickUp>().startPosition;
            Debug.Log($"Position got: {originalPosition.position}");
        }

    }
}

