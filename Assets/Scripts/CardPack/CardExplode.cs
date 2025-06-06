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
    public bool lockCardClicking = false;
    public float moveSpeed = 50f;

    private Vector3 originalScale;
    private Vector3 targetScale;


    public Vector3 boardPosition;


    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = gameObject.GetComponent<CardInstantiator>();
        CardPackTilter = gameObject.GetComponent <CardPackTilter>();

        originalScale = transform.localScale;
        targetScale = originalScale * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (explode == true)
        {
            lockCardClicking = true;
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
            //StartCoroutine(Shrink());
            int number = card.GetComponent<MoveCard>().cardNumber;

            StartCoroutine(MoveCardToPoint(card, explodePoint));

            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator MoveCardToPoint(GameObject card, Vector2 target)
    {
        float elapsedTime = 0f;
        Vector2 startPos = card.transform.position;
        float duration = 0.15f; // adjust to control how long the card moves

        while (elapsedTime < duration)
        {
            card.transform.position = Vector2.Lerp(startPos, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        card.transform.position = target;
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
