using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterballSpawner : MonoBehaviour
{
    public GameObject WaterSpawnpoint;
    public GameObject Water;
    public bool canWater = false;
    public bool canStart = false;

    public float maxCooldown;
    public float currentCooldown;


    // Start is called before the first frame update
    void Start()
    {
        maxCooldown = 0.1f;
        currentCooldown = maxCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (canStart == true)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown < 0)
            {
                canWater = true;
                currentCooldown = maxCooldown;
            }
            else
            {
                canWater = false;
            }

            if (canWater == true)
            {
                Instantiate(Water, WaterSpawnpoint.transform.position, Quaternion.identity);
            }
        }
    }

    public void StartWater()
    {
        canStart = true;
    }
}
