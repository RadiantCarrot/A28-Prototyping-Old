using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuckFlinging : MonoBehaviour
{
    public bool isSelected = false;
    public bool canFling = true;

    public Vector2 startPos;
    public Vector2 endPos;
    public Vector2 flingDir;
    public float dragDistance;

    public float puckSpeed;
    public bool flingPuck = false;
    public bool comeToRest = false;
    public PuckScoreCalculator PuckScoreCalculator;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        canFling = true;
        flingPuck = false;
        comeToRest = false;
        PuckScoreCalculator = GameObject.Find("ShuffleManager").GetComponent<PuckScoreCalculator>();
}

    // Update is called once per frame
    void Update()
    {
        if (isSelected == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;

                flingDir = endPos - startPos; // calculate direction
                flingDir.Normalize();

                dragDistance = Vector2.Distance(startPos, endPos);
                puckSpeed = dragDistance / 100;

                flingPuck = true;
            }
        }

        if (flingPuck == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(flingDir * puckSpeed, ForceMode2D.Impulse);
            isSelected = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;

            comeToRest = true;


            flingPuck = false;
        }


        if (comeToRest == true)
        {
            float velocityX = gameObject.GetComponent<Rigidbody2D>().velocity.x;
            float velocityY = gameObject.GetComponent<Rigidbody2D>().velocity.y;
            if (velocityX < 0.1f && velocityY < 0.1f)
            {
                PuckScoreCalculator.puckStopped += 1;
                comeToRest = false;
            }
        }
    }

    public void OnMouseDown()
    {
        if (canFling == true)
        {
            isSelected = true;
            canFling = false;
        }
    }
}
