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
    public int cardRarity;

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
    public float vlightPity;
    public float lightPity;
    public float heavyPity;
    public float vheavyPity;


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
            //card.GetComponent<CardValueDisplay>().SetCardValue(cardRarity);
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
            cardRarity = 1;
            legendarySpawned = true;
        }
        else if (percentage > legendaryOdds && percentage <= legendaryOdds + epicOdds)
        {
            cardToInstantiate = epicCard;
            cardValue = CardPackWeight.epicValue;
            cardRarity = 2;
        }
        else if (percentage > legendaryOdds + epicOdds && percentage <= legendaryOdds + epicOdds + rareOdds)
        {
            cardToInstantiate = rareCard;
            cardValue = CardPackWeight.rareValue;
            cardRarity = 3;
        }
        else
        {
            cardToInstantiate = commonCard;
            cardValue = CardPackWeight.commonValue;
            cardRarity = 4;
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
                CardPackWeight.legendaryPity += vlightPity;
            }
            if (packType == 2) //light
            {
                CardPackWeight.legendaryPity += lightPity;
            }
            if (packType == 3) //heavy
            {
                CardPackWeight.legendaryPity += heavyPity;
            }
            if (packType == 4) //vheavy
            {
                CardPackWeight.legendaryPity += vheavyPity;
            }
        }
    }
}
