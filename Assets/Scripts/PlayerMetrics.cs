using System.Collections.Generic;
using UnityEngine;

public class PlayerMetrics : MonoBehaviour
{
    private int HeatSourcesVisited = 0;

    public List<GameObject> visitedHeatSources = new List<GameObject>();

    // if thermometer collides with a heat source, check if it's already visited
    // if not visited, add it to the list and increment HeatSourcesVisited counter.
    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("other: " + other.name);
        //Debug.Log("this: " + this.name);

        GameObject heatSource = other.gameObject;
        //Debug.Log("Heat source: " + heatSource.name);
        AddHeatSource(heatSource);
        //Debug.Log("visited heat sources: " + visitedHeatSources);
        foreach (GameObject s in visitedHeatSources)
        {
            //Debug.Log("Visited heat source: " + s.name);  
            //print(s.name);
        }

        Debug.Log("Heat source visited count: " + HeatSourcesVisited);
    }


    // bool to check if the player has visited a heat source
    public void AddHeatSource(GameObject heatSource)
    {
        if (!visitedHeatSources.Contains(heatSource))
        {
            visitedHeatSources.Add(heatSource);
            HeatSourcesVisited++;
            //Debug.Log("Heat source added. Total visited: " + HeatSourcesVisited);
        }
        else
        {
            Debug.Log("Heat source already visited.");
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
