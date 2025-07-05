using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;





public class HeatSourceTrigger : MonoBehaviour
{
    public GameObject therm; // themometer temperature controller
    public GameObject thermMove; // thermometer movement controller
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputAction moveAction;
    const float heatInfluence = 10f;
    Dictionary<string, float> heatInfluenceDic = new Dictionary<string, float>();

   


    private void OnTriggerEnter(Collider other)
    {


        //Debug.Log("this.tag:1 " + this.gameObject.tag);
        GameObject otherGameobject = other.gameObject;

        if (otherGameobject.GetComponent<Temp>() != null)
        {
            //Debug.Log("this.tag:2 " + this.gameObject.tag);
            // We have the thermometer object
            // We now know that the other gameObject IS the thermometer
            //Debug.Log("other: " + other.name); // thermometer
            //Debug.Log("this: " + this.name); // heat source trigger
            //Debug.Log($"Thermometer collided with {this.gameObject.name}");
            //Debug.Log("dictionary: " + this.name + " = " + heatInfluenceDic[this.name]);

            Temp tempRef = otherGameobject.GetComponent<Temp>();
            tempRef.updateTemp(heatInfluenceDic[this.name]);

        }





        //Debug.Log("this.tag:3 " + this.gameObject.tag);

        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (this.gameObject.tag == "leftWall")
        {
            //Debug.Log("this.tag:4 " + this.gameObject.tag);
            //Debug.Log("The thermometer hit the left wall.");

            //stop moving thermometer
            //PlayerController pcScript = thermMove.GetComponent<PlayerController>();
            //pcScript.stopThermometer("left"); // stop the player controller from moving

        }
        
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

        GameObject otherGameobject = other.gameObject;

        if (otherGameobject.GetComponent<Temp>() != null)
        {
            // We have the thermometer object
            // We now know that the other gameObject IS the thermometer
            //Debug.Log("other: " + other.name); // thermometer
            //Debug.Log("this: " + this.name); // heat source trigger
            //Debug.Log($"Thermometer exited from {this.gameObject.name}");
            Temp tempRef = otherGameobject.GetComponent<Temp>();

            //tempRef.updateTemp(-heatInfluence);
            tempRef.updateTemp(-heatInfluenceDic[this.name]);
        }



        // Destroy everything that leaves the trigger
        //Destroy(other.gameObject);
        /*
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
        */

    }



    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        // populate heatInfluenceDic
        heatInfluenceDic.Add("IcecubeTZ",-5f );
        heatInfluenceDic.Add("DryiceCubeTZ", -15f);
        heatInfluenceDic.Add("CampfireTZ", 10f);
        heatInfluenceDic.Add("VolcanoRockTZ", 20f);

    }

    private void Update()
    {

    }

}


