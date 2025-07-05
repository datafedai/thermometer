using JetBrains.Annotations;
using TMPro;
using UnityEditor.EventSystems;
using UnityEngine;

public class Temp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float temperatureC = 20f;
    public float tempMax = 40;
    public float tempMin = 0;
    public GameObject tempBar;
    public float ratio;


    private float getFillRatio(float temp)
    {
        ratio = (temp - tempMin) / (tempMax - tempMin);

        if (temp > tempMax)
            return 1;
        if (temp < tempMin)
            return 0;

        return ratio;
    
    }

    public void updateTemp(float heatInfluence)
    {
        // Update the temperature based on the heat influence
        temperatureC = temperatureC + heatInfluence;
        //Debug.Log("updated_temperatureC: " + temperatureC);
    }

    void Start()
    {


    }

    // Update is called once per frame

    void Update()
    {
        //Debug.Log("temperatureC: " + temperatureC);

        ratio = getFillRatio(temperatureC);
        ratio *= 0.2F;
        //Debug.Log("ratio: " + ratio);

        Vector3 tempBarScale = new Vector3(0.2F, ratio, 0.2F);
        //Debug.Log("tempBarScale: " + tempBarScale.y);
        //Debug.Log("tempBar.transform.localScale: " + tempBar.transform.localScale.y);
        float t = Mathf.Abs(tempBarScale.y - tempBar.transform.localScale.y);
       
        tempBar.transform.localScale = Vector3.Lerp(tempBar.transform.localScale, tempBarScale, t*0.2f);
        // previopus code below:
        //tempBar.transform.localScale = tempBarScale;
   
    }
}
