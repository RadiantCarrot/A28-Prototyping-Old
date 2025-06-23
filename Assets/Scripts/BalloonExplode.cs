using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class BalloonExplode : MonoBehaviour
{
    public int explodeChance = 0;
    public float currentExplodeThreshold = 0;
    public float newExplodeThreshold = 0;
    public float explodeMultiplier;
    public BalloonProbability balloonProbability;
    public Slider thresholdSlider;
    public GameObject ExplodeParticles;

    public BalloonCashout balloonCashout;


    // Start is called before the first frame update
    void Start()
    {
        balloonCashout = GameObject.Find("BalloonController").GetComponent<BalloonCashout>();
        thresholdSlider = GameObject.Find("Backing").GetComponent<Slider>();
        balloonProbability = GameObject.Find("BalloonController").GetComponent<BalloonProbability>();
        explodeMultiplier = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExplodeThreshold != newExplodeThreshold)
        {
            currentExplodeThreshold += 0.1f;
            if (currentExplodeThreshold >= newExplodeThreshold)
            {
                currentExplodeThreshold = newExplodeThreshold;
            }
        }

        thresholdSlider.value = currentExplodeThreshold * -1;

        if (balloonProbability.isFixed == true)
        {
            explodeMultiplier = 1.5f;
        }
        else
        {
            explodeMultiplier = 1.25f;
        }
    }

    public void RaiseThreshold(int pumpCount)
    {
        newExplodeThreshold = currentExplodeThreshold += pumpCount * explodeMultiplier;
    }
    
    public void CheckExplode()
    {
        explodeChance = Random.Range(1, 101);

        if (explodeChance < currentExplodeThreshold)
        {
            balloonCashout.ToggleBuyBalloonButton();
            Instantiate(ExplodeParticles, transform.position, Quaternion.identity);
            currentExplodeThreshold = 0;
            FindObjectOfType<CameraShake>().TriggerShake(0.2f, 0.1f);
            Destroy(gameObject);
        }
    }
}
