using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PyramidScorer : MonoBehaviour
{
    public TMP_Text scoreText;
    public float newScore;

    public PyramidOrganiser PyramidOrganiser;

    
    // Start is called before the first frame update
    void Start()
    {
        PyramidOrganiser = gameObject.GetComponent<PyramidOrganiser>();
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.RoundToInt(newScore);
        scoreText.text = "Score: " + newScore.ToString("F0");
    }

    public void CalculateScore()
    {
        foreach (GameObject tile in PyramidOrganiser.row7Tiles)
        {
            if (tile.GetComponent<TileDetails>().isDebuffed == false && tile.GetComponent<TileDetails>().isBuffed == false)
            {
                newScore = newScore += tile.GetComponent<TileDetails>().tileValue;
            }
            else
            {
                newScore = newScore += tile.GetComponent<TileDetails>().actualTileValue;
            }
        }
        foreach (GameObject tile in PyramidOrganiser.row6Tiles)
        {
            if (tile.GetComponent<TileDetails>().isDebuffed == false && tile.GetComponent<TileDetails>().isBuffed == false)
            {
                newScore = newScore += tile.GetComponent<TileDetails>().tileValue * 1.1f;
            }
            else
            {
                newScore = newScore += tile.GetComponent<TileDetails>().actualTileValue * 1.1f;
            }
        }
        foreach (GameObject tile in PyramidOrganiser.row5Tiles)
        {
            if (tile.GetComponent<TileDetails>().isDebuffed == false && tile.GetComponent<TileDetails>().isBuffed == false)
            {
                newScore = newScore += tile.GetComponent<TileDetails>().tileValue * 1.2f;
            }
            else
            {
                newScore = newScore += tile.GetComponent<TileDetails>().actualTileValue * 1.2f;
            }
        }
        foreach (GameObject tile in PyramidOrganiser.row4Tiles)
        {
            if (tile.GetComponent<TileDetails>().isDebuffed == false && tile.GetComponent<TileDetails>().isBuffed == false)
            {
                newScore = newScore += tile.GetComponent<TileDetails>().tileValue * 1.3f;
            }
            else
            {
                newScore = newScore += tile.GetComponent<TileDetails>().actualTileValue * 1.3f;
            }
        }
        foreach (GameObject tile in PyramidOrganiser.row3Tiles)
        {
            if (tile.GetComponent<TileDetails>().isDebuffed == false && tile.GetComponent<TileDetails>().isBuffed == false)
            {
                newScore = newScore += tile.GetComponent<TileDetails>().tileValue * 1.4f;
            }
            else
            {
                newScore = newScore += tile.GetComponent<TileDetails>().actualTileValue * 1.4f;
            }
        }
        foreach (GameObject tile in PyramidOrganiser.row2Tiles)
        {
            if (tile.GetComponent<TileDetails>().isDebuffed == false && tile.GetComponent<TileDetails>().isBuffed == false)
            {
                newScore = newScore += tile.GetComponent<TileDetails>().tileValue * 1.5f;
            }
            else
            {
                newScore = newScore += tile.GetComponent<TileDetails>().actualTileValue * 1.5f;
            }
        }
        foreach (GameObject tile in PyramidOrganiser.row1Tiles)
        {
            if (tile.GetComponent<TileDetails>().isDebuffed == false && tile.GetComponent<TileDetails>().isBuffed == false)
            {
                newScore = newScore += tile.GetComponent<TileDetails>().tileValue * 1.6f;
            }
            else
            {
                newScore = newScore += tile.GetComponent<TileDetails>().actualTileValue * 1.6f;
            }
        }
    }
}
