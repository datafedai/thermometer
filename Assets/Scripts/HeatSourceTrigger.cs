using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;





public class HeatSourceTrigger : MonoBehaviour
{
    public GameObject therm; // themometer temperature controller
    public GameObject thermMove; // thermometer movement controller

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputAction moveAction;
    public float heatInfluence = 10f;

    private void OnTriggerEnter(Collider other)
    {

        GameObject otherGameobject = other.gameObject;

        if (otherGameobject.GetComponent<Temp>() != null)
        {
            // We have the thermometer object
            // We now know that the other gameObject IS the thermometer

            Temp tempRef = otherGameobject.GetComponent<Temp>();

            tempRef.updateTemp(heatInfluence);

        }





        /*
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (other.gameObject.tag == "leftWall")
        {
            Debug.Log("The thermometer hit the left wall.");

            //stop moving thermometer
            //PlayerController pcScript = thermMove.GetComponent<PlayerController>();
            //pcScript.stopThermometer("left"); // stop the player controller from moving

        }
        */
        // left wall









        /*
        else if (other.gameObject.tag == "rightWall")
        {
            Debug.Log("The thermometer hit the right wall.");
            // stop moving thermometer
            //PlayerController pcScript = thermMove.GetComponent<PlayerController>();
            //pcScript.stopThermometer("right"); // stop the player controller from moving
        }
        */

        // right wall



        /*
        else if (other.gameObject.tag == "campfireTZ")
        {
            Debug.Log("The thermometer entered the campfire trigger zone.");
            // increase temperature by 10 degrees
            Temp tempScript = therm.GetComponent<Temp>();
            tempScript.updateTemp(heatInfluence);
            Debug.Log("Temperature increased to: " + tempScript.temperatureC + " degrees Celsius.");
        }
        */
        // camp fire



        /*
        else if (other.gameObject.tag == "icecubeTZ")
        {
            Debug.Log("The thermometer entered the icecube trigger zone.");
            // drop temperature by 10 degrees
            Temp tempScript = therm.GetComponent<Temp>();
            tempScript.updateTemp(heatInfluence);
            Debug.Log("Temperature decreased to: " + tempScript.temperatureC + " degrees Celsius.");

        }
        */

    }


    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        //Destroy(other.gameObject);
        if (other.gameObject.tag == "campfireTZ")
        {
            Debug.Log("The thermometer exited the campfire trigger zone.");
            // decrease temperature by 5 degrees
            Temp tempScript = therm.GetComponent<Temp>();
            tempScript.updateTemp(-5);
            Debug.Log("Temperature decreased back to: " + tempScript.temperatureC + " degrees Celsius.");
        }

        else if (other.gameObject.tag == "icecubeTZ")
        {
            Debug.Log("The thermometer exited the icecube trigger zone.");
            // increase temperature by 5 degrees
            Temp tempScript = therm.GetComponent<Temp>();
            tempScript.updateTemp(5);
            Debug.Log("Temperature increased back to: " + tempScript.temperatureC + " degrees Celsius.");

        }


    }



    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {

    }

}


