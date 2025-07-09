using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class RotationTest : MonoBehaviour
{
    private Quaternion currentRotation;
    private Quaternion targetRotation;
    public GameObject cyl;
    //public Vector3 targetPos;
    public Vector3 look;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        //Debug.Log("rotation1: " + cyl.transform.rotation);

        //targetRotation = Quaternion.Euler(10, 0, 0); 
        //directionalLight.transform.rotation = startRotation;
        //cyl.transform.rotation = targetRotation;
        //Debug.Log(Quaternion.identity);
        //Debug.Log("rotation2: " + cyl.transform.rotation);
        //directionalLight.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, 2f);

        //targetPos = new Vector3();

        // initial rotation
        look = new Vector3(0, 0, 1);
 
    }



    // Update is called once per frame
    void Update()
    {

        //Vector3 currentPos = transform.position;
        //Debug.Log("current pos: " + currentPos);
        //look = targetPos - currentPos;
        //Debug.Log("target pos: " + currentPos);


        //Debug.Log("looking: " + look);
        //cyl.transform.rotation = Quaternion.LookRotation(look, Vector3.up);
        //Debug.Log("rotation: " + cyl.transform.rotation);
        cyl.transform.Rotate(look * 100f * Time.deltaTime);
  
    }
}
