using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinManager : MonoBehaviour
{
    public GameObject DefaultPin;
    public GameObject StickyPin;
    public GameObject LeftyPin;
    public GameObject RightyPin;
    public GameObject Pin;
    public TMP_Text pinCountText;

    // Start is called before the first frame update
    void Start()
    {
        Pin = DefaultPin;
    }

    // Update is called once per frame
    void Update()
    {
        pinCountText.text = PinSetting.pinCount.ToString() + "/6";
    }

    public void SetDefaultPin()
    {
        Pin = DefaultPin;

    }
    public void SetStickyPin()
    {
        Pin = StickyPin;
    }
    public void SetLeftyPin()
    {
        Pin = LeftyPin;
    }
    public void SetRightyPin()
    {
        Pin = RightyPin;
    }
}
