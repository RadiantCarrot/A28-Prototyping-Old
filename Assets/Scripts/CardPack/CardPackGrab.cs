using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPackGrab : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 startPosition;
    public float moveSpeed = 0.5f;
    public bool reset = true;

    public GameObject flyTarget;
    public GameObject cardPack;
    public GameObject canvas;
    public GameObject arrow;

    public bool canTear = false;
    public bool tearing = false;

    public float currentTime;
    public bool runTimer = false;

    public CardExplode CardExplode;
    public bool delayPack = false;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        CardExplode = GameObject.Find("PackManager").GetComponent<CardExplode>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3 (0.75f,0,0);

        if (canTear == true)
        {
            if (tearing == true)
            {
                runTimer = true;
                gameObject.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            }
            else
            {
                if (reset == true)
                {
                    gameObject.transform.position = Vector2.Lerp(transform.position, startPosition, moveSpeed / 2);
                }
                else
                {
                    gameObject.transform.position = Vector2.Lerp(transform.position, flyTarget.transform.position, moveSpeed / 2);
                    if (delayPack == true)
                    {
                        StartCoroutine(CardPackDelay());
                    }
                    else
                    {
                        cardPack.GetComponent<Rigidbody2D>().velocity = -transform.up * moveSpeed * 16;
                    }
                }
            }
        }

        if (runTimer == true)
        {
            currentTime += Time.deltaTime;
        }
    }

    public void OnMouseDrag()
    {
        tearing = true;
    }

    void OnMouseUp()
    {
        tearing = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.name == "RipCollider")
       {
            canvas.SetActive(false);
            arrow.SetActive(false);
            runTimer = false;

            if (currentTime < 0.75f)
            {
                CardExplode.explode = true;
                delayPack = true;
            }
            reset = false;
       }
    }

    public IEnumerator CardPackDelay()
    {
        yield return new WaitForSeconds(2.5f);
        cardPack.GetComponent<Rigidbody2D>().velocity = -transform.up * moveSpeed * 32;
    }
}
