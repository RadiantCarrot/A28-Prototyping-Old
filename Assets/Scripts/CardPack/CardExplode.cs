using System.Collections;
using UnityEngine;

public class CardExplode : MonoBehaviour
{
    public GameObject explodePoint1;
    public GameObject explodePoint2;
    public GameObject explodePoint3;
    public Vector3 explodePoint;

    public CardInstantiator CardInstantiator;
    public CardPackTilter CardPackTilter;

    public bool explode = false;
    public float moveSpeed = 50f;

    private Vector3 originalScale;
    private Vector3 targetScale;

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
    public Vector3 boardPosition;


    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = gameObject.GetComponent<CardInstantiator>();
        CardPackTilter = gameObject.GetComponent <CardPackTilter>();

        originalScale = transform.localScale;
        targetScale = originalScale * 0.5f;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (explode == true)
        {
            ExplodeCards();
            explode = false;
        }
    }

    public void ExplodeCards()
    {
        CardPackTilter.canTilt = false;
        StartCoroutine(ExplodeCardsCoroutine());
    }

    public void RandomiseExplodePoint()
    {
        int point = Random.Range(1, 4);

        switch (point)
        {
            case 1:
                explodePoint = explodePoint1.transform.position;
                break;
            case 2:
                explodePoint = explodePoint2.transform.position;
                break;
            case 3:
                explodePoint = explodePoint3.transform.position;
                break;
        }
    }

    private IEnumerator ExplodeCardsCoroutine()
    {
        foreach (GameObject card in CardInstantiator.cards)
        {
            card.SetActive(true);
            RandomiseExplodePoint();
            StartCoroutine(Shrink());
            int number = card.GetComponent<MoveCard>().cardNumber;
            //SetBoardNumber(number);

            StartCoroutine(MoveCardToPoint(card, explodePoint));

            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator MoveCardToPoint(GameObject card, Vector2 target)
    {
        float elapsedTime = 0f;
        Vector2 startPos = card.transform.position;
        float duration = 0.2f; // adjust to control how long the card moves

        while (elapsedTime < duration)
        {
            card.transform.position = Vector2.Lerp(startPos, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        card.transform.position = target;

        yield return new WaitForSeconds(4f);
        card.GetComponent<MoveCard>().CardClicked();

        // Reset elapsedTime for second move
        elapsedTime = 0f;
        card.GetComponent<MoveCard>().SetBoardNumber(card.GetComponent<MoveCard>().cardNumber);

        Vector2 secondStartPos = card.transform.position;
        boardPosition = card.GetComponent<MoveCard>().boardPosition;
        while (elapsedTime < duration)
        {
            card.transform.position = Vector2.Lerp(secondStartPos, boardPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //card.transform.position = boardPosition;
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

    /*public void SetBoardNumber(int number)
    {
        if (number == 9)
        {
            boardPosition = boardPosition0.transform.position;
        }
        if (number == 8)
        {
            boardPosition = boardPosition1.transform.position;
        }
        if (number == 7)
        {
            boardPosition = boardPosition2.transform.position;
        }
        if (number == 6)
        {
            boardPosition = boardPosition3.transform.position;
        }
        if (number == 5)
        {
            boardPosition = boardPosition4.transform.position;
        }
        if (number == 4)
        {
            boardPosition = boardPosition5.transform.position;
        }
        if (number == 3)
        {
            boardPosition = boardPosition6.transform.position;
        }
        if (number == 2)
        {
            boardPosition = boardPosition7.transform.position;
        }
        if (number == 1)
        {
            boardPosition = boardPosition8.transform.position;
        }
        if (number == 0)
        {
            boardPosition = boardPosition9.transform.position;
        }
    }*/
}
