using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPackWeight : MonoBehaviour
{
    public GameObject Slider;
    public GameObject Button;
    public int sliderWeight;

    public int difference;

    public CardInstantiator CardInstantiator;
    public CardPackGrab CardPackGrab;
    public GameObject arrow;

    public int originalLegendaryOdds;
    public int originalEpicOdds;
    public int originalRareOdds;
    public int originalCommonOdds;

    // Start is called before the first frame update
    void Start()
    {
        CardInstantiator = GetComponent<CardInstantiator>();
        CardPackGrab = GameObject.Find("Anchor").GetComponent<CardPackGrab>();

        originalLegendaryOdds = 5;
        originalEpicOdds = 15;
        originalRareOdds = 20;
        originalCommonOdds = 60;
    }

    // Update is called once per frame
    void Update()
    {
        float sliderFloat = Slider.GetComponent<Slider>().value;
        sliderWeight = (int)sliderFloat;

        switch (sliderWeight)
        {
            case 1:
                originalLegendaryOdds = 1;
                originalEpicOdds = 7;
                originalRareOdds = 24;
                originalCommonOdds = 68;
                break;
            case 2:
                originalLegendaryOdds = 2;
                originalEpicOdds = 9;
                originalRareOdds = 23;
                originalCommonOdds = 66;
                break;
            case 3:
                originalLegendaryOdds = 3;
                originalEpicOdds = 11;
                originalRareOdds = 22;
                originalCommonOdds = 64;
                break;
            case 4:
                originalLegendaryOdds = 4;
                originalEpicOdds = 13;
                originalRareOdds = 21;
                originalCommonOdds = 62;
                break;
            case 5:
                originalLegendaryOdds = 5;
                originalEpicOdds = 15;
                originalRareOdds = 20;
                originalCommonOdds = 60;
                break;
            case 6:
                originalLegendaryOdds = 6;
                originalEpicOdds = 17;
                originalRareOdds = 19;
                originalCommonOdds = 58;
                break;
            case 7:
                originalLegendaryOdds = 7;
                originalEpicOdds = 19;
                originalRareOdds = 18;
                originalCommonOdds = 56;
                break;
            case 8:
                originalLegendaryOdds = 8;
                originalEpicOdds = 21;
                originalRareOdds = 17;
                originalCommonOdds = 54;
                break;
            case 9:
                originalLegendaryOdds = 9;
                originalEpicOdds = 23;
                originalRareOdds = 16;
                originalCommonOdds = 52;
                break;
        }

        CardInstantiator.legendaryOdds = originalLegendaryOdds;
        CardInstantiator.epicOdds = originalEpicOdds;
        CardInstantiator.rareOdds = originalRareOdds;
        CardInstantiator.commonOdds = originalCommonOdds;
    }

    public void ConfirmWeight()
    {
        Slider.GetComponent<Slider>().interactable = false;
        CardPackGrab.canTear = true;
        arrow.SetActive(true);
        Button.GetComponent<Button>().interactable = false;
    }
}
