using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScale : MonoBehaviour
{
    public Vector3 scaleChange = new Vector3(1f, 1f, 0f); // How much to scale on each pump
    public float lerpDuration = 1f; // Time to complete the scale change

    public Vector3 initialScale;
    public Vector3 targetScale;
    private float elapsedTime = 0f;
    public bool isScaling = false;

    public BalloonExplode balloonExplode;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        balloonExplode = gameObject.GetComponent<BalloonExplode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isScaling)
        {
            elapsedTime += Time.deltaTime;
            float time = elapsedTime / lerpDuration;

            transform.localScale = Vector3.Lerp(initialScale, targetScale, time);

            if (time >= 1f)
            {
                isScaling = false;
                balloonExplode.CheckExplode();
            }
        }
    }

    public void AddAir()
    {
        initialScale = transform.localScale;
        targetScale = initialScale + scaleChange;
        elapsedTime = 0f;
        isScaling = true;
    }
}
