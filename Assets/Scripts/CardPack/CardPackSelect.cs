using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class CardPackSelect : MonoBehaviour
{
    public bool canClick = true;
    public CardInstantiator CardInstantiator;
    public GameObject RealTop;
    public GameObject FakeTop;
    public bool isFrontPack = false;

    public CardPackGrab CardPackGrab;
    public GameObject arrow;
    public GameObject packDetails;

    public CardPackController CardPackController;

    public int packPosition;
    private int lastPackPosition = -1;
    public bool scalePacks = false;

    private Vector3 bigScale;
    private Vector3 mediumScale;
    private Vector3 smallScale;
    private Vector3 tinyScale;
    public float scaleDuration = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = GameObject.Find("PackManager").GetComponent<CardInstantiator>();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();
        CardPackController = GameObject.Find("PackManager").GetComponent<CardPackController>();
        arrow = GameObject.Find("Arrow");

        RealTop = GameObject.Find("RealTop");
        StartCoroutine(HideTop());

        bigScale = transform.localScale;
        mediumScale = bigScale * 0.8f;
        smallScale = bigScale * 0.6f;
        tinyScale = bigScale * 0.4f;

        scalePacks = true;
        ScalePacks();
    }

    // Update is called once per frame
    void Update()
    {
        if (scalePacks == true)
        {
            if (packPosition != lastPackPosition)
            {
                ScalePacks();
                lastPackPosition = packPosition;
            }
        }


        if (IsObjectClicked())
        {
            PackClicked();
        }

        if (IsMouseOver() && isFrontPack == true)
        {
            packDetails.SetActive(true);
        }
        else
        {
            packDetails.SetActive(false);
        }
    }

    public void PackClicked()
    {
        if (canClick == true && isFrontPack == true)
        {
            arrow.SetActive(true);
            RealTop.SetActive(true);
            Destroy(FakeTop);

            CardInstantiator.InstantiateCards(gameObject);
            CardPackGrab.canTear = true;
            CardPackGrab.cardPack = gameObject;

            CardPackController.cardpackSelected = true;

            canClick = false;
        }
    }

    bool IsObjectClicked()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
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

    bool IsMouseOver()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos);

        return hit != null && hit.transform == transform;
    }

    public IEnumerator HideTop()
    {
        yield return new WaitForSeconds(0.25f);
        RealTop.SetActive(false);
    }


    public void ScalePacks()
    {
        Vector3 targetScale = transform.localScale;

        switch (packPosition)
        {
            case 1:
                targetScale = bigScale;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
                break;
            case 2:
            case 8:
                targetScale = mediumScale;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 14;
                break;
            case 3:
            case 7:
                targetScale = smallScale;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 13;
                break;
            case 4:
            case 5:
            case 6:
                targetScale = tinyScale;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 12;
                break;
        }

        foreach (Transform child in transform)
        {
            Canvas canvasRenderer = child.GetComponent<Canvas>();
            if (canvasRenderer != null)
            {
                canvasRenderer.sortingOrder = transform.GetComponentInParent<SpriteRenderer>().sortingOrder;
            }
        }

        StartCoroutine(ScaleOverTime(targetScale, scaleDuration));
    }

    private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 initialScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime * 5;
            yield return null;
        }

        transform.localScale = targetScale; // Snap to final scale
        scalePacks = false;
    }
}
