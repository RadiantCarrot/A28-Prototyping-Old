using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{
    public TMP_Text questionText1;
    public TMP_Text questionText2;
    public TMP_Text questionText3;


    private List<int> questionChoices = new List<int>();

    public GameObject Slider1;
    public int slider1Value;
    public bool lockSlider1;
    public TMP_Text slider1Text;
    public GameObject Slider2;
    public int slider2Value;
    public bool lockSlider2;
    public TMP_Text slider2Text;
    public GameObject Slider3;
    public int slider3Value;
    public bool lockSlider3;
    public TMP_Text slider3Text;

    public KutiScorer KutiScorer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 7; i++)
        {
            questionChoices.Add(i);
        }

        lockSlider1 = false;
        lockSlider2 = false;
        lockSlider3 = false;

        StartCoroutine(GenerateDelay());

        KutiScorer = gameObject.GetComponent<KutiScorer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KutiScorer.totalMarkCount >= 6)
        {
            slider1Value = (int)Slider1.GetComponent<Slider>().value;
            slider1Text.text = slider1Value.ToString();
            slider2Value = (int)Slider2.GetComponent<Slider>().value;
            slider2Text.text = slider2Value.ToString();
            slider3Value = (int)Slider3.GetComponent<Slider>().value;
            slider3Text.text = slider3Value.ToString();
        }
        else
        {
            Slider1.GetComponent<Slider>().interactable = false;
            Slider2.GetComponent<Slider>().interactable = false;
            Slider3.GetComponent<Slider>().interactable = false;
        }
    }

    public void GenerateQuestion1()
    {
        int index = Random.Range(0, questionChoices.Count);
        int number = questionChoices[index];
        questionChoices.RemoveAt(index);  // Remove so it can't be used again

        switch (number)
        {
            case 1:
                //KutiScorer.CheckCircle(1);
                KutiScorer.question1Variable = KutiScorer.circleKutis;
                questionText1.text = "How many CIRCLES are there?";
                break;
            case 2:
                //KutiScorer.CheckSquare(1);
                KutiScorer.question1Variable = KutiScorer.squareKutis;
                questionText1.text = "How many SQUARES are there?";
                break;
            case 3:
                //KutiScorer.CheckTriangle(1);
                KutiScorer.question1Variable = KutiScorer.triangleKutis;
                questionText1.text = "How many TRIANGLES are there?";
                break;
            case 4:
                //KutiScorer.CheckRed(1);
                KutiScorer.question1Variable = KutiScorer.redKutis;
                questionText1.text = "How many RED shapes are there?";
                break;
            case 5:
                //KutiScorer.CheckGreen(1);
                KutiScorer.question1Variable = KutiScorer.greenKutis;
                questionText1.text = "How many GREEN shapes are there?";
                break;
            case 6:
                //KutiScorer.CheckBlue(1);
                KutiScorer.question1Variable = KutiScorer.blueKutis;
                questionText1.text = "How many BLUE shapes are there?";
                break;
            case 7:
                //KutiScorer.CheckYellow(1);
                KutiScorer.question1Variable = KutiScorer.yellowKutis;
                questionText1.text = "How many YELLOW shapes are there?";
                break;
        }
    }
    public void GenerateQuestion2()
    {
        int index = Random.Range(0, questionChoices.Count);
        int number = questionChoices[index];
        questionChoices.RemoveAt(index);  // Remove so it can't be used again

        switch (number)
        {
            case 1:
                //KutiScorer.CheckCircle(2);
                KutiScorer.question2Variable = KutiScorer.circleKutis;
                questionText2.text = "How many CIRCLES are there?";
                break;
            case 2:
                //KutiScorer.CheckSquare(2);
                KutiScorer.question2Variable = KutiScorer.squareKutis;
                questionText2.text = "How many SQUARES are there?";
                break;
            case 3:
                //KutiScorer.CheckTriangle(2);
                KutiScorer.question2Variable = KutiScorer.triangleKutis;
                questionText2.text = "How many TRIANGLES are there?";
                break;
            case 4:
                //KutiScorer.CheckRed(2);
                KutiScorer.question2Variable = KutiScorer.redKutis;
                questionText2.text = "How many RED shapes are there?";
                break;
            case 5:
                //KutiScorer.CheckGreen(2);
                KutiScorer.question2Variable = KutiScorer.greenKutis;
                questionText2.text = "How many GREEN shapes are there?";
                break;
            case 6:
                //KutiScorer.CheckBlue(2);
                KutiScorer.question2Variable = KutiScorer.blueKutis;
                questionText2.text = "How many BLUE shapes are there?";
                break;
            case 7:
                //KutiScorer.CheckYellow(2);
                KutiScorer.question2Variable = KutiScorer.yellowKutis;
                questionText2.text = "How many YELLOW shapes are there?";
                break;
        }
    }
    public void GenerateQuestion3()
    {
        int index = Random.Range(0, questionChoices.Count);
        int number = questionChoices[index];
        questionChoices.RemoveAt(index);  // Remove so it can't be used again

        switch (number)
        {
            case 1:
                //KutiScorer.CheckCircle(3);
                KutiScorer.question3Variable = KutiScorer.circleKutis;
                questionText1.text = "How many CIRCLES are there?";
                break;
            case 2:
                //KutiScorer.CheckSquare(3);
                KutiScorer.question3Variable = KutiScorer.squareKutis;
                questionText3.text = "How many SQUARES are there?";
                break;
            case 3:
                //KutiScorer.CheckTriangle(3);
                KutiScorer.question3Variable = KutiScorer.triangleKutis;
                questionText3.text = "How many TRIANGLES are there?";
                break;
            case 4:
                //KutiScorer.CheckRed(3);
                KutiScorer.question3Variable = KutiScorer.redKutis;
                questionText3.text = "How many RED shapes are there?";
                break;
            case 5:
                //KutiScorer.CheckGreen(3);
                KutiScorer.question3Variable = KutiScorer.greenKutis;
                questionText3.text = "How many GREEN shapes are there?";
                break;
            case 6:
                //KutiScorer.CheckBlue(3);
                KutiScorer.question3Variable = KutiScorer.blueKutis;
                questionText3.text = "How many BLUE shapes are there?";
                break;
            case 7:
                //KutiScorer.CheckYellow(3);
                KutiScorer.question3Variable = KutiScorer.yellowKutis;
                questionText3.text = "How many YELLOW shapes are there?";
                break;
        }
    }

    public IEnumerator GenerateDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GenerateQuestion1();
        GenerateQuestion2();
        GenerateQuestion3();
    }
}
