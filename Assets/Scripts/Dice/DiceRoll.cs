using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceRoll : MonoBehaviour
{
    public TMP_Text rollsCountText;
    public List<GameObject> Dice;
    public GameObject Face1;
    public GameObject Face2;
    public GameObject Face3;
    public GameObject Face4;
    public GameObject Face5;
    public GameObject Face6;

    public DiceScoreCalculator DiceScoreCalculator;
    public int rollResult;

    public int rollsCount;


    // Start is called before the first frame update
    void Start()
    {
        rollsCount = 3;
        rollsCountText.text = rollsCount.ToString() + "/2";
        DiceScoreCalculator = gameObject.GetComponent<DiceScoreCalculator>();
        RollDice();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RollDice()
    {
        if (rollsCount > 0)
        {
            foreach (GameObject dice in Dice)
            {
                if (dice.GetComponent<DiceLock>().locked == false)
                {
                    ClearDice(dice);
                    CalculateNumber(dice);
                }
            }
            rollsCount -= 1;
            rollsCountText.text = rollsCount.ToString() + "/2";
        }
    }

    public void CalculateNumber(GameObject dice)
    {
        int numberRolled = Random.Range(1, 7);

        switch(numberRolled)
        {
            case 1:
                Instantiate(Face1, dice.transform.position, dice.transform.rotation, dice.transform);
                DiceScoreCalculator.AddScore(1);
                break;
            case 2:
                Instantiate(Face2, dice.transform.position, dice.transform.rotation, dice.transform);
                DiceScoreCalculator.AddScore(2);
                break;
            case 3:
                Instantiate(Face3, dice.transform.position, dice.transform.rotation, dice.transform);
                DiceScoreCalculator.AddScore(3);
                break;
            case 4:
                Instantiate(Face4, dice.transform.position, dice.transform.rotation, dice.transform);
                DiceScoreCalculator.AddScore(4);
                break;
            case 5:
                Instantiate(Face5, dice.transform.position, dice.transform.rotation, dice.transform);
                DiceScoreCalculator.AddScore(5);
                break;
            case 6:
                Instantiate(Face6, dice.transform.position, dice.transform.rotation, dice.transform);
                DiceScoreCalculator.AddScore(6);
                break;
        }
    }

    public void ClearDice(GameObject dice)
    {
        for (int i = 0; i < dice.transform.childCount; i++)
        {
            GameObject Child = dice.transform.GetChild(i).gameObject;
            if (Child.tag == "DiceFace")
            {
                Destroy(Child);
            }
        }
    }

    public void ClearLock()
    {
        foreach (GameObject dice in Dice)
        {
            if (dice.GetComponent<DiceLock>().locked == true)
            {
                dice.GetComponent<DiceLock>().locked = false;
                DiceLock.lockCount = 2;
            }
        }
    }
}
