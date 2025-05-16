using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodImpulse : MonoBehaviour
{
    public float currentTime;
    public float maxTime = 6;
    public float startDelay;
    public bool canJump = true;
    public float massOriginal;


    public float foodSpeed;
    public float foodScore;
    public GameObject plateCounter;
    public bool canScore = true;

    public bool foodScored = false;

    public PlateScoreCalculator PlateScoreCalculator;
    public FoodSpawner FoodSpawner;

    // Start is called before the first frame update
    void Start()
    {
        massOriginal = gameObject.GetComponent<Rigidbody2D>().mass;
        PlateScoreCalculator = GameObject.Find("PlateController").GetComponent<PlateScoreCalculator>();
        FoodSpawner = GameObject.Find("PlateController").GetComponent<FoodSpawner>();

        maxTime = Random.Range(3, 5);
        currentTime = maxTime;

        foodSpeed = Random.Range(100, 120);

        if (gameObject.tag == "FoodBig")
        {
            foodScore = 50;
        }
        if (gameObject.tag == "FoodMedium")
        {
            foodScore = 25;
        }
        if (gameObject.tag == "FoodSmall")
        {
            foodScore = 10;
        }

        canJump = true;
        foodScored = false;
        canScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            canJump = true;
            currentTime = maxTime;
        }

        if (canJump == true && foodScored == false)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * foodSpeed, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Table")
        {
            //touchingTable = true;
            //gameObject.GetComponent<Rigidbody2D>().mass = massOriginal;
        }

        if (other.gameObject.tag == "Plate")
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlateTrigger")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            other.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            other.transform.parent.GetComponent<Rigidbody2D>().gravityScale = 1;

            if (canScore == true)
            {
                PlateScoreCalculator.AddScore(foodScore);
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                Instantiate(plateCounter, gameObject.transform.position, gameObject.transform.rotation);
                canScore = false;
            }

            foodScored = true;
            other.GetComponent<SelfDestruct>().stopDestroy = true;
        }
    }
}
