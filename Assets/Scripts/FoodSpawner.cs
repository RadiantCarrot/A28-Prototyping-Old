using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] FoodSpawners;

    public GameObject FoodBig;
    public GameObject FoodMedium;
    public GameObject FoodSmall;


    // Start is called before the first frame update
    void Start()
    {
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFood()
    {
        FoodSpawners = GameObject.FindGameObjectsWithTag("FoodSpawner");
        for (int i = 0; i < FoodSpawners.Length; i++)
        {
            if (FoodSpawners[i].transform.childCount == 0)
            {
                GameObject foodSpawner = FoodSpawners[i];
                RandomiseFood(foodSpawner);
            }
        }
    }

    public void RandomiseFood(GameObject foodSpawner)
    {
        int foodSelected = Random.Range(1, 4);

        switch (foodSelected)
        {
            case 1:
                Instantiate(FoodBig, foodSpawner.transform.position, foodSpawner.transform.rotation, foodSpawner.transform);
                break;
            case 2:
                Instantiate(FoodMedium, foodSpawner.transform.position, foodSpawner.transform.rotation, foodSpawner.transform);
                break;
            case 3:
                Instantiate(FoodSmall, foodSpawner.transform.position, foodSpawner.transform.rotation, foodSpawner.transform);
                break;
        }
    }
}
