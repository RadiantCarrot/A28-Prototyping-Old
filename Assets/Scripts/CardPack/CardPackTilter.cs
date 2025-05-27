using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardPackTilter : MonoBehaviour
{
    public Vector3 mousePosition;
    public CardInstantiator CardInstantiator;
    public CardPackGrab CardPackGrab;

    public float moveSpeed = 10f;

    public bool canHideCards = true;
    public bool canTilt = true;


    // Start is called before the first frame update
    void Start()
    {
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();
        CardInstantiator = gameObject.GetComponent<CardInstantiator>();
        moveSpeed = 10f;

        canHideCards = true;
        canTilt = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x > -2 && mousePosition.x < 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (canHideCards == true)
                {
                    foreach (GameObject card in CardInstantiator.cards)
                    {
                        card.SetActive(false);
                    }
                    canHideCards = false;
                }
            }
        }

        if (MoveCard.lockTilting == false && CardPackGrab.reset == false && canTilt == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (mousePosition.x < -2)
                {
                    foreach (GameObject card in CardInstantiator.cards)
                    {
                        card.SetActive(true);
                        card.transform.position = Vector2.Lerp(card.transform.position, card.GetComponent<MoveCard>().shiftPositionLeft, moveSpeed * Time.deltaTime);
                    }
                }
                else if (mousePosition.x > 2)
                {
                    foreach (GameObject card in CardInstantiator.cards)
                    {
                        card.SetActive(true);
                        card.transform.position = Vector2.Lerp(card.transform.position, card.GetComponent<MoveCard>().shiftPositionRight, moveSpeed * Time.deltaTime);
                    }
                }
            }
            else
            {
                foreach (GameObject card in CardInstantiator.cards)
                {
                    card.transform.position = Vector2.Lerp(card.transform.position, card.GetComponent<MoveCard>().originalPosition, moveSpeed * Time.deltaTime);
                }
            }
        }
    }
}
