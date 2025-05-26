using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstantiator : MonoBehaviour
{
    public List <GameObject> cards = new List <GameObject> ();
    public int cardCount = 10;

    public GameObject commonCard;
    public GameObject rareCard;
    public GameObject epicCard;
    public GameObject legendaryCard;
    public GameObject cardToInstantiate;

    public int cardNumber = 0;
    public bool canReveal = false;

    public CardPackGrab CardPackGrab;

    public int legendaryOdds;
    public int epicOdds;
    public int rareOdds;
    public int commonOdds;


    // Start is called before the first frame update
    void Start()
    {
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();

        canReveal = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canReveal == true && cards.Count >= 1)
        {
            GameObject lastCard = cards[cards.Count - 1];
            lastCard.SetActive(true);
        }
    }

    public void InstantiateCards()
    {
        for (int i = 0; i < cardCount; i++)
        {
            RandomiseCards();
            GameObject card = Instantiate(cardToInstantiate);
            card.name = "Card " + i.ToString();
            card.GetComponent<SpriteRenderer>().sortingOrder = i;
            card.GetComponent<MoveCard>().cardNumber = i;
            //cardNumber += 1;
            cards.Add(card);
        }
    }

    public void RandomiseCards()
    {
        int percentage = Random.Range(1, 101);

        if (percentage <= legendaryOdds)
        {
            cardToInstantiate = legendaryCard;
        }
        else if (percentage > legendaryOdds && percentage <= legendaryOdds + epicOdds)
        {
            cardToInstantiate = epicCard;
        }
        else if (percentage > legendaryOdds + epicOdds && percentage <= legendaryOdds + epicOdds + rareOdds)
        {
            cardToInstantiate = rareCard;
        }
        else
        {
            cardToInstantiate = commonCard;
        }
    }
}
