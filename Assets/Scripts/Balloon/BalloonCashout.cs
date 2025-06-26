using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalloonCashout : MonoBehaviour
{
    public TMP_Text walletText;
    public TMP_Text walletSmallText;
    public float walletValue = 0;
    public GameObject OldBalloon;
    public float balloonValue;
    public float balloonCost;

    public GameObject NewBalloon;
    public GameObject BuyBalloonButton;
    public PumpAir pumpAir;

    public BalloonProbability balloonProbability;


    // Start is called before the first frame update
    void Start()
    {
        walletValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddWalletValue();
        }

        walletText.text = "Wallet: $" + walletValue.ToString("F2");
    }

    public void AddWalletValue() // cashout
    {
        OldBalloon = GameObject.Find("Balloon(Clone)");
        balloonValue = OldBalloon.GetComponent<BalloonValue>().newValue;

        Destroy(OldBalloon);
        ToggleBuyBalloonButton();
        //StartCoroutine (InstantiateBalloon(1f));

        walletValue += balloonValue;
        walletSmallText.text = "+ $" + balloonValue.ToString("F2");
        walletSmallText.color = Color.green;
        walletSmallText.gameObject.SetActive(true);
        StartCoroutine(HideText(walletSmallText));
    }

    public void SubtractWalletValue() // buy new balloon
    {
        if (walletValue > balloonCost)
        {
            walletValue -= balloonCost;
            walletSmallText.text = "- $10";
            walletSmallText.color = Color.red;
            walletSmallText.gameObject.SetActive(true);
            StartCoroutine(HideText(walletSmallText));

            ToggleBuyBalloonButton();
            StartCoroutine(InstantiateBalloon(0f));
            //balloonProbability.balloonExplode = GameObject.Find("Balloon(Clone)").GetComponent<BalloonExplode>();
        }
    }

    public IEnumerator InstantiateBalloon(float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(NewBalloon, gameObject.transform.position, Quaternion.identity);

        pumpAir.ReferenceNewBalloon();
        balloonProbability.ReferenceNewBalloon();
    }

    public void ToggleBuyBalloonButton()
    {
        if (BuyBalloonButton.activeSelf == true)
        {
            BuyBalloonButton.SetActive(false);
        }
        else
        {
            BuyBalloonButton.SetActive(true);
        }
    }

    public IEnumerator HideText(TMP_Text textToHide)
    {
        textToHide.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        textToHide.gameObject.SetActive(false);
    }
}
