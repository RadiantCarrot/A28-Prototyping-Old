using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LudoScorer : MonoBehaviour
{
    public TMP_Text scoreText;
    public float newScore;
    public float currentScore;

    public static float redTiles = 0;
    public static float greenTiles = 0;
    public static float blueTiles = 0;
    public static float yellowTiles = 0;
    public float colourMult = 1;


    // Start is called before the first frame update
    void Start()
    {
        redTiles = 0;
        greenTiles = 0;
        blueTiles = 0;
        yellowTiles = 0;
        colourMult = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != newScore)
        {
            currentScore += 5;
            scoreText.text = "Score: " + currentScore.ToString("F0");
            if (currentScore >= newScore)
            {
                currentScore = newScore;
            }
        }

        if (redTiles >= 3 || greenTiles >= 3 || blueTiles >= 3 || yellowTiles >= 3)
        {
            colourMult = 2;
        }
    }

    public void AddScore(float score)
    {
        newScore = newScore += score * colourMult;
    }
}
