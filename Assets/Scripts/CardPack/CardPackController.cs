using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardPackController : MonoBehaviour
{
    public List<GameObject> cardPacks = new List<GameObject>();
    public List<GameObject> packSpawnpoints = new List<GameObject>();
    public GameObject spawnpoint; // Main spawnpoint for upgraded packs 
    public List<GameObject> packsToDestroy = new List<GameObject>();
    public int spawnpointIndex = 0;

    public GameObject vlightPack; // 1 for vlight, 2 for light, 3 for heavy, 4 for vheavy
    public GameObject lightPack;
    public GameObject heavyPack;
    public GameObject vheavyPack;

    public int vlightPackCount = 2;
    public int lightPackCount = 2;
    public int heavyPackCount = 2;
    public int vheavyPackCount = 2;

    public bool canInactivePacks = true;

    public int packPosition;
    public int indexIncrement = 0;
    public int indexDecrement = 0;

    public float dragThreshold = 50f; // Minimum distance to trigger swipe
    private Vector2 dragStartPos;
    private bool isDragging = false;
    private bool canDrag = true;
    public float moveDuration = 0.3f;

    public CardInstantiator CardInstantiator;
    public TMP_Text statusText;
    public bool hideTop = true;


    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = gameObject.GetComponent<CardInstantiator>();

        cardPacks.Clear();
        packsToDestroy.Clear();
        InstantiatePacks();
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrag == true)
        {
            HandleMouseDrag();
        }
    }

    public void InstantiatePacks()
    {
        foreach (GameObject spawnpoint in packSpawnpoints)
        {
            if (vlightPackCount != 0)
            {
                GameObject cardpack = Instantiate(vlightPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardpack);
                cardpack.GetComponent<CardPackSelect>().packType = 1;
                vlightPackCount--;
            }
            else if (vheavyPackCount != 0)
            {
                GameObject cardpack = Instantiate(vheavyPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                
                cardPacks.Add(cardpack);
                cardpack.GetComponent<CardPackSelect>().packType = 4;
                vheavyPackCount--;
            }
            else if (heavyPackCount != 0)
            {
                GameObject cardpack = Instantiate(heavyPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardpack);
                cardpack.GetComponent<CardPackSelect>().packType = 3;
                heavyPackCount--;
            }
            else if (lightPackCount != 0)
            {
                GameObject cardpack = Instantiate(lightPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
                cardPacks.Add(cardpack);
                cardpack.GetComponent<CardPackSelect>().packType = 2;
                lightPackCount--;
            }
            spawnpointIndex++;
        }
    }

    public void InstantiateUpgradedPack(int packType)
    {
        hideTop = false;
        statusText.text = "Pack Upgrade!";

        if (packType == 2)
        {
            GameObject cardpack = Instantiate(lightPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
            cardpack.GetComponent<CardPackSelect>().packType = 2;
            CardInstantiator.InstantiateCards(cardpack);
        }
        if (packType == 3)
        {
            GameObject cardpack = Instantiate(heavyPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
            cardpack.GetComponent<CardPackSelect>().packType = 3;
            CardInstantiator.InstantiateCards(cardpack);
        }
        if (packType >= 4)
        {
            GameObject cardpack = Instantiate(vheavyPack, spawnpoint.transform.position, spawnpoint.transform.rotation);
            cardpack.GetComponent<CardPackSelect>().packType = 4;
            CardInstantiator.InstantiateCards(cardpack);
        }
    }

    public void DestroyOtherPacks(bool packUpgraded, int packType) 
    {
        if (canInactivePacks == true)
        {
            if (packUpgraded == true)
            {
                InstantiateUpgradedPack(packType);

                foreach (GameObject cardpack in cardPacks)
                {
                    Destroy(cardpack);
                    canDrag = false;
                }
            }
            else
            {
                foreach (GameObject cardpack in cardPacks)
                {
                    if (cardpack.GetComponent<CardPackSelect>().packPosition != 1)
                    {
                        Destroy(cardpack);
                        canDrag = false;
                    }
                }
            }

            canInactivePacks = false;
        }
    }

    public void CycleLeft()
    {
        indexIncrement += 1;

        int totalSpawnpoints = packSpawnpoints.Count;

        foreach (GameObject cardpack in cardPacks)
        {
            int packIndex = cardPacks.IndexOf(cardpack);
            int targetIndex = WrapIndex(packIndex + indexIncrement, totalSpawnpoints);

            CardPackSpawnCollider cpsc = packSpawnpoints[targetIndex].GetComponent<CardPackSpawnCollider>();
            Vector3 targetPos = cpsc.transform.position;

            cardpack.GetComponent<CardPackSelect>().packPosition = cpsc.spawnpointNumber;

            StartCoroutine(MoveToPosition(cardpack, targetPos, moveDuration));
            cardpack.GetComponent<CardPackSelect>().scalePacks = true;
        }
    }

    public void CycleRight()
    {
        indexIncrement -= 1;

        int totalSpawnpoints = packSpawnpoints.Count;

        foreach (GameObject cardpack in cardPacks)
        {
            int packIndex = cardPacks.IndexOf(cardpack);
            int targetIndex = WrapIndex(packIndex + indexIncrement, totalSpawnpoints);

            CardPackSpawnCollider cpsc = packSpawnpoints[targetIndex].GetComponent<CardPackSpawnCollider>();
            Vector3 targetPos = cpsc.transform.position;

            cardpack.GetComponent<CardPackSelect>().packPosition = cpsc.spawnpointNumber;

            StartCoroutine(MoveToPosition(cardpack, targetPos, moveDuration));
            cardpack.GetComponent<CardPackSelect>().scalePacks = true;
        }
    }


    int WrapIndex(int index, int count)
    {
        return (index % count + count) % count;
    }

    private IEnumerator MoveToPosition(GameObject obj, Vector3 target, float duration)
    {
        Vector3 start = obj.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
            obj.GetComponent<CardPackSelect>().canClick = false;
        }

        obj.transform.position = target; // Snap to exact final position
        obj.GetComponent<CardPackSelect>().canClick = true;
    }

    void HandleMouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            Vector2 dragEndPos = Input.mousePosition;
            float dragDistance = dragEndPos.x - dragStartPos.x;

            if (Mathf.Abs(dragDistance) > dragThreshold)
            {
                if (dragDistance < 0)
                {
                    CycleLeft();  // Dragged left
                }
                else
                {
                    CycleRight(); // Dragged right
                }
            }

            isDragging = false;
        }
    }
}
