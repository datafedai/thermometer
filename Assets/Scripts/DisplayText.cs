using UnityEngine;
using UnityEngine.UI; // Needed for accessing UI elements like Text
using TMPro;
using UnityEngine.InputSystem; // Include if using TextMeshPro for text display


public class DisplayText : MonoBehaviour
{

    public GameObject displayTimeMetrics;
    public GameObject displayTempMetrics;
    public GameObject displayVisitMetrics;
    public GameObject displayHeatSourceMetrics;
    public TextMeshProUGUI displayText1; // time
    public TextMeshProUGUI displayText2; // temperature
    public TextMeshProUGUI displayText3; // # of heat source visits
    public TextMeshProUGUI displayText4; // current heat source
    public TextMeshProUGUI rightText; // text on the right side of canvas
    private string hSource; // heat source string

    InputAction keyPressArrow;
    InputAction keyPressSpace;
    InputAction keyPressHelp;

    private void OnEnable()
    {
        //inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }


    private void displayLeftText()
    {
        // current time of day: daytime or nighttime
        PlayerController currentTime = displayTimeMetrics.GetComponent<PlayerController>();
        displayText1.text = "Time of day: " + currentTime.dayOrNight();


        // current temperature
        Temp currentTemp = displayTempMetrics.GetComponent<Temp>();
        // Update the text to display the current score
        displayText2.text = "Temperature: " + currentTemp.currentTemperature.ToString() + " \u00B0C";


        // heat source visit countr
        PlayerMetrics heatSourceVisits = displayVisitMetrics.GetComponent<PlayerMetrics>();
        // Update the text to display the current score
        displayText3.text = "Heat Source Visits: " + heatSourceVisits.getHeatSourceVisits().ToString();


        // heat source name
        HeatSourceTrigger heatSource = displayHeatSourceMetrics.GetComponent<HeatSourceTrigger>();

        // to eliminate non-heat-source trigger, check if current temp is the same as the ambient temp
        if (currentTemp.getAmbientTemperature() == currentTemp.getCurrentTemperature())
        {
            hSource = "None"; // no heat shource under the thermometer
        }
        else
        {
            hSource = heatSource.getCurrentHeatSource();
        }

        displayText4.text = "Heat Source: " + hSource;

    }


    private void displayRightText()
    { 
        string s1 = "To move the thermometer left or right, use <-- or --> arrow keys ";
        string s2 = "To change day and night,\npress the Space Bar.";
        string s3 = "To bring above info back, press 'H' key.";
        rightText.text = s1 + "\n\n" + s2 + "\n\n" + s3;
    }

    // to make right text disappear when arrow or space bar is pressed
    private void displayBlank()
    {
        // erase text
        rightText.text = "";
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyPressArrow = InputSystem.actions.FindAction("Move"); // arrow key binding
        keyPressSpace = InputSystem.actions.FindAction("Jump"); // space bar key binding
        keyPressHelp = InputSystem.actions.FindAction("Interact"); // 'H' key binding       
        displayRightText();
    }

    // Update is called once per frame
    void Update()
    {
        // display left text group on canvas
        // always visible
        displayLeftText();

        // right side text disappes when arrrow or space bar is pressed
        if (keyPressArrow.triggered || keyPressSpace.triggered)
        {
            displayBlank();
        }

        // right text reappears when 'H' key is pressed
        if (keyPressHelp.triggered)
        {
            displayRightText();
        }



    }
}
