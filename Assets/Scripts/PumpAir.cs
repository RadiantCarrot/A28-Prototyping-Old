using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpAir : MonoBehaviour
{
    private int pumpCount = 0;
    public float pumpValueBase;
    public float pumpValueMult;
    public BalloonScale balloonScale;
    public BalloonExplode balloonExplode;
    public BalloonValue balloonValue;

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
    }

    public void OnMouseDown()
    {
        if (balloonScale != null)
        {
            pumpCount++;
            pumpCooldown = 0.5f;
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
