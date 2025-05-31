using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class MoveCard : MonoBehaviour
{
    public GameObject boardPosition0;
    public GameObject boardPosition1;
    public GameObject boardPosition2;
    public GameObject boardPosition3;
    public GameObject boardPosition4;
    public GameObject boardPosition5;
    public GameObject boardPosition6;
    public GameObject boardPosition7;
    public GameObject boardPosition8;
    public GameObject boardPosition9;
    public float moveSpeed = 0.01f;
    public Vector3 boardPosition;
    public Vector3 shiftPositionLeft;
    public Vector3 shiftPositionRight;

    public CardInstantiator CardInstantiator;
    public GameObject Anchor;
    public CardPackGrab CardPackGrab;
    public int cardNumber;

    public bool cardClicked = false;
    public static bool lockTilting = false;

    public Vector3 originalPosition;
    private Vector3 originalScale;
    private Vector3 targetScale;

    public bool canHideCards = true;


    // Start is called before the first frame update
    void Start()
    {
        boardPosition0 = GameObject.Find("Position9");
        boardPosition1 = GameObject.Find("Position8");
        boardPosition2 = GameObject.Find("Position7");
        boardPosition3 = GameObject.Find("Position6");
        boardPosition4 = GameObject.Find("Position5");
        boardPosition5 = GameObject.Find("Position4");
        boardPosition6 = GameObject.Find("Position3");
        boardPosition7 = GameObject.Find("Position2");
        boardPosition8 = GameObject.Find("Position1");
        boardPosition9 = GameObject.Find("Position0");

        CardInstantiator = GameObject.Find("PackManager").GetComponent<CardInstantiator>();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();

        SetBoardNumber(cardNumber);

        originalPosition = new Vector3(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y - 4, 0);
        //gameObject.transform.parent = null;
        originalScale = transform.localScale;
        targetScale = originalScale * 0.5f;

        lockTilting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsObjectClicked())
        {
            cardClicked = true;
        }

        if (cardClicked == true)
        {
            CardClicked();
        }
    }

    public void CardClicked()
    {
        if (canHideCards == true)
        {
            foreach (GameObject card in CardInstantiator.cards)
            {
                card.SetActive(false);
            }
            canHideCards = false;
        }
        else
        {
            lockTilting = true;
            gameObject.transform.position = Vector2.Lerp(transform.position, boardPosition, moveSpeed * Time.deltaTime);
            StartCoroutine(Shrink());
            CardInstantiator.cards.Remove(gameObject);
        }
    }

    bool IsObjectClicked()
    {
        if (Input.GetMouseButtonDown(0) && CardPackGrab.reset == false) // Left mouse button
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.transform == transform)
            {
                return true;
            }
        }
        return false;
    }

    public void SetBoardNumber(int number)
    {
        if (number == 0)
        {
            boardPosition = boardPosition0.transform.position;
            shiftPositionLeft = new Vector3 (originalPosition.x + 0.4f, originalPosition.y - 5,0);
            shiftPositionRight = new Vector3(originalPosition.x - 0.4f, originalPosition.y - 5, 0);
        }
        if (number == 1)
        {
            boardPosition = boardPosition1.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x + 0.3f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x - 0.3f, originalPosition.y - 5, 0);
        }
        if (number == 2)
        {
            boardPosition = boardPosition2.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x + 0.2f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x - 0.2f, originalPosition.y - 5, 0);
        }
        if (number == 3)
        {
            boardPosition = boardPosition3.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x + 0.1f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x - 0.1f, originalPosition.y - 5, 0);
        }
        if (number == 4)
        {
            boardPosition = boardPosition4.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x + 0f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x - 0f, originalPosition.y - 5, 0);
        }
        if (number == 5)
        {
            boardPosition = boardPosition5.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x - 0.1f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x + 0.1f, originalPosition.y - 5, 0);
        }
        if (number == 6)
        {
            boardPosition = boardPosition6.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x - 0.2f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x + 0.2f, originalPosition.y - 5, 0);
        }
        if (number == 7)
        {
            boardPosition = boardPosition7.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x - 0.3f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x + 0.3f, originalPosition.y - 5, 0);
        }
        if (number == 8)
        {
            boardPosition = boardPosition8.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x - 0.4f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x + 0.4f, originalPosition.y - 5, 0);
        }
        if (number == 9)
        {
            boardPosition = boardPosition9.transform.position;
            shiftPositionLeft = new Vector3(originalPosition.x - 0.5f, originalPosition.y - 5, 0);
            shiftPositionRight = new Vector3(originalPosition.x + 0.5f, originalPosition.y - 5, 0);
        }
    }

    private IEnumerator Shrink()
    {
        float elapsed = 0f;

        while (elapsed < 0.5f)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsed / 0.5f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale; // Ensure exact final scale
    }
}
