using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCheck : MonoBehaviour
{
    public List<GameObject> boardPositions = new List<GameObject>();
    public int positionCount = 0;
    public Vector3 boardPosition;

    public float moveSpeed = 10f;

    public DontDestroyOnLoad DontDestroyOnLoad;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad = GameObject.Find("GameManager").GetComponent<DontDestroyOnLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (positionCount >= boardPositions.Count) return;

        Vector3 targetPos = boardPositions[positionCount].transform.position;
        other.transform.localScale = other.transform.localScale * 0.5f;

        StartCoroutine(MoveToPosition(other.gameObject, targetPos));
        DontDestroyOnLoad.cardsClicked += 1;
        positionCount++;
    }

    private IEnumerator MoveToPosition(GameObject obj, Vector3 target)
    {
        yield return new WaitForSeconds(2);

        float elapsed = 0f;
        float duration = 0.25f / moveSpeed; // Invert speed to get duration

        Vector3 start = obj.transform.position;

        while (elapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = target;
    }
}
