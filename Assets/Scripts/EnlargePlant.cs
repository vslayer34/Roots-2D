using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;

public class EnlargePlant : MonoBehaviour
{
    bool isGameOver;
    float interval = 5.0f;

    void Start()
    {
        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateScale(int number)
    {
        float valueTOModifiyScale = 0.1f;
        Vector3 addedScale = new Vector3(0.0f, valueTOModifiyScale, 0.0f);
        transform.localScale += addedScale * Time.deltaTime;
    }


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

    /// <summary>
    /// Manage the game loop
    /// </summary>
    /// <returns></returns>
    IEnumerator GameLoop()
    {
        while (!isGameOver)
        {
            int generatedNumber = GenerateNumber();
            UpdateScale(generatedNumber);
            yield return new WaitForSeconds(interval);
        }
    }
}
