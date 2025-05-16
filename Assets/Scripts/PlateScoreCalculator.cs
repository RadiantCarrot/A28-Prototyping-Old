using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class PlateScoreCalculator : MonoBehaviour
{
    public TMP_Text scoreText;
    public float newScore= 0;
    public float currentScore;
    public bool lockScore = false;
    public bool finaliseScore = false;

    public float foodScored = 0;

    public TMP_Text timeText;
    public float currentTime;
    public int maxTime = 60;

    public GameObject[] plateCounters;

    // Start is called before the first frame update
    void Start()
    {
        newScore = 0;
        scoreText.text = currentScore.ToString("F0");
        maxTime = 60;
        currentTime = maxTime;
        lockScore = false;
        finaliseScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != newScore)
        {
            currentScore += 50;
            scoreText.text = currentScore.ToString("F0");
            if (currentScore >= newScore)
            {
                currentScore = newScore;
            }
        }

        if (plateCounters.Length != 5)
        {
            if (currentTime >= 0)
            {
                currentTime -= Time.deltaTime;
                timeText.text = currentTime.ToString("F0") + "s";

                if (currentTime < 0)
                {
                    currentTime = 0;
                    lockScore = true;
                }

                if (currentTime < 16)
                {
                    timeText.color = Color.red;
                }
            }
        }
        else
        {
            FinaliseScore();
        }

        plateCounters = GameObject.FindGameObjectsWithTag("PlateCounter");
    }

    public void AddScore(float foodScore)
    {
        if (lockScore == false)
        {
            newScore = foodScore + newScore;
        }
    }

    public void FinaliseScore()
    {
        if (finaliseScore == false)
        {
            finaliseScore = true;
            newScore += currentTime * 10;
        }

    }
}
