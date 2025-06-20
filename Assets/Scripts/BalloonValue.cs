using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BalloonValue : MonoBehaviour
{
    public TMP_Text valueText;
    public TMP_Text potentialValueText;
    public float currentValue = 0;
    public float newValue;

    public GameObject CashOutButton;


    // Start is called before the first frame update
    void Start()
    {
        currentValue = 0;
        newValue = currentValue;

        CashOutButton = GameObject.Find("CashOutButton");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue != newValue)
        {
            //currentValue = Mathf.Lerp(currentValue, newValue, 2f);
            currentValue += 0.1f;
            if (currentValue >= newValue)
            {
                currentValue = newValue;
            }
            valueText.text = "$" + currentValue.ToString("F2");
        }

        if (currentValue == 0)
        {
            CashOutButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            CashOutButton.GetComponent<Button>().interactable = true;
        }
    }

    public void AddBalloonValue(float value)
    {
        newValue += value;
    }
    public void DisplayPotentialValue(float value)
    {
        potentialValueText.text = "(+$" + value.ToString("F2") + ")";
    }
}
