using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = GameObject.Find("PackManager").GetComponent<CardInstantiator>();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();
        CardPackController = GameObject.Find("PackManager").GetComponent<CardPackController>();

        RealTop = GameObject.Find("RealTop");
        StartCoroutine(HideTop());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsObjectClicked())
        {
            PackClicked();
        }

        if (IsMouseOver())
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
        if (canClick == true)
        {
            //arrow.SetActive(true);
            RealTop.SetActive(true);
            Destroy(FakeTop);

            CardInstantiator.InstantiateCards();
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
}
