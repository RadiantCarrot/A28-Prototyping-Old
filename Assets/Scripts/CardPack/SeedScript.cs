using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class SeedScript : MonoBehaviour
{
    public int seed;
    public bool useSeed;
    public TMP_Text seedText;

    // Start is called before the first frame update
    void Start()
    {
        if (useSeed == true)
        {
            Random.InitState(seed);
        }
        else
        {
            int randomSeed = Random.Range(0, 1000000);
            Random.InitState(randomSeed);

            seedText.text = "Seed: " + randomSeed.ToString();
            Debug.Log(randomSeed);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
