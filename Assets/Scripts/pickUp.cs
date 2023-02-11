using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{

    public Vector3 startPosition;
    public int number;

    [SerializeField]
    TextMeshProUGUI numberText;


    void Start()
    {
        // get the startiting position of the pick up
        startPosition = transform.position;
        numberText.text = number.ToString();
    }
}
