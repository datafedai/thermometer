using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class PlayerController : MonoBehaviour
{
    // variables
    public GameObject thermometer; // themometer controller
    private float movementSpeed = 10f; // speed of the thermometer movement
    InputAction moveAction; // input action for movement from keyboard

    public GameObject directionalLight; // directional light for day/night cycle
    InputAction changeDayAction; // input action for changing day
    private int dayIndex = 0; // Initialize day index, even=day, odd=night
    
    //public Quaternion startRotation; // The rotation to start from
    private Quaternion targetRotation;
    private float rotationSpeed = 0.5f;
    private float sunTargetAngle = 50f;
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

    private void rotateLight(float angle)
    {
        // rotate the directional light by the given angle
        directionalLight.transform.Rotate(angle, 0f, 0f, Space.World);
    }


    // PlayerController.cs
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        changeDayAction = InputSystem.actions.FindAction("ChangeDay");

        //directionalLight.transform.Rotate(-1f, 0f, 0f);
        //directionalLight.transform.Rotate(-10f, 0f, 0f, Space.World);

        //startRotation = Quaternion.Euler(20, 0, 0); 
        //Debug.Log("start rotaion: " + startRotation); 
        targetRotation = Quaternion.Euler(180-sunTargetAngle, 0, 0); 
        //Debug.Log("target rotation: " + targetRotation);
        //Debug.Log("rotation1: " + directionalLight.transform.rotation);


        //set sun to the start position
        //directionalLight.transform.rotation = startRotation;
        //directionalLight.transform.rotation = targetRotation;
        //Debug.Log(Quaternion.identity);
        //Debug.Log("rotation2: " + directionalLight.transform.rotation);
        //directionalLight.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, 2f);
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
        if (dayIndex % 2 == 0)
        {
            directionalLight.transform.rotation =
                Quaternion.Lerp(directionalLight.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        Temp tempRef = thermometer.GetComponent<Temp>();
        tempRef.updateBaseTemperature(dayIndex);
        tempRef.updateTemp();

        // change the day based on the input from the keyboard
        if (changeDayAction.triggered)
        {
            //Debug.Log("Change day action triggered");
            // code to change the day
            // for example, you can call a method to change the day in the game
            float changeDayValue = changeDayAction.ReadValue<float>();
            //Debug.Log("Change day value: " + changeDayValue);
            dayIndex++;
            Debug.Log("Current day index: " + dayIndex);

            //directionalLight.transform.Rotate(180f, 0f, 0f, Space.World);
            if (dayIndex % 2 == 0)
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
                rotateLight(90f);

                // update room temperature down to 10 degrees Celsius
                //tempRef.updateTemp(-10f);
            }

        }
    }
}
