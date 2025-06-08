using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstantiator : MonoBehaviour
{
    public List <GameObject> cards = new List <GameObject> ();
    public int cardCount = 10;
    public GameObject cardPack;

    public GameObject commonCard;
    public GameObject rareCard;
    public GameObject epicCard;
    public GameObject legendaryCard;
    public GameObject cardToInstantiate;

    public int cardNumber = 0;
    public bool canReveal = false;

    public CardPackGrab CardPackGrab;

    public float legendaryOdds;
    public float epicOdds;
    public float rareOdds;
    public float commonOdds;

    public CardPackWeight CardPackWeight;
    public float cardValue;
    public bool legendarySpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        cards.Clear();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();
        CardPackWeight = GameObject.Find("GameManager").GetComponent <CardPackWeight>();

        canReveal = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cards.Count >= 1)
        {
            GameObject lastCard = cards[cards.Count - 1];
            lastCard.SetActive(true);
        }
    }

    public void InstantiateCards(GameObject cardpack)
    {
        for (int i = 0; i < cardCount; i++)
        {
            RandomiseCards();
            CardPackWeight.AddEarnings(cardValue);
            GameObject card = Instantiate(cardToInstantiate);
            cardPack = cardpack;
            card.transform.SetParent(cardPack.transform);
            card.name = "Card " + i.ToString();
            card.GetComponent<SpriteRenderer>().sortingOrder = i;
            card.GetComponent<MoveCard>().cardNumber = i;
            cards.Add(card);
        }

        CheckLegendary();
    }

    public void RandomiseCards()
    {
        int percentage = Random.Range(1, 101);

        if (percentage <= legendaryOdds)
        {
            cardToInstantiate = legendaryCard;
            cardValue = CardPackWeight.legendaryValue;
            legendarySpawned = true;
        }
        else if (percentage > legendaryOdds && percentage <= legendaryOdds + epicOdds)
        {
            cardToInstantiate = epicCard;
            cardValue = CardPackWeight.epicValue;
        }
        else if (percentage > legendaryOdds + epicOdds && percentage <= legendaryOdds + epicOdds + rareOdds)
        {
            cardToInstantiate = rareCard;
            cardValue = CardPackWeight.rareValue;
        }
        else
        {
            cardToInstantiate = commonCard;
            cardValue = CardPackWeight.commonValue;
        }
    }

    public void CheckLegendary()
    {
        if (legendarySpawned == true)
        {
            CardPackWeight.legendaryPity = 0;
            legendarySpawned = false;
        }
        else
        {
            int packType = cardPack.GetComponent<CardPackSelect>().packType;

            if (packType == 1) //vlight
            {
                CardPackWeight.legendaryPity += 2f;
            }
            if (packType == 2) //light
            {
                CardPackWeight.legendaryPity += 1.5f;
            }
            if (packType == 3) //heavy
            {
                CardPackWeight.legendaryPity += 1f;
            }
            if (packType == 4) //vheavy
            {
                CardPackWeight.legendaryPity += 0.5f;
            }
        }
    }
}
