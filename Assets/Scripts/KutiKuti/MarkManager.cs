using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MarkManager : MonoBehaviour
{
    public KutiScorer KutiScorer;
    public GameObject mark;
    public bool canMark = true;

    // Start is called before the first frame update
    void Start()
    {
        canMark = true;
        KutiScorer = GameObject.Find("KutiManager").GetComponent<KutiScorer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KutiScorer.totalMarkCount == 0)
        {
            canMark = false;
        }
    }

    public void Question1Marked()
    {
        if (canMark == true)
        {
            KutiScorer.question1MarkCount++;
            KutiScorer.totalMarkCount--;
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void Question2Marked()
    {
        if (canMark == true)
        {
            KutiScorer.question2MarkCount++;
            KutiScorer.totalMarkCount--;
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void Question3Marked()
    {
        if (canMark == true)
        {
            KutiScorer.question3MarkCount++;
            KutiScorer.totalMarkCount--;
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
