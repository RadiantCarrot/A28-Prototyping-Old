using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidOrganiser : MonoBehaviour
{
    public int currentRow;

    public List<GameObject> row7Tiles = new List<GameObject>();
    public int row7TilesCap = 7;
    public GameObject row7Spawnpoint;
    public int positionCounter7 = 0;

    public List<GameObject> row6Tiles = new List<GameObject>();
    public int row6TilesCap = 6;
    public GameObject row6Spawnpoint;
    public int positionCounter6 = 0;

    public List<GameObject> row5Tiles = new List<GameObject>();
    public int row5TilesCap = 5;
    public GameObject row5Spawnpoint;
    public int positionCounter5 = 0;

    public List<GameObject> row4Tiles = new List<GameObject>();
    public int row4TilesCap = 4;
    public GameObject row4Spawnpoint;
    public int positionCounter4 = 0;

    public List<GameObject> row3Tiles = new List<GameObject>();
    public int row3TilesCap = 3;
    public GameObject row3Spawnpoint;
    public int positionCounter3 = 0;

    public List<GameObject> row2Tiles = new List<GameObject>();
    public int row2TilesCap = 2;
    public GameObject row2Spawnpoint;
    public int positionCounter2 = 0;

    public List<GameObject> row1Tiles = new List<GameObject>();
    public int row1TilesCap = 1;
    public GameObject row1Spawnpoint;
    public int positionCounter1 = 0;

    public bool endRound = false;
    public PyramidScorer PyramidScorer;

    public GameObject Score1;
    public GameObject Score2;
    public GameObject Score3;  
    public GameObject Score4;
    public GameObject Score5;
    public GameObject Score6;


    // Start is called before the first frame update
    void Start()
    {
        endRound = false;
        PyramidScorer = gameObject.GetComponent<PyramidScorer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTileToBoard(GameObject tile)
    {
        if (row7Tiles.Count < row7TilesCap)
        {
            currentRow = 7;
            row7Tiles.Add(tile);
            tile.transform.position = row7Spawnpoint.transform.position + positionCounter7 * new Vector3(2.5f, 0, 0);
            positionCounter7 += 1;
        }
        else if (row6Tiles.Count < row6TilesCap)
        {
            currentRow = 6;
            row6Tiles.Add(tile);
            tile.transform.position = row6Spawnpoint.transform.position + positionCounter6 * new Vector3(2.5f, 0, 0);
            positionCounter6 += 1;
            Score1.SetActive(true);
        }
        else if (row5Tiles.Count < row5TilesCap)
        {
            currentRow = 5;
            row5Tiles.Add(tile);
            tile.transform.position = row5Spawnpoint.transform.position + positionCounter5 * new Vector3(2.5f, 0, 0);
            positionCounter5 += 1;
            Score2.SetActive(true);
        }
        else if (row4Tiles.Count < row4TilesCap)
        {
            currentRow = 4;
            row4Tiles.Add(tile);
            tile.transform.position = row4Spawnpoint.transform.position + positionCounter4 * new Vector3(2.5f, 0, 0);
            positionCounter4 += 1;
            Score3.SetActive(true);
        }
        else if (row3Tiles.Count < row3TilesCap)
        {
            currentRow = 3;
            row3Tiles.Add(tile);
            tile.transform.position = row3Spawnpoint.transform.position + positionCounter3 * new Vector3(2.5f, 0, 0);
            positionCounter3 += 1;
            Score4.SetActive(true);
        }
        else if (row2Tiles.Count < row2TilesCap)
        {
            currentRow = 2;
            row2Tiles.Add(tile);
            tile.transform.position = row2Spawnpoint.transform.position + positionCounter2 * new Vector3(2.5f, 0, 0);
            positionCounter2 += 1;
            Score5.SetActive(true);
        }
        else if (row1Tiles.Count < row1TilesCap)
        {
            currentRow = 1;
            row1Tiles.Add(tile);
            tile.transform.position = row1Spawnpoint.transform.position + positionCounter1 * new Vector3(2.5f, 0, 0);

            endRound = true;
            PyramidScorer.CalculateScore();
            Score6.SetActive(true);
        }
    }

    public void RemoveTileFromBoard(GameObject Tile)
    {
        if (currentRow == 7)
        {
            row7Tiles.Remove(Tile);
            positionCounter7 -= 1;
        }
        else if (currentRow == 6)
        {
            row6Tiles.Remove(Tile);
            positionCounter6 -= 1;
        }
        else if (currentRow == 5)
        {
            row5Tiles.Remove(Tile);
            positionCounter5 -= 1;
        }
        else if (currentRow == 4)
        {
            row4Tiles.Remove(Tile);
            positionCounter4 -= 1;
        }
        else if (currentRow == 3)
        {
            row3Tiles.Remove(Tile);
            positionCounter3 -= 1;
        }
        else if (currentRow == 2)
        {
            row2Tiles.Remove(Tile);
            positionCounter2 -= 1;
        }
        else if (currentRow == 1)
        {
            row1Tiles.Remove(Tile);
            positionCounter1 -= 1;
        }
    }
}
