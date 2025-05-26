using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudoDifficulty : MonoBehaviour
{
    public float diffMult;


    // Start is called before the first frame update
    void Start()
    {
        DifficultyMedium();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DifficultyEasy()
    {
        diffMult = 0.75f;
    }
    public void DifficultyMedium()
    {
        diffMult = 1f;
    }
    public void DifficultyHard()
    {
        diffMult = 1.25f;
    }
}
