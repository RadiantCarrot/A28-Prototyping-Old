using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutiPiece : MonoBehaviour
{
    public KutiConsolidator KutiConsolidator;
    public string kutiShape;
    public Color32 kutiColour;

    // Start is called before the first frame update
    void Start()
    {
        KutiConsolidator = GameObject.Find("KutiManager").GetComponent<KutiConsolidator>();

        CheckShape();
        CheckColour();

        //Invoke("KutiConsolidator.AddKuti(gameObject, kutiShape, kutiColour)", 1.0f);
        KutiConsolidator.AddKuti(gameObject, kutiShape, kutiColour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckShape()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name == ("Circle"))
        {
            kutiShape = "Circle";
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name == ("Square"))
        {
            kutiShape = "Square";
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name == ("Triangle"))
        {
            kutiShape = "Triangle";
        }
    }

    public void CheckColour()
    {
        if (gameObject.GetComponent<SpriteRenderer>().material.color == Color.red)
        {
            kutiColour = Color.red;
        }
        if (gameObject.GetComponent<SpriteRenderer>().material.color == Color.green)
        {
            kutiColour = Color.green;
        }
        if (gameObject.GetComponent<SpriteRenderer>().material.color == Color.blue)
        {
            kutiColour = Color.blue;
        }
        if (gameObject.GetComponent<SpriteRenderer>().material.color == Color.yellow)
        {
            kutiColour = Color.yellow;
        }
    }
}
