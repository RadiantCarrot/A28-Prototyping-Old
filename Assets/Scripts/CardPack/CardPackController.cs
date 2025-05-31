using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CardPackController : MonoBehaviour
{
    public List<GameObject> cardPacks = new List<GameObject>();
    public List<GameObject> packSpawnpoints = new List<GameObject>();
    public List<GameObject> packsToDestroy = new List<GameObject>();

    public GameObject vlightPack;
    public GameObject lightPack;
    public GameObject heavyPack;
    public GameObject vheavyPack;

    public int vlightPackCount = 2;
    public int lightPackCount = 2;
    public int heavyPackCount = 2;
    public int vheavyPackCount = 2;

    public bool cardpackSelected = false;
    public bool canInactivePacks = true;


    // Start is called before the first frame update
    void Start()
    {
        InstantiatePacks(8);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOtherPacks();
    }

    public void InstantiatePacks(int packCount)
    {
        foreach (GameObject spawnpoint in packSpawnpoints)
        {
            if (vlightPackCount != 0)
            {
                GameObject cardpack = Instantiate(vlightPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardpack);
                vlightPackCount--;
            }
            else if (lightPackCount != 0)
            {
                GameObject cardpack = Instantiate(lightPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardpack);
                lightPackCount--;
            }
            else if (heavyPackCount != 0)
            {
                GameObject cardpack = Instantiate(heavyPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardpack);
                heavyPackCount--;
            }
            else if (vheavyPackCount != 0)
            {
                GameObject cardpack = Instantiate(vheavyPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardpack);
                vheavyPackCount--;
            }
        }
    }

    public void DestroyOtherPacks()
    {
        if (cardpackSelected == true && canInactivePacks == true)
        {
            for (int i = 1; i < cardPacks.Count; i++)
            {
                cardPacks[i].gameObject.SetActive(false);
            }

            canInactivePacks = false;
        }
    }
}
