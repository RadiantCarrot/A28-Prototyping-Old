using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileDetails : MonoBehaviour
{
    public int tileValue;
    public TMP_Text valueText;
    public int topLeftValue;
    public int topRightValue;
    public int leftValue;
    public int rightValue;
    public int bottomLeftValue;
    public int bottomRightValue;

    public PyramidOrganiser PyramidOrganiser;
    public TileSpawner TileSpawner;

    public bool canClick = true;
    public Vector3 originalPosition;

    public bool isDebuffed = false;
    public bool isBuffed = false;
    public bool canBuff = false;
    public int actualTileValue;

    public GameObject TopLeftArm;
    public GameObject TopRightArm;
    public GameObject LeftArm;
    public GameObject RightArm;
    public GameObject BottomLeftArm;
    public GameObject BottomRightArm;


    // Start is called before the first frame update
    void Start()
    {
        PyramidOrganiser = GameObject.Find("PyramidManager").GetComponent<PyramidOrganiser>();
        TileSpawner = GameObject.Find("PyramidManager").GetComponent <TileSpawner>();
        canClick = true;
        valueText.text = tileValue.ToString();

        isDebuffed = false;
        isBuffed = false;
        canBuff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bottomLeftValue + bottomRightValue != 0 && canClick == false)
        {
            if (tileValue > bottomLeftValue + bottomRightValue)
            {
                DebuffTile();
            }
        }

        if (tileValue == topLeftValue || tileValue == topRightValue || tileValue == leftValue || tileValue == rightValue || tileValue == bottomLeftValue || tileValue == bottomRightValue)
        {
            BuffTile();
        }
    }

    public void OnMouseDown()
    {
        if (canClick == true)
        {
            canClick = false;
            TileSpawner.playedTiles += 1;
            originalPosition = gameObject.transform.position;
            TileSpawner.drawnTiles.Remove(gameObject);
            PyramidOrganiser.AddTileToBoard(gameObject);
            StartCoroutine(ActivateArms());

            TileSpawner.rerollCost = 0;
            foreach (GameObject tile in TileSpawner.drawnTiles)
            {
                int tileValue = tile.GetComponent<TileDetails>().tileValue;
                TileSpawner.rerollCost = TileSpawner.rerollCost += tileValue;
                TileSpawner.rerollText.text = "Cost: " + TileSpawner.rerollCost.ToString();
            }
        }
    }

    public void DebuffTile()
    {
        isDebuffed = true;
        actualTileValue = 0;
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
    }

    public void BuffTile()
    {
        if (isDebuffed == false)
        {
            isBuffed = true;
            actualTileValue = tileValue * 2;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
    
    public IEnumerator ActivateArms()
    {
        yield return new WaitForSeconds(0.1f);
        TopLeftArm.SetActive(true);
        TopRightArm.SetActive(true);
        LeftArm.SetActive(true);
        RightArm.SetActive(true);
        BottomLeftArm.SetActive(true);
        BottomRightArm.SetActive(true);
    }
}
