using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public bool stopDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        if (stopDestroy == false)
        {
            Destroy(gameObject);
        }
    }
}
