using UnityEngine;

public class thermoPosition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float pos = 15;
    public float posMax = 30;
    public float posMin = 5;
    public GameObject newPos;






    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * 1.1f, 0, 0);

        // newPos.transform.localScale = currentPos;
    }
}
