using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnSetter : MonoBehaviour
{
    public GameObject BallRed;
    public GameObject BallGreen;
    public GameObject BallYellow;
    public GameObject BallBlue;

    public Vector2 ballRedPosition;
    public Vector2 ballGreenPosition;
    public Vector2 ballYellowPosition;
    public Vector2 ballBluePosition;

    public float ballxPosition;
    public float ballyPosition;


    // Start is called before the first frame update
    void Start()
    {
        RandomiseBallPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomiseBallPosition()
    {
        ballxPosition = Random.Range(0, 5.5f);
        ballyPosition = Random.Range(-2.5f, 2.5f);
        ballRedPosition = new Vector2(ballxPosition, ballyPosition);
        BallRed.transform.position = ballRedPosition;
        BallRed.GetComponent<Rigidbody2D>().gravityScale = 0;

        ballxPosition = Random.Range(0, 5.5f);
        ballyPosition = Random.Range(-2.5f, 2.5f);
        ballGreenPosition = new Vector2(ballxPosition, ballyPosition);
        BallGreen.transform.position = ballGreenPosition;
        BallGreen.GetComponent<Rigidbody2D>().gravityScale = 0;

        ballxPosition = Random.Range(0, 5.5f);
        ballyPosition = Random.Range(-2.5f, 2.5f);
        ballYellowPosition = new Vector2(ballxPosition, ballyPosition);
        BallYellow.transform.position = ballYellowPosition;
        BallYellow.GetComponent<Rigidbody2D>().gravityScale = 0;

        ballxPosition = Random.Range(0, 5.5f);
        ballyPosition = Random.Range(-2.5f, 2.5f);
        ballBluePosition = new Vector2(ballxPosition, ballyPosition);
        BallBlue.transform.position = ballBluePosition;
    }

    public void StartBalls()
    {
        BallRed = GameObject.Find("BallRed");
        BallRed.GetComponent<Rigidbody2D>().gravityScale = 1;
        BallGreen = GameObject.Find("BallGreen");
        BallGreen.GetComponent<Rigidbody2D>().gravityScale = 1;
        BallYellow = GameObject.Find("BallYellow");
        BallYellow.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
