using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPackSpawnCollider : MonoBehaviour
{
    public int spawnpointNumber;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "CardPack")
        {
            if (spawnpointNumber == 1)
            {
                other.gameObject.GetComponent<CardPackSelect>().isFrontPack = true;
            }
            else
            {
                other.gameObject.GetComponent<CardPackSelect>().isFrontPack = false;
            }

            other.gameObject.GetComponent<CardPackSelect>().packPosition = spawnpointNumber;
        }
    }
}
