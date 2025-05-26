using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackManager : MonoBehaviour
{
    public List<GameObject> PositionsOnBoard = new List<GameObject>();
    List<Vector3> PositionVectors = new List<Vector3>();

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = PositionsOnBoard.Count - 1; i < 0; i--)
        {
            PositionVectors.Add(PositionsOnBoard[i].transform.position);
            Debug.Log("Vector Added");
        }

        foreach (Vector3 v in PositionVectors)
        {
            Debug.Log(v);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
