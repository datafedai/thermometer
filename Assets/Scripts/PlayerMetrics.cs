using System.Collections.Generic;
using UnityEngine;

public class PlayerMetrics : MonoBehaviour
{
    private int HeatSourcesVisited = 0;
    private List<GameObject> visitedHeatSources = new List<GameObject>();

    // if thermometer collides with a heat source, check if it's already visited
    // if not visited, add it to the list and increment HeatSourcesVisited counter.
    private void OnTriggerEnter(Collider other)
    {
        // debug purpose:
        //Debug.Log("other: " + other.name);
        //Debug.Log("this: " + this.name);

        // get the heat source gameobject from the collider.
        // PlayerMetrics.cs is attached to the thermometer gameobject.
        // so thermometer is 'this' and the heat source is 'other'.
        GameObject heatSource = other.gameObject;

        // debug purpose:
        //Debug.Log("Heat source: " + heatSource.name);

        // add the heat source to the list of visited heat sources if not already visited
        // and increment the HeatSourcesVisited counter.
        AddHeatSource(heatSource);

        // print the list of visited heat sources
        //Debug.Log("visited heat sources: " + visitedHeatSources);
        /* another way to print the list
        foreach (GameObject s in visitedHeatSources)
        {
            Debug.Log("Visited heat source: " + s.name);
        }
        */

        // print the count of visited heat sources
        Debug.Log("Heat source visited count: " + HeatSourcesVisited);
    }

    // method to add a heat source to the list HeatSourcesVisited
    // and increment the HeatSourcesVisited counter.
    // if the heat source is already visited, do not increment the counter
    // and print a message. 
    private void AddHeatSource(GameObject heatSource)
    {
        if (!visitedHeatSources.Contains(heatSource))
        {
            visitedHeatSources.Add(heatSource);
            HeatSourcesVisited++;
            //Debug.Log("Heat source added. Total visited: " + HeatSourcesVisited);
        }
        else
        {
            Debug.Log(heatSource.name + " is already visited.");
        }
    }











    /*
     
    public List<GameObject> MyGem = new List<GameObject>();


    public void AddItem ()
    {
        MyGem.Add(gemma.currentGem);

    }


    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }






}
