using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KutiScorer : MonoBehaviour
{
    public int circleKutis;
    public int squareKutis;
    public int triangleKutis;
    public int redKutis;
    public int greenKutis;
    public int blueKutis;
    public int yellowKutis;

    public int question1Value; // player answer
    public int question2Value;
    public int question3Value;

    public int question1Variable; // ai answer
    public GameObject question1VariablePanel;
    public TMP_Text question1VariableText;
    public int question2Variable;
    public GameObject question2VariablePanel;
    public TMP_Text question2VariableText;
    public int question3Variable;
    public GameObject question3VariablePanel;
    public TMP_Text question3VariableText;


    public QuestionGenerator QuestionGenerator;

    public static int totalMarkCount = 6;
    public static int question1MarkCount = 0;
    public static int question2MarkCount = 0;
    public static int question3MarkCount = 0;
    public TMP_Text markText;

    public TMP_Text hotcoldText1;
    public GameObject ButtonHigher1;
    public GameObject ButtonLower1;
    public TMP_Text hotcoldText2;
    public GameObject ButtonHigher2;
    public GameObject ButtonLower2;
    public TMP_Text hotcoldText3;
    public GameObject ButtonHigher3;
    public GameObject ButtonLower3;

    public bool q1m1 = true;
    public bool q1m3 = true;
    public bool q2m1 = true;
    public bool q2m3 = true;
    public bool q3m1 = true;
    public bool q3m3 = true;


    public int question1Score;
    public TMP_Text question1ScoreText;
    public int question2Score;
    public TMP_Text question2ScoreText;
    public int question3Score;
    public TMP_Text question3ScoreText;
    public TMP_Text totalScoreText;

    public int question1Variance;
    public int question2Variance;
    public int question3Variance;

    public float score1Multiplier;
    public float score2Multiplier;
    public float score3Multiplier;

    public bool question1bust = false;
    public bool question2bust = false;
    public bool question3bust = false;


    public float currentScore;
    public float newScore;


    // Start is called before the first frame update
    void Start()
    {
        QuestionGenerator = gameObject.GetComponent<QuestionGenerator>();
        totalMarkCount = 6;
        question1MarkCount = 0;
        question2MarkCount = 0;
        question3MarkCount = 0;

        newScore = 0;

        ButtonHigher1.SetActive(false);
        ButtonLower1.SetActive(false);
        ButtonHigher2.SetActive(false);
        ButtonLower2.SetActive(false);
        ButtonHigher3.SetActive(false);
        ButtonLower3.SetActive(false);

        score1Multiplier = 1;
        score2Multiplier = 1;
        score3Multiplier = 1;

        question1bust = false;
        question2bust = false;
        question3bust = false;

        q1m1 = true;
        q1m3 = true;
        q2m1 = true;
        q2m3 = true;
        q3m1 = true;
        q3m3 = true;

        question1VariablePanel.SetActive(false);
        question2VariablePanel.SetActive(false);
        question3VariablePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        markText.text = "Marks: " + totalMarkCount.ToString();

        question1Value = QuestionGenerator.slider1Value; // player answer
        question2Value = QuestionGenerator.slider2Value;
        question3Value = QuestionGenerator.slider3Value;

        question1ScoreText.text = question1Score.ToString();
        question2ScoreText.text = question2Score.ToString();
        question3ScoreText.text = question3Score.ToString();


        if (question1MarkCount >= 1)
        {
            if (q1m1 == true)
            {
                q1m1 = false;
                if (question1Variance <= 2)
                {
                    hotcoldText1.text = "Your guess is ALMOST at the amount";
                    score1Multiplier = score1Multiplier += 0.2f;
                }
                else if (question1Variance <= 4)
                {
                    hotcoldText1.text = "Your guess is CLOSE to the amount";
                    score1Multiplier = score1Multiplier += 0.1f;
                }
                else
                {
                    hotcoldText1.text = "Your guess is FAR from the amount";
                    score1Multiplier = score1Multiplier += 0f;
                }
            }
        }
        if (question2MarkCount >= 1)
        {
            if (q2m1 == true)
            {
                q2m1 = false;
                if (question2Variance <= 2)
                {
                    hotcoldText2.text = "Your guess is ALMOST at the amount";
                    score2Multiplier = score2Multiplier += 0.2f;
                }

                else if (question2Variance <= 4)
                {
                    hotcoldText2.text = "Your guess is CLOSE to the amount";
                    score2Multiplier = score2Multiplier += 0.1f;
                }
                else
                {
                    hotcoldText2.text = "Your guess is FAR from the amount";
                    score2Multiplier = score2Multiplier += 0f;
                }
            }
        }
        if (question3MarkCount >= 1)
        {
            if (q3m1 == true)
            {
                q3m1 = false;
                if (question3Variance <= 2)
                {
                    hotcoldText3.text = "Your guess is ALMOST at the amount";
                    score3Multiplier = score3Multiplier += 0.2f;
                }
                else if (question3Variance <= 4)
                {
                    hotcoldText3.text = "Your guess is CLOSE to the amount";
                    score3Multiplier = score3Multiplier += 0.1f;
                }
                else
                {
                    hotcoldText3.text = "Your guess is FAR from the amount";
                    score3Multiplier = score3Multiplier += 0f;
                }
            }
        }


        if (question1MarkCount >= 2)
        {
            ButtonHigher1.SetActive(true);
            ButtonLower1.SetActive(true);
        }
        if (question2MarkCount >= 2)
        {
            ButtonHigher2.SetActive(true);
            ButtonLower2.SetActive(true);
        }
        if (question3MarkCount >= 2)
        {
            ButtonHigher3.SetActive(true);
            ButtonLower3.SetActive(true);
        }


        if (question1MarkCount == 3)
        {
            if (q1m3 == true)
            {
                q1m3 = false;
                if (question1Variance == 0)
                {
                    score1Multiplier += 2;
                }
                else
                {
                    question1bust = true;
                }
            }
        }
        if (question2MarkCount == 3)
        {
            if (q2m3 == true)
            {
                q2m3 = false;
                if (question2Variance == 0)
                {
                    score2Multiplier += 2;
                }
                else
                {
                    question2bust = true;
                }
            }
        }
        if (question3MarkCount == 3)
        {
            if (q3m3 == true)
            {
                q3m3 = false;
                if (question3Variance == 0)
                {
                    score3Multiplier += 2;
                }
                else
                {
                    question3bust = true;
                }
            }
        }



        if (currentScore != newScore)
        {
            currentScore += 1;
            totalScoreText.text = "Total: " + currentScore.ToString();
            if (currentScore >= newScore)
            {
                currentScore = newScore;
            }
        }


        question1Variance = Mathf.Abs(question1Variable - question1Value);
        question2Variance = Mathf.Abs(question2Variable - question2Value);
        question3Variance = Mathf.Abs(question3Variable - question3Value);

        if (totalMarkCount == 0)
        {
            if (question1bust == true)
            {
                question1Score = 0;
            }
            else
            {
                question1Score = 100 - question1Variance * 2;
            }

            if (question2bust == true)
            {
                question2Score = 0;
            }
            else
            {
                question2Score = 100 - question2Variance * 2;
            }

            if (question3bust == true)
            {
                question3Score = 0;
            }
            else
            {
                question3Score = 100 - question3Variance * 2;
            }

            newScore = question1Score * score1Multiplier + question2Score * score2Multiplier + question3Score * score3Multiplier;

            ButtonHigher1.SetActive(false);
            ButtonLower1.SetActive(false);
            ButtonHigher2.SetActive(false);
            ButtonLower2.SetActive(false);
            ButtonHigher3.SetActive(false);
            ButtonLower3.SetActive(false);

            question1VariablePanel.SetActive(true);
            question1VariableText.text = question1Variable.ToString();
            question2VariablePanel.SetActive(true);
            question2VariableText.text = question2Variable.ToString();
            question3VariablePanel.SetActive(true);
            question3VariableText.text = question3Variable.ToString();
        }
    }

    public void PressedButtonHigher1()
    {
        if (question1Variable - question1Value <= 0)
        {
            score1Multiplier = score1Multiplier += 1.3f;
        }
        else
        {
            question1bust = true;
        }
        ButtonHigher1.GetComponent<Button>().interactable = false;
        ButtonLower1.GetComponent<Button>().interactable = false;
    }
    public void PressedButtonLower1()
    {
        if (question1Variable - question1Value >= 0)
        {
            score1Multiplier = score1Multiplier += 1.3f;
        }
        else
        {
            question1bust = true;
        }
        ButtonHigher1.GetComponent<Button>().interactable = false;
        ButtonLower1.GetComponent<Button>().interactable = false;
    }
    public void PressedButtonHigher2()
    {
        if (question2Variable - question2Value <= 0)
        {
            score2Multiplier = score2Multiplier += 1.3f;
        }
        else
        {
            question2bust = true;
        }
        ButtonHigher2.GetComponent<Button>().interactable = false;
        ButtonLower2.GetComponent<Button>().interactable = false;
    }
    public void PressedButtonLower2()
    {
        if (question2Variable - question2Value >= 0)
        {
            score2Multiplier = score2Multiplier += 1.3f;
        }
        else
        {
            question2bust = true;
        }
        ButtonHigher2.GetComponent<Button>().interactable = false;
        ButtonLower2.GetComponent<Button>().interactable = false;
    }
    public void PressedButtonHigher3()
    {
        if (question3Variable - question3Value <= 0)
        {
            score3Multiplier = score3Multiplier += 1.3f;
        }
        else
        {
            question3bust = true;
        }
        ButtonHigher3.GetComponent<Button>().interactable = false;
        ButtonLower3.GetComponent<Button>().interactable = false;
    }
    public void PressedButtonLower3()
    {
        if (question3Variable - question3Value >= 0)
        {
            score3Multiplier = score3Multiplier += 1.3f;
        }
        else
        {
            question3bust = true;
        }
        ButtonHigher3.GetComponent<Button>().interactable = false;
        ButtonLower3.GetComponent<Button>().interactable = false;
    }
}
