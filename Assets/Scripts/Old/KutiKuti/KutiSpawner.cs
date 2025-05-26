using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutiSpawner : MonoBehaviour
{
    public int kutiCount;
    public int kutiSets = 3;
    public Vector2 kutiPosition;
    public float kutixRange = 8f;
    public float kutiyRange = 4f;

    public GameObject CircleKuti;
    public GameObject SquareKuti;
    public GameObject TriangleKuti;
    public GameObject KutiShape;

    public Color32 red = Color.red;
    public Color32 green = Color.green;
    public Color32 blue = Color.blue;
    public Color32 yellow = Color.yellow;
    public Color32 kutiColour;

    // Start is called before the first frame update
    void Start()
    {
        RandomiseKutiCount();
        kutiSets = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (kutiCount > 0)
        {
            kutiCount--;
            RandomiseKutiLocation();
            RandomiseKutiShape();
            RandomiseKutiColour();
            InstantiateKuti();
            if (kutiCount == 0 && kutiSets > 0)
            {
                kutiSets--;
                RandomiseKutiCount();
            }
        }
    }

    public void RandomiseKutiCount()
    {
        kutiCount = Random.Range(1, 9);
    }

    public void RandomiseKutiLocation()
    {
        float kutixPosition = Random.Range(0 - kutixRange, 0 + kutixRange);
        float kutiyPosition = Random.Range(0 - kutiyRange, 0 + kutiyRange);
        kutiPosition = new Vector2(kutixPosition, kutiyPosition);
    }

    public void RandomiseKutiShape()
    {
        int shape = Random.Range(1, 4);

        switch (shape)
        {
            case 1:
                KutiShape = CircleKuti;
                break;
            case 2:
                KutiShape = SquareKuti;
                break;
            case 3:
                KutiShape = TriangleKuti;
                break;
        }
    }

    public void RandomiseKutiColour()
    {
        int colour = Random.Range(1, 5);

        switch (colour)
        {
            case 1:
                kutiColour = red;
                break;
            case 2:
                kutiColour = green;
                break;
            case 3:
                kutiColour = blue;
                break;
            case 4:
                kutiColour = yellow;
                break;
        }
    }

    public void InstantiateKuti()
    {
        GameObject Kuti = Instantiate(KutiShape, kutiPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        Kuti.GetComponent<SpriteRenderer>().material.color = kutiColour;
    }
}
