using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileSpawner : MonoBehaviour
{
    public int totalSuits = 4;
    public int totalNumbers = 10;
    public GameObject Tile;
    public GameObject Spawnpoint;
    public List<GameObject> totalTiles = new List<GameObject>();

    public GameObject SelectionPoint;
    public List<GameObject> drawnTiles = new List<GameObject>();

    public static int playedTiles = 0;
    public TMP_Text rerollText;
    public int rerollCost;

    public PyramidOrganiser PyramidOrganiser;
    public PyramidScorer PyramidScorer;


    // Start is called before the first frame update
    void Start()
    {
        PyramidOrganiser = gameObject.GetComponent<PyramidOrganiser>();
        PyramidScorer = gameObject.GetComponent<PyramidScorer>();

        for (int i = 1; i <= totalSuits; i++)
        {
            for (int j = 1; j < totalNumbers; j++)
            {
                GameObject InstantiatedTile = Instantiate(Tile, Spawnpoint.transform.position, Spawnpoint.transform.rotation);
                InstantiatedTile.GetComponent<TileDetails>().tileValue = j;
                totalTiles.Add(InstantiatedTile);
            }
        }

        GenerateHand(7);
    }

    // Update is called once per frame
    void Update()
    {
        if (playedTiles == 7)
        {
            playedTiles = 0;
            GenerateHand(7 - drawnTiles.Count);
        }

        if (PyramidOrganiser.endRound == true)
        {
            foreach (GameObject tile in drawnTiles)
            {
                Destroy(tile);
            }
        }
    }

    public void GenerateHand(int numberOfCards)
    {
        for (int i = 1; i <= numberOfCards; i++)
        {
            int index = Random.Range(0, totalTiles.Count);
            GameObject tile = totalTiles[index];
            totalTiles.RemoveAt(index);  // Remove so it can't be used again

            drawnTiles.Add(tile);
        }

        for (int j = 0; j <= drawnTiles.Count -1; j++)
        { 
            drawnTiles[j].gameObject.transform.position = SelectionPoint.transform.position + j * new Vector3 (2.5f,0,0);
        }

        rerollCost = 0;
        foreach (GameObject tile in drawnTiles)
        {
            int tileValue = tile.GetComponent<TileDetails>().tileValue;
            rerollCost = rerollCost += tileValue;
            rerollText.text = "Cost: " + rerollCost.ToString();
        }
    }

    public void RerollHand()
    {
        for (int i = drawnTiles.Count - 1; i >= 0; i--)
        {
            drawnTiles[i].gameObject.transform.position = Spawnpoint.transform.position;
            totalTiles.Add(drawnTiles[i]);
            drawnTiles.RemoveAt(i);
        }
        PyramidScorer.newScore = PyramidScorer.newScore -= rerollCost;
        playedTiles = 7;
    }
}
