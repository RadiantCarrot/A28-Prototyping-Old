using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Unity.Collections.LowLevel.Unsafe;

public class BalloonProbability : MonoBehaviour
{
    public double pumpValueBase;
    public double pumpValueMult;
    public double explodeMultiplier;
    public double entryCost;
    int maxPumps = 100;

    double survivalProb = 1.0;
    double cumulativeEV = 0.0;

    public int probabilityCase;
    public Slider RTPSlider;
    public TMP_Text RTPText;
    public int startingRTP;

    public PumpAir pumpAir;
    public BalloonExplode balloonExplode;
    public BalloonCashout balloonCashout;


    public void Start()
    {
        pumpAir = GameObject.Find("Pump").GetComponent<PumpAir>();
        balloonCashout = GameObject.Find("BalloonController").GetComponent<BalloonCashout>();

        //CalculateRTP(explodeMultiplier, pumpValueBase, pumpValueMult, maxPumps, entryCost);
        NewRTP(startingRTP);
        RTPSlider.onValueChanged.AddListener(OnSliderValueChanged);

        pumpAir.pumpValueBase = (float)Math.Round(pumpValueBase,2);
        pumpAir.pumpValueMult = (float)Math.Round(pumpValueMult,2);
        balloonCashout.balloonCost = (float)entryCost;

    }

    public void Update()
    {
        RTPText.text = "RTP: "+RTPSlider.value.ToString() + "%";
    }

    void OnSliderValueChanged(float newValue)
    {
        Debug.Log("Slider changed to: " + newValue);

        NewRTP(newValue);
    }

    public void ReferenceNewBalloon()
    {
        balloonExplode = GameObject.Find("Balloon(Clone)").GetComponent<BalloonExplode>();
        balloonExplode.explodeMultiplier = (float)explodeMultiplier * 10;

        pumpAir.pumpValueBase = (float)Math.Round(pumpValueBase, 2);
        pumpAir.pumpValueMult = (float)Math.Round(pumpValueMult, 2);
    }

    public void NewRTP(double targetRTP)
    {
        double bestExplode = explodeMultiplier;
        double bestPumpMult = pumpValueMult;
        double bestError = double.MaxValue;

        for (double explode = 0.01; explode <= 0.3; explode += 0.005)
        {
            for (double pumpMult = 0.05; pumpMult <= 0.5; pumpMult += 0.01)
            {
                double rtp = CalculateRTP(explode, pumpValueBase, pumpMult, maxPumps, entryCost);
                double error = Math.Abs(rtp - targetRTP);

                if (error < bestError)
                {
                    bestError = error;
                    bestExplode = explode;
                    bestPumpMult = pumpMult;

                    if (bestError < 0.1) // Close enough
                    {
                        explodeMultiplier = (float)Math.Round(bestExplode,2);
                        pumpValueMult = (float)Math.Round(bestPumpMult,2);
                        pumpAir.pumpValueMult = (float)Math.Round(pumpValueMult, 2);
                        Debug.Log($"Adjusted: RTP={rtp:F2}%, Explode={bestExplode}, PumpMult={bestPumpMult}");
                        return;
                    }
                }
            }
        }

        // If best match found after loop
        //explodeMultiplier = bestExplode;
        //pumpValueMult = bestPumpMult;

        double finalRTP = CalculateRTP(bestExplode, pumpValueBase, bestPumpMult, maxPumps, entryCost);
        Debug.Log($"Best Match: RTP={finalRTP:F2}%, Explode={bestExplode}, PumpMult={bestPumpMult}");
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
        Debug.Log("RTP =" + (cumulativeEV / entryCost) * 100.0);
        //RTPSlider.value = (float)(cumulativeEV / entryCost * 100.0);
        return (cumulativeEV / entryCost) * 100.0;
    }
}
