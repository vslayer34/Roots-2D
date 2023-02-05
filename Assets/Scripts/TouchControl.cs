using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Vector3 touchPos;
    public Transform testObject;

    Collider2D pickUp;

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

            if (touchInput.phase == TouchPhase.Moved && isFound)
            {
                pickUp.transform.position = touchPos;
            }
        }
    }

    void SendTouchToGame()
    {
        Debug.Log(touchPos);
        //Ray ray = Camera.main.ScreenPointToRay(touchPos);
        //RaycastHit hit;

        if (Physics2D.OverlapPoint(touchPos).tag == Tags.pickUpTag)
        {
            isFound = true;
            Debug.Log("touched the object");
            pickUp = Physics2D.OverlapPoint(touchPos);
        }
        else
        {
            isFound = false;
        }
        //{
        //    Debug.Log("Raycast sent");

        //    if (hit.collider.CompareTag(Tags.pickUpTag))
        //    {
        //        Debug.Log("touched the object");
        //    }
        //}
    }
}

