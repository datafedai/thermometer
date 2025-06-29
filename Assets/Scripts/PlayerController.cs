using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject thermometer; // themometer controller
    public float movementSpeed = 1f;
    //public InputSystem_Actions inputActions;
    InputAction moveAction;

    private void OnEnable()
    {
        //inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
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
        //transform.Translate(Time.deltaTime * 1.1f, 0, 0);
        if (moveValue == new Vector2(1,0))
        {
            transform.Translate(Time.deltaTime * movementSpeed, 0, 0);

        }
        else if (moveValue == new Vector2(-1,0))
        {
             transform.Translate(-Time.deltaTime * movementSpeed, 0, 0);
        }
    }
}
