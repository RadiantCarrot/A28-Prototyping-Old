using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutiConsolidator : MonoBehaviour
{
    public List<GameObject> CircleKutis;
    public List<GameObject> SquareKutis;
    public List<GameObject> TriangleKutis;

    public List<GameObject> RedKutis;
    public List<GameObject> GreenKutis;
    public List<GameObject> BlueKutis;
    public List<GameObject> YellowKutis;

    public QuestionGenerator QuestionGenerator;
    public KutiScorer KutiScorer;

    // Start is called before the first frame update
    void Start()
    {
        QuestionGenerator = gameObject.GetComponent<QuestionGenerator>();
        KutiScorer = gameObject.GetComponent<KutiScorer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddKuti(GameObject Kuti, string shape, Color32 colour)
    {
        if (shape == "Circle")
        {
            CircleKutis.Add(Kuti);
        }
        if (shape == "Square")
        {
            SquareKutis.Add(Kuti);
        }
        if (shape == "Triangle")
        {
            TriangleKutis.Add(Kuti);
        }

        if (colour == Color.red)
        {
            RedKutis.Add(Kuti);
        }
        if (colour == Color.green)
        {
            GreenKutis.Add(Kuti);
        }
        if (colour == Color.blue)
        {
            BlueKutis.Add(Kuti);
        }
        if (colour == Color.yellow)
        {
            YellowKutis.Add(Kuti);
        }

        KutiScorer.circleKutis = CircleKutis.Count;
        KutiScorer.squareKutis = SquareKutis.Count;
        KutiScorer.triangleKutis = TriangleKutis.Count;
        KutiScorer.redKutis = RedKutis.Count;
        KutiScorer.greenKutis = GreenKutis.Count;
        KutiScorer.blueKutis = BlueKutis.Count;
        KutiScorer.yellowKutis = YellowKutis.Count;
    }
}
