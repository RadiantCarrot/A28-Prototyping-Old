using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoringZone : MonoBehaviour
{
    public PuckScoreCalculator PuckScoreCalculator;
    public int score;
    public float multiplier = 0;
    public int puckCount = 0;
    public bool canMult = true;

    // Start is called before the first frame update
    void Start()
    {
        puckCount = 0;
        canMult = true;

        PuckScoreCalculator = GameObject.Find("ShuffleManager").GetComponent<PuckScoreCalculator>();

        if (gameObject.tag == "ZoneBig")
        {
            score = 1000;
            multiplier = 1.2f;
        }
        if (gameObject.tag == "ZoneSmall")
        {
            score = 500;
            multiplier = 1.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMult == true)
        {
            if (PuckScoreCalculator.puckStopped == PuckScoreCalculator.Pucks.Length)
            {
                if (puckCount >= 2)
                {
                    PuckScoreCalculator.CalculateMultiplier(puckCount * multiplier);
                    canMult = false;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Puck")
        {
            PuckScoreCalculator.AddScore(score);
            puckCount += 1;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Puck")
        {
            PuckScoreCalculator.SubtractScore(score);
            puckCount -= 1;
        }
    }
}
