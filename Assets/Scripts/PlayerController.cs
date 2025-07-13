using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.WSA;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{
    // variables
    public GameObject thermometer; // themometer controller
    private float movementSpeed = 10f; // speed of the thermometer movement
    InputAction moveAction; // input action for movement from keyboard
    InputAction changeDayAction; // input action for changing day
    private int spaceCount;
   
    public float temperature;
    //public GameObject moonRotationControll;

    public DayNightCycle dayNightCycle;

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


    // PlayerController.cs
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // arrow keys
        moveAction = InputSystem.actions.FindAction("Move");

        // space bar
        changeDayAction = InputSystem.actions.FindAction("Jump");

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

        if (changeDayAction.triggered)
        {
  
        }


/*
        Temp tempRef = thermometer.GetComponent<Temp>();
        tempRef.updateAmbientTemperature(dayNightIndex(spaceCount));
        //tempRef.updateTemp();
*/
        }
    }

