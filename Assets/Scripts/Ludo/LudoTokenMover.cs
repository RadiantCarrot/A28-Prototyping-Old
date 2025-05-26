using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LudoTokenMover : MonoBehaviour
{
    public GameObject Token;
    public List<GameObject> Tiles = new List<GameObject>();

    public int startingCurrentIndex = 0;
    private int currentTileIndex = 0;

    public LudoScorer LudoScorer;
    public LudoDiceRoll LudoDiceRoll;

    public float stepMoveDelay = 0.3f; // Delay between each step


    // Start is called before the first frame update
    void Start()
    {
        LudoScorer = gameObject.GetComponent<LudoScorer>();
        LudoDiceRoll = gameObject.GetComponent<LudoDiceRoll>();
        Token.transform.position = Tiles[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToken(int steps)
    {
        StartCoroutine(MoveTokenStepByStep(steps));
    }

    private IEnumerator MoveTokenStepByStep(int steps)
    {
        int targetTileIndex = Mathf.Min(currentTileIndex + steps, Tiles.Count - 1);

        while (currentTileIndex < targetTileIndex)
        {
            currentTileIndex++;
            Vector3 startPos = Token.transform.position;
            Vector3 endPos = Tiles[currentTileIndex].transform.position;

            float elapsed = 0f;
            float duration = stepMoveDelay;

            while (elapsed < duration)
            {
                Token.transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
                elapsed += Time.deltaTime * 2;
                yield return null;
            }

            Token.transform.position = endPos;
        }

        float score = Tiles[currentTileIndex].gameObject.GetComponent<LudoTile>().tileScore;
        LudoScorer.AddScore(score);
        if (Tiles[currentTileIndex].gameObject.GetComponent<LudoTile>().isExtraRoll == true)
        {
            LudoDiceRoll.rollsCount += 1;
        }

        if (Tiles[currentTileIndex].gameObject.name == "Red")
        {
            LudoScorer.redTiles += 1;
        }
        if (Tiles[currentTileIndex].gameObject.name == "Green")
        {
            LudoScorer.greenTiles += 1;
        }
        if (Tiles[currentTileIndex].gameObject.name == "Blue")
        {
            LudoScorer.blueTiles += 1;
        }
        if (Tiles[currentTileIndex].gameObject.name == "Yellow")
        {
            LudoScorer.yellowTiles += 1;
        }
    }
}
