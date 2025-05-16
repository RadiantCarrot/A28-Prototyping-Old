using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BucketScorer : MonoBehaviour
{
    public PinScoreCalculator PinScoreCalculator;
    public int score;
    public bool doubleScore = false;

    public GameObject Bet;

    public BallBucketSetter BallBucketSetter;


    // Start is called before the first frame update
    void Start()
    {
        doubleScore = false;
        PinScoreCalculator = GameObject.Find("PinGameManager").GetComponent<PinScoreCalculator>();
        BallBucketSetter = GameObject.Find("PinGameManager").GetComponent<BallBucketSetter>();
        Bet = GameObject.Find("Bet");


        if (gameObject.tag == "BucketBig")
        {
            score = 1500;
        }
        else if (gameObject.tag == "BucketMedium")
        {
            score = 1000;
        }
        else if (gameObject.tag == "BucketSmall")
        {
            score = 500;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (BallBucketSetter.ballDropped == false)
        {
            if (Bet != null)
            {
                Bet.transform.position = gameObject.transform.position;
                Bet.transform.parent = gameObject.transform;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject Child = gameObject.transform.GetChild(i).gameObject;
            if (Child.name == "Bet")
            {
                doubleScore = true;
            }
        }

        if (other.name == "Ball")
        {
            if (doubleScore == true)
            {
                PinScoreCalculator.AddScore(score * 2);
                doubleScore = false;
            }
            else
            {
                PinScoreCalculator.AddScore(score);
            }

            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = rb.velocity * 0;
        }
    }
}
