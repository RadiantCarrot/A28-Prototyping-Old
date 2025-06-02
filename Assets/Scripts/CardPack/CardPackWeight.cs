using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardPackWeight : MonoBehaviour
{

    public CardInstantiator CardInstantiator;
    public CardPackGrab CardPackGrab;
    public GameObject arrow;

    public int originalLegendaryOdds;
    public TMP_Text legendaryText;
    public int originalEpicOdds;
    public TMP_Text epicText;
    public int originalRareOdds;
    public TMP_Text rareText;
    public int originalCommonOdds;
    public TMP_Text commonText;

    public float legendaryValue;
    public float epicValue;
    public float rareValue;
    public float commonValue;

    public int RTP = 95; // "percentage" of money returned to player per wager

    public int packType;
    public string packTypeName;
    public TMP_Text packName;
    public int packCost;

    public float playerWallet;
    public TMP_Text walletText;
    public float playerSpent;
    public TMP_Text spentText;
    public float playerEarned;
    public TMP_Text earnedText;

    public GameObject oddsPanel;


    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = GetComponent<CardInstantiator>();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();

        originalLegendaryOdds = 1;
        originalEpicOdds = 4;
        originalRareOdds = 15;
        originalCommonOdds = 80;

        legendaryValue = 8f; // EV $0.05
        epicValue = 4f; // EV $0.24
        rareValue = 1.75f; // EV $0.30
        commonValue = 0.25f; // EV $0.36

        playerWallet = 50;
        playerSpent = 0;
        playerEarned = 0;

        oddsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();

        if (Input.GetKeyDown(KeyCode.M))
        {
            AddMoney(50);
        }
    }

    public void ConfirmWeight(int packType)
    {
        switch (packType)
        {
            case 1: // vlight
                packTypeName = "Okay Pack";
                originalLegendaryOdds = 1;
                originalEpicOdds = 4;
                originalRareOdds = 15;
                originalCommonOdds = 80;
                packCost = 5;
                break;
            case 2: // light
                packTypeName = "Good Pack";
                originalLegendaryOdds = 2;
                originalEpicOdds = 8;
                originalRareOdds = 14;
                originalCommonOdds = 76;
                packCost = 10;
                break;
            case 3: // heavy
                packTypeName = "Gooder Pack";
                originalLegendaryOdds = 3;
                originalEpicOdds = 12;
                originalRareOdds = 14;
                originalCommonOdds = 71;
                packCost = 15;
                break;
            case 4: // vheavy
                packTypeName = "Bestest Pack";
                originalLegendaryOdds = 4;
                originalEpicOdds = 16;
                originalRareOdds = 13;
                originalCommonOdds = 67;
                packCost = 20;
                break;
        }

        CardInstantiator.legendaryOdds = originalLegendaryOdds;
        CardInstantiator.epicOdds = originalEpicOdds;
        CardInstantiator.rareOdds = originalRareOdds;
        CardInstantiator.commonOdds = originalCommonOdds;

        CardPackGrab.canTear = true;
        arrow.SetActive(true);
    }

    public void AddMoney(float money)
    {
        playerWallet += money;
    }
    public void SubtractMoney(float money)
    {
        playerWallet -= money;
        playerSpent += money;
    }
    public void AddEarnings(float money)
    {
        playerEarned += money;
    }

    public void UpdateOdds(int packType)
    {
        switch (packType)
        {
            case 1: // vlight
                packTypeName = "Okay Pack";
                originalLegendaryOdds = 1;
                originalEpicOdds = 4;
                originalRareOdds = 15;
                originalCommonOdds = 80;
                packCost = 5;
                break;
            case 2: // light
                packTypeName = "Good Pack";
                originalLegendaryOdds = 2;
                originalEpicOdds = 8;
                originalRareOdds = 14;
                originalCommonOdds = 76;
                packCost = 10;
                break;
            case 3: // heavy
                packTypeName = "Gooder Pack";
                originalLegendaryOdds = 3;
                originalEpicOdds = 12;
                originalRareOdds = 14;
                originalCommonOdds = 71;
                packCost = 15;
                break;
            case 4: // vheavy
                packTypeName = "Bestest Pack";
                originalLegendaryOdds = 4;
                originalEpicOdds = 16;
                originalRareOdds = 13;
                originalCommonOdds = 67;
                packCost = 20;
                break;
        }

        CardInstantiator.legendaryOdds = originalLegendaryOdds;
        CardInstantiator.epicOdds = originalEpicOdds;
        CardInstantiator.rareOdds = originalRareOdds;
        CardInstantiator.commonOdds = originalCommonOdds;
    }

    public void UpdateText()
    {
        walletText.text = "Wallet: $" + playerWallet.ToString();
        spentText.text = "Spent: $" + playerSpent.ToString();
        earnedText.text = "Earned: $" + playerEarned.ToString();

        packName.text = packTypeName;
        legendaryText.text = originalLegendaryOdds.ToString()+"%";
        epicText.text = originalEpicOdds.ToString() + "%";
        rareText.text = originalRareOdds.ToString() + "%";
        commonText.text = originalCommonOdds.ToString() + "%";
    }

    public void ToggleOddsPanel()
    {
        if (oddsPanel.activeSelf == false)
        {
            oddsPanel.SetActive(true);
        }
        else
        {
            oddsPanel.SetActive(false);
        }
    }
}
