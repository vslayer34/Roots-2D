using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver;
    float interval = 5.0f;

    [SerializeField] EnlargePlant[] plants;
    [SerializeField] GameObject pickUp;

    public static GameManager instance;

    void Start()
    {
        if (instance == null)
            instance = this;


        StartCoroutine(GameLoop());
    }


    /// <summary>
    /// Manage the game loop
    /// </summary>
    /// <returns></returns>
    public IEnumerator GameLoop()
    {
        int stage = 0;
        while (!isGameOver)
        {
            //Debug.Log($"current stage: {stage}");
            //int generatedNumber = GenerateNumber();
            //UpdateScale(generatedNumber);
            foreach (var plant in plants)
            {
                int genratedNumber = GenerateNumber(stage);
                plant.UpdateScale(genratedNumber);
                stage++;
            }

            yield return new WaitForSeconds(interval);
        }
    }


    public int GenerateNumber(int stage)
    {
        int stageInterval = 3;
        int addedValue = stage * stageInterval;

        // minimum and max number
        int minimumValue = 1;
        int maximumValue = 5;

        // genrate the number and return it
        int number = Random.Range(minimumValue + addedValue, maximumValue + addedValue);

        //Debug.Log(number * number);
        return number * number;
    }
}
