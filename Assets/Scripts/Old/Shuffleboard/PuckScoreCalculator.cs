using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuckScoreCalculator : MonoBehaviour
{
    public TMP_Text scoreText;
    public float newScore;
    public float currentScore;
    public float expectedScore;
    public float scoreMultiplier = 1;

    public static bool canCountScore = false;
    public GameObject[] Pucks;
    public int puckStopped = 0;


    // Start is called before the first frame update
    void Start()
    {
        newScore = 0;
        currentScore = 0;
        expectedScore = 0;
        puckStopped = 0;

        scoreMultiplier = 1;

        StartCoroutine(PuckAddDelay());
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

        if (puckStopped == Pucks.Length)
        {
            newScore = expectedScore * scoreMultiplier;
        }
    }

    public void AddScore(int score)
    {
        expectedScore = expectedScore + score;
    }

    public void SubtractScore(int score)
    {
        expectedScore = expectedScore - score;
    }

    public void CalculateMultiplier (float multiplier)
    {
        scoreMultiplier = multiplier + scoreMultiplier;
    }

    public IEnumerator PuckAddDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Pucks = GameObject.FindGameObjectsWithTag("Puck");
    }
}
