using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public CardPackWeight CardPackWeight;

    public int packPosition;
    public int packType; // 1 for vlight, 2 for light, 3 for heavy, 4 for vheavy
    private int lastPackPosition = -1;

    public bool scalePacks = false;
    private Vector3 bigScale;
    private Vector3 mediumScale;
    private Vector3 smallScale;
    private Vector3 tinyScale;
    public float scaleDuration = 0.1f;

    public int upgradeThreshold = 5;
    public bool upgradePack = false;
    public TMP_Text statusText;


    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = GameObject.Find("PackManager").GetComponent<CardInstantiator>();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();
        CardPackController = GameObject.Find("PackManager").GetComponent<CardPackController>();
        CardPackWeight = GameObject.Find("GameManager").GetComponent<CardPackWeight>();
        arrow = GameObject.Find("Arrow");
        statusText = GameObject.Find("StatusText").GetComponent<TextMeshProUGUI>();

        RealTop = GameObject.Find("RealTop");
        StartCoroutine(HideTop());

        bigScale = transform.localScale;
        mediumScale = bigScale * 0.8f;
        smallScale = bigScale * 0.6f;
        tinyScale = bigScale * 0.4f;

        scalePacks = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (packPosition != lastPackPosition)
        {
            lastPackPosition = packPosition;
            if(packPosition == 1) isFrontPack = true;
            else isFrontPack = false;
        }
        ScalePacks();


        if (IsObjectClicked())
        {
            PackClicked();
        }

        if (isFrontPack == true)
        {
            CardPackWeight.UpdateOdds(packType);
        }
    }

    public void PackClicked()
    {
        if (CardPackWeight.packCost <= CardPackWeight.playerWallet)
        {
            statusText.text = "";
            if (canClick == true && isFrontPack == true)
            {
                statusText.text = "";

                if (packType != 4)
                {
                    TryUpgrade();
                }

                if (upgradePack == true)
                {
                    CardPackWeight.ConfirmWeight(packType + 1);
                    CardPackController.DestroyOtherPacks(true, packType + 1);
                }
                else
                {
                    CardPackWeight.ConfirmWeight(packType);
                    CardPackController.DestroyOtherPacks(false, 1);
                    CardInstantiator.InstantiateCards(gameObject);
                }

                arrow.SetActive(true);
                RealTop.SetActive(true);
                Destroy(FakeTop);

                CardPackGrab.canTear = true;
                CardPackGrab.cardPack = gameObject;

                CardPackWeight.SubtractMoney(CardPackWeight.packCost);

                canClick = false;
            }
        }
        else
        {
            statusText.text = "Press 'M' to refill wallet";
        }
    }

    public void TryUpgrade()
    {
        float upgradeAmount = Random.Range(1, 101);

        if (upgradeAmount <= upgradeThreshold)
        {
            upgradePack = true;
        }
    }

    public void InstantiateCards()
    {
        CardInstantiator.InstantiateCards(gameObject);
        CardPackGrab.canTear = true;
        CardPackGrab.cardPack = gameObject;
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
        if (CardPackController.hideTop == true)
        {
            RealTop.SetActive(false);
        }
        else
        {
            CardPackGrab.canTear = true;
            CardPackGrab.cardPack = gameObject;
            Destroy(FakeTop);
        }
    }


    public void ScalePacks()
    {
        Vector3 targetScale = transform.localScale;

        switch (packPosition)
        {
            case 1:
                targetScale = LerpTarget(targetScale, bigScale);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
                break;
            case 2:
            case 8:
                targetScale = LerpTarget(targetScale, mediumScale);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 14;
                break;
            case 3:
            case 7:
                targetScale = LerpTarget(targetScale, smallScale);
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 13;
                break;
            case 4:
            case 5:
            case 6:
                targetScale = LerpTarget(targetScale, tinyScale);
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

    Vector3 LerpTarget(Vector3 targetScale, Vector3 scaleSize)
    {
        targetScale = Vector3.Lerp(targetScale, scaleSize, Time.fixedDeltaTime * 10f);
        return targetScale;
    }

    private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 initialScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsed / duration);
            //scalePacks = false;
            elapsed += Time.deltaTime * 5;
            yield return null;
        }

        transform.localScale = targetScale; // Snap to final scale
        //scalePacks = true;
    }
}
