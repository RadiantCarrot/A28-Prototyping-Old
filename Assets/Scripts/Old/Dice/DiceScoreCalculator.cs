using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class DiceScoreCalculator : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text roundText;
    public TMP_Text rollsCountText;
    public int roundsCount = 5;
    public DiceRoll DiceRoll;

    public TMP_Text score1Text;
    public TMP_Text score2Text;
    public TMP_Text score3Text;
    public TMP_Text score4Text;
    public TMP_Text score5Text;

    public int currentScore = 0;
    public int expectedScore;
    public int newScore;
    public bool startTracking = false;
    public int addCounter = 0;

    public bool scoreAdded = false;
    public int directAddition;

    public int oneCombo = 0;
    public int twoCombo = 0;
    public int threeCombo = 0;
    public int fourCombo = 0;
    public int comboMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        newScore = currentScore;
        roundsCount = 5;
        roundText.text = roundsCount.ToString() + "/5";
        DiceRoll = gameObject.GetComponent<DiceRoll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTracking == true)
        {
            if (currentScore != newScore)
            {
                currentScore+=50;
                scoreText.text = currentScore.ToString();
                if (currentScore >= newScore)
                {
                    currentScore = newScore;
                    expectedScore = 0;
                    startTracking = false;
                }
            }
        }
    }

    public void ScoreDice()
    {
        if (roundsCount > 0)
        {
            if (scoreAdded == false)
            {
                expectedScore = directAddition;
            }

            newScore = currentScore + expectedScore;
            //Debug.Log("ExpectedScore = " + expectedScore);
            //Debug.Log("NewScore =  " + newScore);
            //Debug.Log("CurrentScore =  " + currentScore);
            startTracking = true;

            if (roundsCount == 5)
            {
                score1Text.text = expectedScore.ToString();
            }
            if (roundsCount == 4)
            {
                score2Text.text = expectedScore.ToString();
            }
            if (roundsCount == 3)
            {
                score3Text.text = expectedScore.ToString();
            }
            if (roundsCount == 2)
            {
                score4Text.text = expectedScore.ToString();
            }
            if (roundsCount == 1)
            {
                score5Text.text = expectedScore.ToString();
            }

            roundsCount -= 1;
            roundText.text = roundsCount.ToString() + "/5";
            DiceRoll.rollsCount = 3;
            rollsCountText.text = "2/2";
            DiceRoll.RollDice(); //reroll after scoring
            DiceRoll.ClearLock();
            scoreAdded = false;
        }
    }

    public void AddScore(int rollResult)
    {
        if (rollResult == 1)
        {
            oneCombo++;
            if (oneCombo >= 3)
            {
                comboMultiplier = comboMultiplier * 4;
            }
        }
        if (rollResult == 2)
        {
            twoCombo++;
            if (twoCombo >= 3)
            {
                comboMultiplier = comboMultiplier * 4;
            }
        }
        if (rollResult == 3)
        {
            threeCombo++;
            if (threeCombo >= 3)
            {
                comboMultiplier = comboMultiplier * 2;
            }
        }
        if (rollResult == 4)
        {
            fourCombo++;
            if (fourCombo >= 3)
            {
                comboMultiplier = comboMultiplier * 2;
            }
        }

 

        if (addCounter == 6)
        {
            addCounter = 0;
            expectedScore = 0;
        }
        addCounter +=1;

        if (comboMultiplier > 1)
        {
            expectedScore = (rollResult * 100) * comboMultiplier + expectedScore;
        }
        else
        {
            expectedScore = (rollResult * 100) + expectedScore;
        }

        directAddition = expectedScore; // if no reroll before scoring

        scoreAdded = true;
        comboMultiplier = 1;
        oneCombo = 0;
        twoCombo = 0;
        threeCombo = 0;
        fourCombo = 0;
    }
}
