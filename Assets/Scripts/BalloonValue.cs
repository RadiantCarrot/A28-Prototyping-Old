using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalloonValue : MonoBehaviour
{
    public TMP_Text valueText;
    public float currentValue = 0;
    public float newValue;


    // Start is called before the first frame update
    void Start()
    {
        currentValue = 0;
        newValue = currentValue;
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
    }

    public void AddBalloonValue(float value)
    {
        newValue += value;
    }

}
