using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawner : MonoBehaviour
{
    public float plateForce = 1.5f;

    public GameObject Plate;
    public GameObject plateSpawner;

    public float currentCooldown;
    public float maxCooldown = 1;


    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = maxCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = 0;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentCooldown <= 0)
            {
                GameObject spawnedPlate = Instantiate(Plate, plateSpawner.transform.position, plateSpawner.transform.rotation);
                spawnedPlate.GetComponent<Rigidbody2D>().AddForce(transform.right * 1.5f, ForceMode2D.Impulse);

                currentCooldown = maxCooldown;
            }
        }
    }
}
