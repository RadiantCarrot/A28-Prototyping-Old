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
    public GameObject cardPackTarget;
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
        StartCoroutine(ArrowHider());
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3 (0.75f,0,0);

        if (canTear == true)
        {
            if (tearing == true) // tearing pack
            {
                runTimer = true;
                // pack rip follow mouse
                gameObject.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            }
            else // stop tearing pack
            {
                if (reset == true)
                {
                    // pack rip go back to start point
                    gameObject.transform.position = Vector2.Lerp(transform.position, startPosition, moveSpeed / 2);
                }
                else // pack is fully torn
                {
                    // yoink pack rip far away
                    gameObject.transform.position = Vector2.Lerp(transform.position, flyTarget.transform.position, moveSpeed / 2);
                    if (delayPack == true)
                    {
                        // fast rip
                        StartCoroutine(CardPackDelay());
                    }
                    else
                    {
                        // slow rip
                        cardPack.transform.position = Vector2.Lerp(cardPack.transform.position, cardPackTarget.transform.position, moveSpeed / 5);
                    }
                }
            }
        }

        if (runTimer == true)
        {
            currentTime += Time.deltaTime;
        }

        if (gameObject.transform.position.z != -1)
        {
            // making collider grabbable, for some reason it's getting reset to 0
            gameObject.transform.position = gameObject.transform.position += new Vector3(0, 0, -1);
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

            if (currentTime < 0.6f)
            {
                CardExplode.explode = true;
                delayPack = true;
            }
            reset = false;
       }
    }

    public IEnumerator CardPackDelay()
    {
        yield return new WaitForSeconds(2.25f);
        cardPack.GetComponent<Rigidbody2D>().velocity = -transform.up * moveSpeed * 32;
    }

    public IEnumerator ArrowHider()
    {
        yield return new WaitForSeconds(0.1f);
        arrow.SetActive (false);
    }
}
