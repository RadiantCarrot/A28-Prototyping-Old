using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LudoTile : MonoBehaviour
{
    public int baseScore;
    public float tileScore;
    public bool isExtraRoll;
    public TMP_Text tileText;

    public LudoDifficulty LudoDifficulty;


    // Start is called before the first frame update
    void Start()
    {
        LudoDifficulty = GameObject.Find("LudoManager").GetComponent<LudoDifficulty>();
    }

    // Update is called once per frame
    void Update()
    {
        tileScore = baseScore * LudoDifficulty.diffMult;
        tileText.text = tileScore.ToString("F0");
    }
}
