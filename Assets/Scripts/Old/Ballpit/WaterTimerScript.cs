using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class WaterTimerScript : MonoBehaviour
{
    public bool startTimer = false;
    public float maxTime = 20;

    public TMP_Text timerText;
    public TMP_Text winnerText;

    public GameObject BallRed;
    public GameObject BallGreen;
    public GameObject BallBlue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            maxTime -= Time.deltaTime;
            timerText.text = maxTime.ToString("F0");

            if (maxTime < 0)
            {
                maxTime = 0;
                CheckWinner();
            }
        }
    }

    public void StartTimer()
    {
        startTimer = true;
    }

    public void CheckWinner()
    {
        if (BallRed.transform.position.y > BallGreen.transform.position.y && BallRed.transform.position.y > BallBlue.transform.position.y)
        {
            winnerText.text = "Red Wins!";
        }
        if (BallGreen.transform.position.y > BallRed.transform.position.y && BallGreen.transform.position.y > BallBlue.transform.position.y)
        {
            winnerText.text = "Green Wins!";
        }
        if (BallBlue.transform.position.y > BallGreen.transform.position.y && BallBlue.transform.position.y > BallRed.transform.position.y)
        {
            winnerText.text = "Yellow Wins!";
        }
    }
}
