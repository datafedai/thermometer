using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float iSpeed = 5f;
    public GameObject thermometer; // themometer controller
    public float movementSpeed = iSpeed;
    InputAction moveAction;

    private void OnEnable()
    {
        //inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }

    public void stopThermometer(string direction)
    {
        Debug.Log("Current position X: " + transform.position.x);

        Vector2 moveValue = moveAction.ReadValue<Vector2>();


        if (direction == "right" && moveValue == new Vector2(1, 0))
        {
            Debug.Log("The thermometer stopped moving right.");
            // code to stop the thermometer from moving
            movementSpeed = 0f; // stop the thermometer from moving
        }
        else if (direction == "left" && moveValue == new Vector2(-1, 0))
        {

            Debug.Log("The thermometer stopped moving left.");
            // code to stop the thermometer from moving
            movementSpeed = 0f; // stop the thermometer from moving

        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (moveValue == new Vector2(1,0))
        {
            transform.Translate(Time.deltaTime * movementSpeed, 0, 0);

        }
        else if (moveValue == new Vector2(-1,0))
        {
            transform.Translate(-Time.deltaTime * movementSpeed, 0, 0);

        }

        // if thermometer hits a wall, it stops
        // Q: how to use BoxTrigger to detect collision with walls and stop movement
        // instead of using hard coding like 'transform.position.x < -6f'?
        //  
        // A:
        // 
        // 
        /*
        if (transform.position.x < -7f)
        {
            transform.position = new Vector3(-7f, transform.position.y, transform.position.z);
        }
        
        else if (transform.position.x > 43f)
        {
            transform.position = new Vector3(43f, transform.position.y, transform.position.z);
        }
        */
    }
}
