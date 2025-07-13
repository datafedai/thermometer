using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class PlayerController : MonoBehaviour
{
    // variables
    public GameObject thermometer; // themometer controller
    private float movementSpeed = 10f; // speed of the thermometer movement
    InputAction moveAction; // input action for movement from keyboard

    public GameObject moon; // RMoon

    public GameObject directionalLight; // directional light for day/night cycle
    InputAction changeDayAction; // input action for changing day
    //private int dayIndex = 0; // Initialize day index, even=day, odd=night
    //private bool dayNightIndex = false; // day:0, night:1
    private int spaceCount;
    private bool isDayTime = true;
    
    //public Quaternion startRotation; // The rotation to start from
    private Quaternion targetRotation;
    private float rotationSpeed = 0.1f;
    private float sunTargetAngle = 90f;
    public float temperature;
    //public GameObject moonRotationControll;

        // ???? 
    private void OnEnable()
    {
        //inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

    /*
    public void stopThermometer(string direction)
    {
        //Debug.Log("Current position X: " + transform.position.x);

        Vector2 moveValue = moveAction.ReadValue<Vector2>();


        if (direction == "right" && moveValue == new Vector2(1, 0))
        {
            //Debug.Log("The thermometer stopped moving right.");
            // code to stop the thermometer from moving
            movementSpeed = 0f; // stop the thermometer from moving
        }
        else if (direction == "left" && moveValue == new Vector2(-1, 0))
        {

            //Debug.Log("The thermometer stopped moving left.");
            // code to stop the thermometer from moving
            movementSpeed = 0f; // stop the thermometer from moving

        }

    }
    */

    public string dayOrNight()
    {
        if (spaceCount%2 == 0)
            return "Day";
        else
            return "Night";
    }


    private void rotateLight(float angle)
    {
        // rotate the directional light by the given angle
        directionalLight.transform.Rotate(angle, 0f, 0f, Space.World);
    }

    private bool dayNightIndex(int spaceCount)
    {
        if (spaceCount % 2 == 0) // day
        {
            isDayTime = false;
            return isDayTime;
        }
        else // night
        {
            isDayTime = true;
            return isDayTime;
        }
    }


    private bool isDayTimeCheck()
    {
        if (spaceCount % 2 == 0) // day
        {
            return true;
        }
        else // night
        {
            return false;
        }
    }


    // PlayerController.cs
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spaceCount = 0; // initial, day time
        Debug.Log("space count: " + spaceCount);
        Debug.Log("dayNightIndex(): " + dayNightIndex(spaceCount));

        moveAction = InputSystem.actions.FindAction("Move");
        changeDayAction = InputSystem.actions.FindAction("Jump");

        //directionalLight.transform.Rotate(-1f, 0f, 0f);
        //directionalLight.transform.Rotate(-10f, 0f, 0f, Space.World);

        //startRotation = Quaternion.Euler(20, 0, 0); 
        //Debug.Log("start rotaion: " + startRotation); 
        targetRotation = Quaternion.Euler(180 - sunTargetAngle, 0, 0);
        //Debug.Log("target rotation: " + targetRotation);
        //Debug.Log("rotation1: " + directionalLight.transform.rotation);


        //set sun to the start position
        //directionalLight.transform.rotation = startRotation;
        //directionalLight.transform.rotation = targetRotation;
        //Debug.Log(Quaternion.identity);
        //Debug.Log("rotation2: " + directionalLight.transform.rotation);
        //directionalLight.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, 2f);



        //TextMeshProUGUI left = leftTextGroup.GetComponent<TextMeshProUGUI>();
        //left.text = "10:30am";


    }

    // Update is called once per frame
    void Update()
    {
        // move the thermometer based on the input from the keyboard
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue.x * Time.deltaTime * movementSpeed, 0, 0);
        //Debug.Log(Time.deltaTime);

        //directionalLight.transform.Rotate(Mathf.Lerp(0f,1f,0.01f), 0f, 0f, Space.World);
        //directionalLight.transform.rotation = Quaternion.Euler(-0.01f, 0, 0);

        // interpolate the rotation of sun(directionalLight) using Lerp
        // if day time


        //if (dayNightIndex(spaceCount) == false)
        if (isDayTimeCheck())
        {
            // hide moon
            RotationController moonRotation = moon.GetComponent<RotationController>();
            moonRotation.hideMoon();


            // rotate directional light
            directionalLight.transform.rotation =
                Quaternion.Slerp(directionalLight.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            RotationController moonRotation = moon.GetComponent<RotationController>();
            moonRotation.revolveMoon();
            Debug.Log("moon");  
        }



        Temp tempRef = thermometer.GetComponent<Temp>();
        tempRef.updateAmbientTemperature(dayNightIndex(spaceCount));
        tempRef.updateTemp();

        // change the day based on the input from the keyboard
        if (changeDayAction.triggered)
        {
            //Debug.Log("Change day action triggered");
            // code to change the day
            // for example, you can call a method to change the day in the game
            float changeDayValue = changeDayAction.ReadValue<float>();
            //Debug.Log("Change day value: " + changeDayValue);
            spaceCount++;
            Debug.Log("space count: " + spaceCount);
            Debug.Log("Current day(F) night(T) index: " + dayNightIndex(spaceCount));

            //directionalLight.transform.Rotate(180f, 0f, 0f, Space.World);
            if (dayNightIndex(spaceCount) == false)
            {
                Debug.Log("It's day time now.");
                // code to change the day to day time
                // for example, you can change the background color or the light intensity
                //directionalLight.transform.Rotate(90f, 180f, 180f, Space.World);
                rotateLight(90f);
                //tempRef.updateTemp(0f);

                // room temperature stays 20 dgrees Celsius
            }
            else
            {
                Debug.Log("It's night time now.");
                // code to change the day to night time
                // for example, you can change the background color or the light intensity
                //rotateLight(90f);
                rotateLight(2*90f);

                // call revolveMoon() on RotationController
                

                
                // update room temperature down to 10 degrees Celsius
                //tempRef.updateTemp(-10f);
            }

        }
    }
}
