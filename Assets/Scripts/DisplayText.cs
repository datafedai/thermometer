using UnityEngine;
using UnityEngine.UI; // Needed for accessing UI elements like Text
using TMPro; // Include if using TextMeshPro for text display


public class DisplayText : MonoBehaviour
{

    public GameObject displayTimeMetrics;
    public GameObject displayTempMetrics;
    public GameObject displayVisitMetrics;
    public GameObject displaySourceMetrics;
    public TextMeshProUGUI displayText1; // Or public Text displayText; if not using TextMeshPro
    public TextMeshProUGUI displayText2; // Or public Text displayText; if not using TextMeshPro
    public TextMeshProUGUI displayText3; // Or public Text displayText; if not using TextMeshPro
    public TextMeshProUGUI displayText4; // Or public Text displayText; if not using TextMeshPro
    public float currentTemp = 99f; // temp variable


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerController currentTime = displayTimeMetrics.GetComponent<PlayerController>();
        displayText1.text = "Time of day: " + currentTime.dayOrNight();


        Temp currentTemp = displayTempMetrics.GetComponent<Temp>();
        // Update the text to display the current score
        displayText2.text = "Temperature: " + currentTemp.currentTemperature.ToString();

        PlayerMetrics heatSourceVisits = displayVisitMetrics.GetComponent<PlayerMetrics>();
        // Update the text to display the current score
        displayText3.text = "Heat Source Visits: " + heatSourceVisits.getHeatSourceVisits().ToString();

        HeatSourceTrigger heatSource = displaySourceMetrics.GetComponent<HeatSourceTrigger>(); 
        displayText4.text = "Heat Source: " + heatSource.getCurrentHeatSDource();


    }
}
