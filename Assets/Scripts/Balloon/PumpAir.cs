using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PumpAir : MonoBehaviour
{
    private int pumpCount = 0;
    public float pumpValueBase;
    public float pumpValueMult;
    public BalloonProbability balloonProbability;
    public BalloonScale balloonScale;
    public BalloonExplode balloonExplode;

    public BalloonValue balloonValue;
    public TMP_Text potentialValueText;

    public float pumpCooldown;

    public Animator pumpAnimator;


    // Start is called before the first frame update
    void Start()
    {
        pumpAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pumpCooldown -= Time.deltaTime;
        if (balloonValue != null)
        {
            float potentialValue = pumpValueBase + 0.25f + pumpCount * pumpValueMult;
            potentialValueText.text = "Next Pump: +$" + potentialValue.ToString("F2");
        }
        else
        {
            potentialValueText.text = "Buy New Balloon!";
        }
    }

    public void OnMouseDown()
    {
        if (balloonScale != null && pumpCooldown <= 0)
        {
            pumpCount++;
            pumpCooldown = 0.75f;
            balloonValue.AddBalloonValue(pumpValueBase + pumpCount * pumpValueMult);
            pumpAnimator.Play("PumpDown");
            balloonScale.AddAir();
            balloonExplode.RaiseThreshold(pumpCount);
        }
    }

    public void ReferenceNewBalloon()
    {
        balloonScale = GameObject.Find("Balloon(Clone)").GetComponent<BalloonScale>();
        balloonExplode = GameObject.Find("Balloon(Clone)").GetComponent<BalloonExplode>();
        balloonValue = GameObject.Find("Balloon(Clone)").GetComponent<BalloonValue>();
        pumpCount = 0;
    }
}
