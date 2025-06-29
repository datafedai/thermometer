using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject thermometer; // themometer controller
    public const float movementSpeed = 1f;
    //public InputSystem_Actions inputActions;
    private void OnEnable()
    {
        //inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * 1.1f, 0, 0);
    }
}
