using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonProbability : MonoBehaviour
{
    double pumpValueBase = 2.0;
    double pumpValueMult = 0.4; // old 0.25
    double explodeMultiplier = 0.125; // old 0.015
    double entryCost = 10;
    int maxPumps = 100;

    double survivalProb = 1.0;
    double cumulativeEV = 0.0;

    public bool isFixed = true;


    public void Start()
    {
        CalculateRTP(explodeMultiplier, pumpValueBase, pumpValueMult, maxPumps, entryCost);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isFixed = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isFixed = false;
        }
    }

    public static double CalculateRTP(double explodeMultiplier, double pumpValueBase, double pumpValueMult, int maxPumps = 100, double entryCost = 10.0)
    {
        double survivalProb = 1.0;
        double cumulativeEV = 0.0;

        for (int pump = 1; pump <= maxPumps; pump++)
        {
            // Calculate payout if balloon is cashed at this pump
            double payout = 0.0;
            for (int j = 1; j <= pump; j++)
            {
                payout += pumpValueBase + pumpValueMult * j;
            }

            // Risk of bursting at this pump
            double burstChance = pump * explodeMultiplier;
            double burstProb = survivalProb * burstChance;

            // Expected value contribution
            cumulativeEV += burstProb * payout;

            // Update survival probability for next pump
            survivalProb -= burstProb;

            // Break early if survival probability is negligible
            if (survivalProb < 1e-6)
                break;
        }

        // Return RTP as a percentage
        Debug.Log((cumulativeEV / entryCost) * 100.0);
        return (cumulativeEV / entryCost) * 100.0;
    }
}
