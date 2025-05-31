using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPackController : MonoBehaviour
{
    public List<GameObject> cardPacks = new List<GameObject>();
    public List<GameObject> packSpawnpoints = new List<GameObject>();

    public GameObject vlightPack;
    public GameObject lightPack;
    public GameObject heavyPack;
    public GameObject vheavyPack;

    public int vlightPackCount = 2;
    public int lightPackCount = 2;
    public int heavyPackCount = 2;
    public int vheavyPackCount = 2;


    // Start is called before the first frame update
    void Start()
    {
        InstantiatePacks(8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiatePacks(int packCount)
    {
        foreach (GameObject spawnpoint in packSpawnpoints)
        {
            if (vlightPackCount != 0)
            {
                GameObject cardPack = Instantiate(vlightPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardPack);
                vlightPackCount--;
            }
            else if (lightPackCount != 0)
            {
                GameObject cardPack = Instantiate(lightPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardPack);
                lightPackCount--;
            }
            else if (heavyPackCount != 0)
            {
                GameObject cardPack = Instantiate(heavyPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardPack);
                heavyPackCount--;
            }
            else if (vheavyPackCount != 0)
            {
                GameObject cardPack = Instantiate(vheavyPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardPack);
                vheavyPackCount--;
            }
        }
    }
}
