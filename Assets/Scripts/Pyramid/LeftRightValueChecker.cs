using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightValueChecker : MonoBehaviour
{
    public GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {
        //Parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "TopLeftArm")
        {
            if (collision.gameObject.tag == "Tile")
            {
                Parent.GetComponent<TileDetails>().topLeftValue = collision.gameObject.GetComponent<TileDetails>().tileValue;
            }
        }
        if (gameObject.name == "TopRightArm")
        {
            if (collision.gameObject.tag == "Tile")
            {
                Parent.GetComponent<TileDetails>().topRightValue = collision.gameObject.GetComponent<TileDetails>().tileValue;
            }
        }

        if (gameObject.name == "LeftArm")
        {
            if (collision.gameObject.tag == "Tile")
            {
                Parent.GetComponent<TileDetails>().leftValue = collision.gameObject.GetComponent<TileDetails>().tileValue;
            }
        }
        if (gameObject.name == "RightArm")
        {
            if (collision.gameObject.tag == "Tile")
            {
                Parent.GetComponent<TileDetails>().rightValue = collision.gameObject.GetComponent<TileDetails>().tileValue;
            }
        }

        if (gameObject.name == "BottomLeftArm")
        {
            if (collision.gameObject.tag == "Tile")
            {
                Parent.GetComponent<TileDetails>().bottomLeftValue = collision.gameObject.GetComponent<TileDetails>().tileValue;
            }
        }
        if (gameObject.name == "BottomRightArm")
        {
            if (collision.gameObject.tag == "Tile")
            {
                Parent.GetComponent<TileDetails>().bottomRightValue = collision.gameObject.GetComponent<TileDetails>().tileValue;
            }
        }
    }
}
