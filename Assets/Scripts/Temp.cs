using JetBrains.Annotations;
using TMPro;
using UnityEditor.EventSystems;
using UnityEngine;

public class Temp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float ambientTemperature = 0f;
    private float heatSourceInfluence = 0f;
    public float currentTemperature = 20f;
    public float tempMax = 50;
    public float tempMin = -30;
    public GameObject tempBar;
    public float ratio;


    private float getFillRatio(float temp)
    {
        // calculate the fill  ratio based on the temperature
        ratio = (temp - tempMin) / (tempMax - tempMin);

        if (temp > tempMax)
            return 1;
        if (temp < tempMin)
            return 0;

        return ratio;
    }

    public void updateTemp()
    {
        // Update the temperature based on the heat influence value
        // of a heat source and ambient temperature
        currentTemperature = ambientTemperature + heatSourceInfluence;
        //Debug.Log("baseTemperature: " + baseTemperature);
        //Debug.Log("heatInfluence: " + heatSourceInfluence);
        //Debug.Log("updated_temperatureC: " + currentTemperature);
    }

    public void updateHeatSourceInfluence(float influence)
    { 
        heatSourceInfluence = influence;
    }


    public void updateAmbientTemperature(bool dayNightIndex)
    {
        //Debug.Log("dayIndex: " + dayIndex);
        if (dayNightIndex == false) //day
        {
            ambientTemperature = 20f;
        }
        else // night
        {
            ambientTemperature = 10f;
        }

        //Debug.Log("base temp: " + baseTemperature);

    }

    public float getAmbientTemperature()
    {
        return ambientTemperature;
    }

    public float getCurrentTemperature()
    {
        return currentTemperature;
    }

    public float getHeatSourceInfluence()
    {
        return heatSourceInfluence;
    }

    void Start()
    {


    }

    // Update is called once per frame

    void Update()
    {
        ratio = getFillRatio(currentTemperature);
        ratio *= 0.2F;
        //Debug.Log("ratio: " + ratio);

        Vector3 tempBarScale = new Vector3(0.2F, ratio, 0.2F);
        //Debug.Log("tempBarScale: " + tempBarScale.y);
        //Debug.Log("tempBar.transform.localScale: " + tempBar.transform.localScale.y);
        //Debug.Log(1/(tempBar.transform.localScale.y-tempBarScale.y));

        // tempBar changes only along the y-axis
        // t is the difference between the current scale and the target scale
        // and is used to control the interpolation speed
        // if t is small, the interpolation will be slower
        // t is devide by 15f to slow down the interpolation speed
        float t = Mathf.Abs(tempBarScale.y - tempBar.transform.localScale.y);
       
        tempBar.transform.localScale = Vector3.Lerp(tempBar.transform.localScale, tempBarScale, t/15f);
        // No interpolation code below:
        //tempBar.transform.localScale = tempBarScale;
    }
}
