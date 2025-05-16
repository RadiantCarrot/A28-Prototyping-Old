using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetting : MonoBehaviour
{
    public static int pinCount = 6;
    public bool pinSet = false;

    public GameObject PlacedPin;
    public PinManager PinManager;


    // Start is called before the first frame update
    void Start()
    {
        PinManager = GameObject.Find("PinGameManager").GetComponent<PinManager>();
        pinCount = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (PlacedPin != null)
        {
            Destroy(PlacedPin);
            pinCount++;
        }
        else
        {
            if (pinCount > 0)
            {
                PlacedPin = Instantiate(PinManager.Pin, gameObject.transform.position, PinManager.Pin.transform.rotation);

                pinCount--;
            }
        }
    }
}
