using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalloonCashout : MonoBehaviour
{
    public TMP_Text walletText;
    public float walletValue = 0;
    public GameObject OldBalloon;
    public float balloonValue;

    public GameObject NewBalloon;
    public GameObject BuyBalloonButton;
    public PumpAir pumpAir;


    // Start is called before the first frame update
    void Start()
    {
        pumpAir = GameObject.Find("Pump").GetComponent<PumpAir>();
        walletValue = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddWalletValue();
        }

        walletText.text = "$" + walletValue.ToString("F2");
    }

    public void AddWalletValue() // cashout
    {
        OldBalloon = GameObject.Find("Balloon(Clone)");
        balloonValue = OldBalloon.GetComponent<BalloonValue>().newValue;

        Destroy(OldBalloon);
        ToggleBuyBalloonButton();
        //StartCoroutine (InstantiateBalloon(1f));

        walletValue += balloonValue;
    }

    public void SubtractWalletValue() // buy new balloon
    {
        if (walletValue > 10)
        {
            walletValue -= 10;
            ToggleBuyBalloonButton();
            StartCoroutine(InstantiateBalloon(0f));
        }
    }

    public IEnumerator InstantiateBalloon(float spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(NewBalloon, gameObject.transform.position, Quaternion.identity);
        pumpAir.ReferenceNewBalloon();
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
}
