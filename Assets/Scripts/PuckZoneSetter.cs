using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckZoneSetter : MonoBehaviour
{
    public Vector2 puckPosition;
    public float puckxRange = 8f;
    public float puckyRange = 4f;
    public GameObject Puck;

    public Vector2 zone1Position;
    public Vector2 zone2Position;
    public float zonexRange = 5f;
    public float zoneyRange = 2f;
    public GameObject Zone1;
    public GameObject Zone2;

    public int puckCount = 4;
    public Vector2 previousPuckPos;

    // Start is called before the first frame update
    void Start()
    {
        RandomiseZoneLocation();
        puckCount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (puckCount > 0)
        {
            puckCount--;
            RandomisePuckLocation();
        }
    }

    public void RandomisePuckLocation()
    {
        float puckxPosition = Random.Range(0 - puckxRange, 0 + puckxRange);
        float puckyPosition = Random.Range(0 - puckyRange, 0 + puckyRange);
        puckPosition = new Vector2 (puckxPosition, puckyPosition);
        previousPuckPos = puckPosition;

        if (Vector2.Distance(puckPosition, previousPuckPos) != 0 && Vector2.Distance(puckPosition, previousPuckPos) < 2)
        {
            RandomisePuckLocation();
        }
        else if (Vector2.Distance(puckPosition, zone1Position) < 4 || Vector2.Distance(puckPosition, zone2Position) < 4)
        {
            RandomisePuckLocation();
        }
        else
        {
            Instantiate(Puck, puckPosition, Quaternion.identity);
        }
    }

    public void RandomiseZoneLocation()
    {
        float zone1xPosition = Random.Range(0 - zonexRange, 0 + zonexRange);
        float zone1yPosition = Random.Range(0 - zoneyRange, 0 + zoneyRange);
        zone1Position = new Vector2 (zone1xPosition, zone1yPosition);
        Instantiate(Zone1, zone1Position, Quaternion.identity);

        float zone2xPosition = Random.Range(0 - zonexRange, 0 + zonexRange);
        float zone2yPosition = Random.Range(0 - zoneyRange, 0 + zoneyRange);
        zone2Position = new Vector2(zone2xPosition, zone2yPosition);

        while (Vector2.Distance(zone1Position, zone2Position) < 4)
        {
            float zone2newxPosition = Random.Range(0 - zonexRange, 0 + zonexRange);
            float zone2newyPosition = Random.Range(0 - zoneyRange, 0 + zoneyRange);
            zone2Position = new Vector2(zone2newxPosition, zone2newyPosition);
        }
        if (Vector2.Distance(zone1Position, zone2Position) > 4)
        {
            Instantiate(Zone2, zone2Position, Quaternion.identity);
        }
    }
}
