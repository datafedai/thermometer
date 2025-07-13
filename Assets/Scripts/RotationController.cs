using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class RotationController : MonoBehaviour
{
    private Quaternion currentRotation;
    private Quaternion targetRotation;
    public GameObject cyl;
    //public Vector3 targetPos;
    public Vector3 lookCyl;
    public Vector3 lookCaps;
    public Vector3 rotationAxisCaps;
    public Vector3 rotationAxisSph;
    public Vector3 rotationAxisMoon; // axis for moon to revolve around
    public GameObject targetSph;
    public GameObject targetCaps;
    public GameObject targetMoon;
    public GameObject blackPoint;

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
        lookCyl = new Vector3(1, 1, 0);
        lookCaps = new Vector3(1, -1, 0);
        rotationAxisCaps = new Vector3(-1, 1, 0);
        rotationAxisSph = new Vector3(1, 1, 0);
        rotationAxisMoon = new Vector3(-1, 2, -5);
        //rotationAxis = Vector3.up;
    }


    public void revolveMoon()
    {
        //Debug.Log("I am in revolveMoon()");
        rotationAxisMoon = new Vector3(-1, 2, -5);
        targetMoon.transform.RotateAround(blackPoint.transform.position, rotationAxisMoon, 10 * Time.deltaTime);
        Debug.Log("moon position: " + targetMoon.transform.position);
    }

    public void hideMoon()
    {
        //rotationAxisMoon = new Vector3(-1, 2, -5);
        targetMoon.transform.position = new Vector3(-90, -48, 42);
    }


    // Update is called once per frame
    void Update()
    {

        //Vector3 currentPos = transform.position;
        //Debug.Log("current pos: " + currentPos);
        //look = targetPos - currentPos;
        //Debug.Log("target pos: " + currentPos);


        //Debug.Log("looking: " + look);
        cyl.transform.rotation = Quaternion.LookRotation(lookCyl, Vector3.up);
        //Debug.Log("rotation: " + cyl.transform.rotation);
        //cyl.transform.Rotate(look * 100f * Time.deltaTime);
        targetCaps.transform.rotation = Quaternion.LookRotation(lookCaps, Vector3.up);

        targetCaps.transform.RotateAround(cyl.transform.position, rotationAxisCaps, 50 * Time.deltaTime);
        targetSph.transform.RotateAround(cyl.transform.position, rotationAxisSph, 30 * Time.deltaTime);

        // revolve moon
        //revolveMoon();
  
    }
}
