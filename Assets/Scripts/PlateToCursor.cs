using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlateToCursor : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        moveVector.x = -7.5f;
        moveVector.y = mousePosition.y;

        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, moveVector, 10* Time.deltaTime);
    }
}
