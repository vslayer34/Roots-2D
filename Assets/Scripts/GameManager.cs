using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool isGameOver;
    float interval = 5.0f;

    [SerializeField] EnlargePlant[] plants;
    [SerializeField] GameObject pickUp;
    [SerializeField] Transform[] spawnPoints;

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
        // spawn the pick ups
        foreach (var spawnPoint in spawnPoints)
        {
            Instantiate(pickUp, spawnPoint.position, pickUp.transform.rotation);
        }

        int stage = 0;
        while (!isGameOver)
        {
            // Spawn the plants and generate there numbers
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
