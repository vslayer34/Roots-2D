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

        int stage = 0;
        while (!isGameOver)
        {
            int genratedNumber;
            int[] arrayOfGeneratedNumbers = new int[3];


            // Generate numbers for pick up and the plant
            genratedNumber = GenerateNumber(stage);

            // generate random numbers for array of 3
            arrayOfGeneratedNumbers[0] = GenerateNumber(stage) + Random.Range(0, 3);
            arrayOfGeneratedNumbers[1] = GenerateNumber(stage) - Random.Range(0, 2);
            arrayOfGeneratedNumbers[2] = GenerateNumber(stage) + Random.Range(0, 3);

            // one random index must have the correct number
            int index = Random.Range(0, 3);
            arrayOfGeneratedNumbers[index] = genratedNumber;

            // spawn the pick ups
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                // assign a number to the array acorrding to the index
                pickUp.GetComponent<PickUp>().number = arrayOfGeneratedNumbers[i];

                // instantiate the pick up objects as child of the spawn points
                GameObject newSpawn = Instantiate(pickUp, spawnPoints[i].position, pickUp.transform.rotation);
                newSpawn.transform.parent = spawnPoints[i];
            }

            // Spawn the plants and power its number
            foreach (var plant in plants)
            {
                genratedNumber = (int) Mathf.Pow(genratedNumber, 2);
                plant.UpdateScale(genratedNumber);
                stage++;
            }

            yield return new WaitForSeconds(interval);

            // remove old pick ups
            foreach (var spawnPoint in spawnPoints)
            {
                Destroy(spawnPoint.transform.GetChild(0).gameObject);
            }
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
        return number;
    }
}
