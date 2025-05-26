using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LudoDiceRoll : MonoBehaviour
{
    public GameObject Dice;
    public GameObject Face1;
    public GameObject Face2;
    public GameObject Face3;
    public GameObject Face4;
    public GameObject Face5;
    public GameObject Face6;

    public LudoTokenMover LudoTokenMover;

    public int rollsCount = 3;
    public TMP_Text rollsText;

    public LudoDifficulty LudoDifficulty;


    // Start is called before the first frame update
    void Start()
    {
        LudoTokenMover = gameObject.GetComponent<LudoTokenMover>();
        LudoDifficulty = GameObject.Find("LudoManager").GetComponent<LudoDifficulty>();
        rollsCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        rollsText.text = "Rolls Left: " + rollsCount.ToString();
    }

    public void RollDice()
    {
        if (rollsCount > 0)
        {
            rollsCount--;
            ClearDice(Dice);

            if (LudoDifficulty.diffMult == 0.75f)
            {
                RollEasy();
            }
            if (LudoDifficulty.diffMult == 1f)
            {
                RollMedium();
            }
            if (LudoDifficulty.diffMult == 1.25f)
            {
                RollHard();
            }
        }
    }

    public void RollEasy()
    {
        int numberRolled = Random.Range(1, 9);

        switch (numberRolled)
        {
            case 1:
                Instantiate(Face1, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(1);
                break;
            case 2:
                Instantiate(Face2, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(2);
                break;
            case 3:
                Instantiate(Face3, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(3);
                break;
            case 4:
                Instantiate(Face4, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(4);
                break;
            case 5:
                Instantiate(Face5, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(5);
                break;
            case 6:
                Instantiate(Face6, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(6);
                break;
            case 7:
                Instantiate(Face5, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(5);
                break;
            case 8:
                Instantiate(Face6, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(6);
                break;
        }
    }
    public void RollMedium()
    {
        int numberRolled = Random.Range(1, 7);

        switch (numberRolled)
        {
            case 1:
                Instantiate(Face1, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(1);
                break;
            case 2:
                Instantiate(Face2, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(2);
                break;
            case 3:
                Instantiate(Face3, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(3);
                break;
            case 4:
                Instantiate(Face4, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(4);
                break;
            case 5:
                Instantiate(Face5, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(5);
                break;
            case 6:
                Instantiate(Face6, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(6);
                break;
        }
    }
    public void RollHard()
    {
        int numberRolled = Random.Range(1, 9);

        switch (numberRolled)
        {
            case 1:
                Instantiate(Face1, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(1);
                break;
            case 2:
                Instantiate(Face2, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(2);
                break;
            case 3:
                Instantiate(Face3, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(3);
                break;
            case 4:
                Instantiate(Face4, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(4);
                break;
            case 5:
                Instantiate(Face5, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(5);
                break;
            case 6:
                Instantiate(Face6, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(6);
                break;
            case 7:
                Instantiate(Face1, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(1);
                break;
            case 8:
                Instantiate(Face2, Dice.transform.position, Dice.transform.rotation, Dice.transform);
                LudoTokenMover.MoveToken(2);
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
}
