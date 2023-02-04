using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargePlant : MonoBehaviour
{
    //public Transform gfx;

    // Update is called once per frame
    void Update()
    {
        Vector3 addedScale = new Vector3(0.0f, 0.1f, 0.0f);
        transform.localScale += addedScale * Time.deltaTime;
    }
}
