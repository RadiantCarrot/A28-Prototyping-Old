using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalveBallVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = rb.velocity / 2;
    }
}
