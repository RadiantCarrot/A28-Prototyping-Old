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

    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = GameObject.Find("PackManager").GetComponent<CardInstantiator>();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();
        StartCoroutine(HideTop());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsObjectClicked())
        {
            PackClicked();
        }
    }

    public void PackClicked()
    {
        if (canClick == true)
        {
            arrow.SetActive(true);
            RealTop.SetActive(true);
            Destroy(FakeTop);

            CardInstantiator.InstantiateCards();
            CardPackGrab.canTear = true;
            CardPackGrab.cardPack = gameObject;

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

    public IEnumerator HideTop()
    {
        yield return new WaitForSeconds(0.25f);
        RealTop.SetActive(false);
    }
}
