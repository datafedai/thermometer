using System.Collections.Generic;
//using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

using UnityEngine.InputSystem;


public class HeatSourceTrigger : MonoBehaviour
{
    //public GameObject therm; // themometer temperature controller
    //public GameObject thermMove; // thermometer movement controller
    InputAction moveAction;

    // Dictionary to hold heat influence values 
    // for different heat sources populated in Start()
    public float heatInfluence = -1f;
    private string currentHeatSource;
    // Start is called once before the first execution of Update 
    // after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other) // other is the object that entered the trigger collider
    {
        // debug purpose:
        //Debug.Log("other: " + other.name);
        //Debug.Log("this: " + this.name);
        //HeatSourceTrigger brick = noHeatSource.GetComponent<HeatSourceTrigger>();
        //Debug.Log("Heat Influence On Trigger:this " + heatInfluence);
        updateHeatSource(other.name);
/*
        if (this.heatInfluence != 0f)
        {
            Debug.Log("Heat Influence:inside " + this.heatInfluence);
            Debug.Log("I am above " + this.name);
            currentHeatSource = other.name;
        }
        else
        {
            Debug.Log("not a heat source.");
            currentHeatSource = "None";
        }
*/

        // other is the collider that entered the trigger
        // that is, thermometer
        GameObject otherGameobject = other.gameObject;

        // check if thermometer gameobject has Temp component
        if (otherGameobject.GetComponent<Temp>() != null)
        {
            //updateHeatSource(this.name);

            // debug purpose below:
            
            //currentHeatSource = this.name;
            // We have the thermometer object
            // We now know that the other gameObject IS the thermometer
            //Debug.Log("other:2 " + other.name); // thermometer
            //Debug.Log("this: " + this.name); // heat source trigger
            //Debug.Log("current heat source: " + currentHeatSource);
            //Debug.Log($"Thermometer collided with {this.gameObject.name}");
            //Debug.Log("dictionary: " + this.name + " = " + heatInfluenceDic[this.name]);

            // get the themometer's Temp component
            // update the temperature based on the heat influence value
            // of the heat source from the dictionary
            Temp tempRef = otherGameobject.GetComponent<Temp>();
            tempRef.updateHeatSourceInfluence(heatInfluence);
            tempRef.updateTemp();
        }
        /*
        else
        {
            Debug.Log("not a heat source.");
            currentHeatSource = "None";
        }
        */

        // move the thermometer based on the input from the keyboard
        //Vector2 moveValue = moveAction.ReadValue<Vector2>();
    }


    void OnTriggerExit(Collider other)
    {
        currentHeatSource = "None";

        GameObject otherGameobject = other.gameObject;

        if (otherGameobject.GetComponent<Temp>() != null)
        {

            // We have the thermometer object
            // We now know that the other gameObject IS the thermometer
            //Debug.Log("other: " + other.name); // thermometer
            //Debug.Log("this: " + this.name); // heat source trigger
            //Debug.Log($"Thermometer exited from {this.gameObject.name}");
            Temp tempRef = otherGameobject.GetComponent<Temp>();

            //reverse the heat influence
            tempRef.updateHeatSourceInfluence(0);
            tempRef.updateTemp();

            //resetHeatSource();
        }

    }


    private void resetHeatSource()
    {
        currentHeatSource = "None";
 
    }

    private void updateHeatSource(string source)
    {
        currentHeatSource = source;
    }

    public string getCurrentHeatSource()
    {

        return currentHeatSource;

    }

    public float getHeatInfluence()
    {
        return heatInfluence;
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        currentHeatSource = "None";

    }

    private void Update()
    {

    }

}


