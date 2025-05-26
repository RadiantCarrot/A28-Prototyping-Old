using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KutiTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public float maxTime;
    public float currentTime;
    public bool clearBoard = false;
    public GameObject QuizBoard;

    // Start is called before the first frame update
    void Start()
    {
        clearBoard = false;
        maxTime = 15f;
        currentTime = maxTime;
        QuizBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = currentTime.ToString("0") + "s";

        if (currentTime <= 5)
        {
            timerText.color = Color.red;
        }

        if (currentTime < 0)
        {
            currentTime = 0;
            QuizBoard.SetActive(true);
        }
    }
}
