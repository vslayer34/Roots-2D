using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Vector3 touchPos;
    public Transform testObject;

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
                //testObject.position = touchPos;
                SendTouchToGame();
            }

            // make the object follow the player touch
            else if (touchInput.phase == TouchPhase.Moved && isFound)
            {
                pickUp.transform.position = touchPos;
            }

            //else if (touchInput.phase == TouchPhase.Canceled)
            //{
            //    isFound = false;
            //    pickUp.transform.position = originalPosition.position;
            //}
        }
    }

    void SendTouchToGame()
    {
        Debug.Log(touchPos);

        if (Physics2D.OverlapPoint(touchPos).tag == Tags.pickUpTag)
        {
            // the pickup is found
            isFound = true;
            Debug.Log("touched the object");

            // get reference to the picked object
            pickUp = Physics2D.OverlapPoint(touchPos);

            // get the original poistion of the pick up
            originalPosition.position = pickUp.transform.position;
            Debug.Log(originalPosition.position);
        }
    }
}

