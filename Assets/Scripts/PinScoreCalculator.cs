using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinScoreCalculator : MonoBehaviour
{
    public TMP_Text scoreText;
    public int newScore;
    public int currentScore;

    public int stickyPenalty;
    public int leftyPenalty;
    public int rightyPenalty;

    public GameObject[] stickyPins;

    // Start is called before the first frame update
    void Start()
    {
        newScore = 0;
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != newScore)
        {
            currentScore += 50;
            scoreText.text = currentScore.ToString();
            if (currentScore >= newScore)
            {
                currentScore = newScore;
            }
        }
    }

    public void AddScore(int score)
    {
        stickyPenalty = GameObject.FindGameObjectsWithTag("PinSticky").Length * -200;
        leftyPenalty = GameObject.FindGameObjectsWithTag("PinLefty").Length * -100;
        rightyPenalty = GameObject.FindGameObjectsWithTag("PinRighty").Length * -100;

        newScore = score + stickyPenalty + leftyPenalty + rightyPenalty;
    }
}
