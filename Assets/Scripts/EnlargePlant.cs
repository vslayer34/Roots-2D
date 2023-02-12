using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnlargePlant : MonoBehaviour
{
    [SerializeField]
     TextMeshProUGUI growthText;

    public int growthLevel;

    /// <summary>
    /// Update the scale of the plant based on the generated number
    /// </summary>
    /// <param name="number"></param>
    public void UpdateScale(int number)
    {
        growthLevel = number;

        growthText.text = number.ToString();
        // value to modify the scale so it won't be so big of a plant (/ 10)
        float valueTOModifiyScale = 0.1f;

        // calculate the added scale and add it to the plant
        Vector3 addedScale = new Vector3(transform.localScale.x, number * valueTOModifiyScale, transform.localScale.z);
        transform.localScale = addedScale;
    }
}
