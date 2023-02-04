using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public Transform testObject;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touchInput = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touchInput.position);
            touchPos.z = 0;

            if (touchInput.phase == TouchPhase.Moved) 
            {
                testObject.position = touchPos;
            }
        }
    }
}
