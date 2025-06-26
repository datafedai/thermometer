using UnityEngine;

public class Temp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float temperatureC = 25;
    public float tempMax = 50;
    public float tempMin = -20;
    public GameObject tempBar;


    private float getFillRatio(float temp)
    {
        float ratio = (temp - tempMin) / (tempMax - tempMin);

        if (temp > tempMax)
            return 1;
        if (temp < tempMin)
            return 0;

        return ratio;
    
    }
    void Start()
    {





    }

    // Update is called once per frame
    void Update()
    {
        float ratio = 30;
        ratio = getFillRatio(temperatureC);
        ratio *= 0.2F;

        Vector3 tempBarScale = new Vector3(0.2F, ratio, 0.2F);

        tempBar.transform.localScale = tempBarScale;


    }
}
