using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class PlayerController : MonoBehaviour
{
    // variables
    public GameObject thermometer; // themometer controller
    public float movementSpeed = 10f; // speed of the thermometer movement
    InputAction moveAction; // input action for movement from keyboard

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        // move the thermometer based on the input from the keyboard
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue.x * Time.deltaTime * movementSpeed, 0, 0);
    }
}
