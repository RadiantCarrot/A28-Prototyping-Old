using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceLock : MonoBehaviour
{
    public bool locked = false;
    public static int lockCount = 2;
    public GameObject LockIcon;

    public TMP_Text locksText;

    // Start is called before the first frame update
    void Start()
    {
        lockCount = 2;
        locksText.text = lockCount.ToString() + "/2";
    }

    // Update is called once per frame
    void Update()
    {
        if (locked == true)
        {
            LockIcon.SetActive(true);
        }
        else
        {
            LockIcon.SetActive(false);
        }
        locksText.text = lockCount.ToString() + "/2";
    }

    public void OnMouseDown()
    {
        if (locked == false)
        {
            if (lockCount != 0)
            {
                locked = true;
                lockCount--;
            }
        }
        else
        {
            locked = false;
            lockCount++;
        }
    }
}
