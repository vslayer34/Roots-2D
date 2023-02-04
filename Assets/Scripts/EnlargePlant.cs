using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnlargePlant : MonoBehaviour
{
    [SerializeField]
     TextMeshProUGUI growthText;

    /// <summary>
    /// Update the scale of the plant based on the generated number
    /// </summary>
    /// <param name="number"></param>
    public void UpdateScale(int number)
    {
        growthText.text = number.ToString();
        // value to modify the scale so it won't be so big of a plant (/ 10)
        float valueTOModifiyScale = 0.1f;

        // calculate the added scale and add it to the plant
        Vector3 addedScale = new Vector3(transform.localScale.x, number * valueTOModifiyScale, transform.localScale.z);
        transform.localScale = addedScale;
    }

    /*
    /// <summary>
    /// Generate the number that the plant would grow relative to it
    /// </summary>
    /// <returns></returns>
    int GenerateNumber()
    {
        // get out of the loop
        bool success = false;
        int generatedNumber = 0;


        // keep generating numberes until the number can be squared so then it returns it and get out of the loop
        while (!success)
        {
            // Max number to be generated
            int maxNumber = 20 * 20;
            int newNum = Random.Range(0, maxNumber + 1);

            // get the square root of the new number and type cast it into int
            float result = Mathf.Sqrt(newNum);
            generatedNumber = (int)result;


            // see if the number is the value as the float number
            // and keep going untill it generates an acceptable number and return it
            if (generatedNumber == result)
            {
                Debug.Log("Number Generated: " + generatedNumber);
                success = true;
            }
        }

        return generatedNumber;
    }
    */
    
}
