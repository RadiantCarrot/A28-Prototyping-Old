using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBucketSetter : MonoBehaviour
{
    public GameObject Ball;
    public float ballLeftxPos;
    public float ballRightxPos;
    public GameObject PinsPotential;

    public List<Vector2> bucketSpawns;
    public GameObject BigBucket;
    public GameObject MediumBucket;
    public GameObject SmallBucket;
    public int bigBucketSpawn;
    public int mediumBucketSpawn1;
    public int mediumBucketSpawn2;

    public bool ballDropped = false;


    // Start is called before the first frame update
    void Start()
    {
        ballDropped = false;
        RandomiseBallLocation();
        RandomiseBucketLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomiseBallLocation()
    {
        float ballxPos = Random.Range(0 + ballLeftxPos, 0 + ballRightxPos);
        Ball.transform.position = new Vector3(ballxPos, 4.4f, 0);
    }
    public void StartBall()
    {
        ballDropped=true;

        TogglePinsPotential();
        if (Ball.gameObject.GetComponent<Rigidbody2D>().gravityScale == 1)
        {
            Ball.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            Ball.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    public void TogglePinsPotential()
    {
        if (PinsPotential.activeSelf == false)
        {
            PinsPotential.SetActive(true);
        }
        else
        {
            PinsPotential.SetActive(false);
        }
    }


    public void RandomiseBucketLocation()
    {
        bigBucketSpawn = Random.Range(1, bucketSpawns.Count);
        CalculateMedBucket1(bigBucketSpawn);
        CalculateMedBucket2(bigBucketSpawn);


        for (int i = 0; i < bucketSpawns.Count; i++)
        {
            if (i == bigBucketSpawn)
            {
                Instantiate(BigBucket, bucketSpawns[i], transform.rotation);
            }
            if (i == mediumBucketSpawn1 || i == mediumBucketSpawn2)
            {
                Instantiate(MediumBucket, bucketSpawns[i], transform.rotation);
            }
            else if (i != bigBucketSpawn)
            {
                Instantiate(SmallBucket, bucketSpawns[i], transform.rotation);
            }
        }
    }

    public void CalculateMedBucket1(int bigBucketSpawn)
    {
        mediumBucketSpawn1 = Random.Range(1, bucketSpawns.Count);
        if (mediumBucketSpawn1 == bigBucketSpawn)
        {
            CalculateMedBucket1(bigBucketSpawn);
        }
    }
    public void CalculateMedBucket2(int bigBucketSpawn)
    {
        mediumBucketSpawn2 = Random.Range(1, bucketSpawns.Count);
        if (mediumBucketSpawn2 == bigBucketSpawn || mediumBucketSpawn2 == mediumBucketSpawn1)
        {
            CalculateMedBucket2(bigBucketSpawn);
        }
    }
}
