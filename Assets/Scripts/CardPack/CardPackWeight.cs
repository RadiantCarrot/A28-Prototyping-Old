using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardPackWeight : MonoBehaviour
{

    public CardInstantiator CardInstantiator;
    public CardPackGrab CardPackGrab;
    public GameObject arrow;

    public float originalLegendaryOdds;
    public TMP_Text legendaryText;
    public float originalEpicOdds;
    public TMP_Text epicText;
    public float originalRareOdds;
    public TMP_Text rareText;
    public float originalCommonOdds;
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
    public bool reassignVariables = true;
    public GameObject Button;

    public float legendaryPity = 0;
    public TMP_Text pityText;


    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = GameObject.Find("PackManager").GetComponent<CardInstantiator>();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();
        arrow = GameObject.Find("Arrow");
        Button = GameObject.Find("PackButton");

        originalLegendaryOdds = 1;
        originalEpicOdds = 4;
        originalRareOdds = 15;
        originalCommonOdds = 80;

        legendaryValue = 6f;
        epicValue = 3f;
        rareValue = 1f;
        commonValue = 0.1f;

        playerWallet = 50;

        oddsPanel = GameObject.Find("OddsPanel");
        reassignVariables = false;

        packName = GameObject.Find("PackNameText").GetComponent<TextMeshProUGUI>();
        legendaryText = GameObject.Find("L Text").GetComponent<TextMeshProUGUI>();
        epicText = GameObject.Find("E Text").GetComponent<TextMeshProUGUI>();
        rareText = GameObject.Find("R Text").GetComponent<TextMeshProUGUI>();
        commonText = GameObject.Find("C Text").GetComponent<TextMeshProUGUI>();

        walletText = GameObject.Find("WalletText").GetComponent<TextMeshProUGUI>();
        spentText = GameObject.Find("SpentText").GetComponent<TextMeshProUGUI>();
        earnedText = GameObject.Find("EarnedText").GetComponent<TextMeshProUGUI>();
        pityText = GameObject.Find("PityText").GetComponent<TextMeshProUGUI>();

        oddsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (reassignVariables == true)
        {
            oddsPanel = GameObject.Find("OddsPanel");
            if (oddsPanel.activeSelf == true)
            {
                packName = GameObject.Find("PackNameText").GetComponent<TextMeshProUGUI>();
                legendaryText = GameObject.Find("L Text").GetComponent<TextMeshProUGUI>();
                epicText = GameObject.Find("E Text").GetComponent<TextMeshProUGUI>();
                rareText = GameObject.Find("R Text").GetComponent<TextMeshProUGUI>();
                commonText = GameObject.Find("C Text").GetComponent<TextMeshProUGUI>();

                walletText = GameObject.Find("WalletText").GetComponent<TextMeshProUGUI>();
                spentText = GameObject.Find("SpentText").GetComponent<TextMeshProUGUI>();
                earnedText = GameObject.Find("EarnedText").GetComponent<TextMeshProUGUI>();
                pityText = GameObject.Find("PityText").GetComponent<TextMeshProUGUI>();
                oddsPanel.SetActive(false);
            }
            CardInstantiator = GameObject.Find("PackManager").GetComponent<CardInstantiator>();
            CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();
            arrow = GameObject.Find("Arrow");
            Button = GameObject.Find("PackButton");
            Button.GetComponent<Button>().onClick.AddListener(ToggleOddsPanel);

            reassignVariables = false;
        }

        UpdateText();

        if (Input.GetKeyDown(KeyCode.M))
        {
            AddMoney(50);
        }

        if (Input.GetKey(KeyCode.R))
        {
            reassignVariables = true;
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

        AdjustPityValues(legendaryPity);
        CardInstantiator.legendaryOdds = originalLegendaryOdds;
        CardInstantiator.epicOdds = originalEpicOdds;
        CardInstantiator.rareOdds = originalRareOdds;
        CardInstantiator.commonOdds = originalCommonOdds;

        CardPackGrab.canTear = true;
        arrow.SetActive(true);
    }

    public void AdjustPityValues(float legendaryPity)
    {
        originalLegendaryOdds += legendaryPity;

        float split = legendaryPity / 3;
        float remainder = legendaryPity % 3;

        originalCommonOdds -= split;
        originalRareOdds -= split;
        originalEpicOdds -= split;
        int intRemainder = Mathf.FloorToInt(remainder);

        if (intRemainder > 0)
        {
            originalCommonOdds -= 1;
            intRemainder--;
        }
        if (intRemainder > 0)
        {
            originalRareOdds -= 1;
            intRemainder--;
        }
        if (intRemainder > 0)
        {
            originalEpicOdds -= 1;
        }

        pityText.text = "Pity: " + legendaryPity.ToString("F1") + "%";
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

    public void UpdateOdds(int packType) // constantly update oddsPanel rates
    {
        if (oddsPanel.activeSelf == true)
        {
            packName = GameObject.Find("PackNameText").GetComponent<TextMeshProUGUI>();
        }

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

        AdjustPityValues(legendaryPity);
        CardInstantiator.legendaryOdds = originalLegendaryOdds;
        CardInstantiator.epicOdds = originalEpicOdds;
        CardInstantiator.rareOdds = originalRareOdds;
        CardInstantiator.commonOdds = originalCommonOdds;
    }

    public void UpdateText()
    {
        if (oddsPanel.activeSelf == true)
        {
            packName = GameObject.Find("PackNameText").GetComponent<TextMeshProUGUI>();
            legendaryText = GameObject.Find("L Text").GetComponent<TextMeshProUGUI>();
            epicText = GameObject.Find("E Text").GetComponent<TextMeshProUGUI>();
            rareText = GameObject.Find("R Text").GetComponent<TextMeshProUGUI>();
            commonText = GameObject.Find("C Text").GetComponent<TextMeshProUGUI>();

            walletText = GameObject.Find("WalletText").GetComponent<TextMeshProUGUI>();
            spentText = GameObject.Find("SpentText").GetComponent<TextMeshProUGUI>();
            earnedText = GameObject.Find("EarnedText").GetComponent<TextMeshProUGUI>();
            pityText = GameObject.Find("PityText").GetComponent<TextMeshProUGUI>();
        }


        walletText.text = "Wallet: $" + playerWallet.ToString();
        spentText.text = "Spent: $" + playerSpent.ToString();
        earnedText.text = "Earned: $" + playerEarned.ToString("F2");

        pityText.text = "Pity: " + legendaryPity + "%";

        packName.text = packTypeName;
        legendaryText.text = originalLegendaryOdds.ToString("F1") +"%";
        if (legendaryPity > 0)
        {
            legendaryText.color = Color.blue;
        }
        epicText.text = originalEpicOdds.ToString("F1") + "%";
        rareText.text = originalRareOdds.ToString("F1") + "%";
        commonText.text = originalCommonOdds.ToString("F1") + "%";
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
