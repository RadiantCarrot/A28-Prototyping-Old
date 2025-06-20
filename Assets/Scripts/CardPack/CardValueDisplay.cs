using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardValueDisplay : MonoBehaviour
{
    public CardPackWeight CardPackWeight;
    public TMP_Text valueText;
    public float displayValue;

    // Start is called before the first frame update
    void Start()
    {
        CardPackWeight = GameObject.Find("GameManager").GetComponent<CardPackWeight>();
        //valueText = GetComponent<TextMeshProUGUI>();

        SetCardValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardValue()
    {
        if (gameObject.tag == "CardLegendary")
        {
            displayValue = CardPackWeight.legendaryValue;
        }
        if (gameObject.tag == "CardEpic")
        {
            displayValue = CardPackWeight.epicValue;
        }
        if (gameObject.tag == "CardRare")
        {
            displayValue = CardPackWeight.rareValue;
        }
        if (gameObject.tag == "CardCommon")
        {
            displayValue = CardPackWeight.commonValue;
        }

        if (displayValue >= 1)
        {
            valueText.text = "$" + displayValue.ToString("F0");
        }
        else
        {
            int cents = Mathf.RoundToInt(displayValue * 100);
            valueText.text = cents.ToString("F0") + "c";
        }
    }
}
