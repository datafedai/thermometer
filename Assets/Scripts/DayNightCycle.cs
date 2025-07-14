using UnityEngine;
using UnityEngine.InputSystem;

public class DayNightCycle : MonoBehaviour
{

    public GameObject moon; // RMoon

    public GameObject directionalLight; // directional light for day/night cycle

    //private int dayIndex = 0; // Initialize day index, even=day, odd=night
    //private bool dayNightIndex = false; // day:0, night:1

    private bool isDayTime = true; // day time or night time indicator

    //public Quaternion startRotation; // The rotation to start from
    private Quaternion targetRotation;  // directional light target position
    private Quaternion hideSunRotation;
    private float sunTargetAngle = 80f; // directional light x target angle during day time
    private float rotationSpeed = 0.5f; // directional light rotation speed

    public Vector3 rotationAxisMoon; // axis for moon to revolve around
    public GameObject targetMoon;
    public GameObject blackPoint;

    public void switchDayNight()
    {
        if (isDayTime)
        {
            isDayTime = false;
        }
        else
        {
            isDayTime = true;
        }
    }


    public bool getIsDayTimeValue()
    {
        return isDayTime;
    }


    public string getDayNightString()
    {
        if (isDayTime)
            return "Day";
        else
            return "Night";
    }


    private void rotateLight(float angle)
    {
        // rotate the directional light by the given angle
        directionalLight.transform.Rotate(angle, 0f, 0f, Space.World);
    }

    /*
        private bool dayNightIndex(int spaceCount)
        {
            if (spaceCount % 2 == 0) // day
            {
                isDayTime = false;
                return isDayTime;
            }
            else // night
            {
                isDayTime = true;
                return isDayTime;
            }
        }


        public bool isDayTimeCheck()
        {
            if (spaceCount % 2 == 0) // day
            {
                return true;
            }
            else // night
            {
                return false;
            }
        }

    */

    public void triggerDayNightChange()
    {
        // change the day based on the input from the keyboard


        //Debug.Log("Change day action triggered");
        // code to change the day
        // for example, you can call a method to change the day in the game
        /*
        float changeDayValue = changeDayAction.ReadValue<float>();
        //Debug.Log("Change day value: " + changeDayValue);
        
        spaceCount++;
        Debug.Log("space count: " + spaceCount);
        Debug.Log("Current day(F) night(T) index: " + dayNightIndex(spaceCount));
*/
        //directionalLight.transform.Rotate(180f, 0f, 0f, Space.World);
        if (isDayTime)
        {
            Debug.Log("It's day time now.");
            // code to change the day to day time
            // for example, you can change the background color or the light intensity
            //directionalLight.transform.Rotate(90f, 180f, 180f, Space.World);
            rotateLight(15f);
            //tempRef.updateTemp(0f);

            // room temperature stays 20 dgrees Celsius
        }
        else
        {
            Debug.Log("It's night time now.");
            // code to change the day to night time
            // for example, you can change the background color or the light intensity
            //rotateLight(90f);
            //rotateLight(2 * 90f);
            directionalLight.transform.Rotate(20, 0f, 0f, Space.World);

            // call revolveMoon() on RotationController



            // update room temperature down to 10 degrees Celsius
            //tempRef.updateTemp(-10f);
        }


    }


    public void revolveMoon()
    {
        //Debug.Log("I am in revolveMoon()");
        rotationAxisMoon = new Vector3(-1, 2, -5);
        targetMoon.transform.RotateAround(blackPoint.transform.position, rotationAxisMoon, 30 * Time.deltaTime);
        //Debug.Log("moon position: " + targetMoon.transform.position);
    }

    public void hideMoon()
    {
        //rotationAxisMoon = new Vector3(-1, 2, -5);
        targetMoon.transform.position = new Vector3(-90, -48, 42);
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        spaceCount = 0; // initial, day time
        Debug.Log("space count: " + spaceCount);
        Debug.Log("dayNightIndex(): " + dayNightIndex(spaceCount));

*/

        rotationAxisMoon = new Vector3(-1, 2, -5);

        //directionalLight.transform.Rotate(-1f, 0f, 0f);
        //directionalLight.transform.Rotate(-10f, 0f, 0f, Space.World);

        //startRotation = Quaternion.Euler(20, 0, 0); 
        //Debug.Log("start rotaion: " + startRotation); 
        targetRotation = Quaternion.Euler(180 - sunTargetAngle, 0, 0);
        //hideSunRotation = Quaternion.Euler(190, 0, 0);
        //Debug.Log("target rotation: " + targetRotation);
        //Debug.Log("rotation1: " + directionalLight.transform.rotation);



    }

    // Update is called once per frame
    void Update()
    {
        //if (dayNightIndex(spaceCount) == false)
        if (isDayTime) // day time
        {
            // hide moon if day time
            //RotationController moonRotation = moon.GetComponent<RotationController>();
            //moonRotation.hideMoon();
            hideMoon();

            // rotate directional light
            directionalLight.transform.rotation =
                Quaternion.Slerp(directionalLight.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else // night time
        {
            // hide sun, directional light
            /*
            directionalLight.transform.rotation =
                Quaternion.Slerp(directionalLight.transform.rotation, hideSunRotation, Time.deltaTime * 10* rotationSpeed);
                */
            directionalLight.transform.eulerAngles = new Vector3(260, 0, 0);

            //RotationController moonRotation = moon.GetComponent<RotationController>();
            //moonRotation.revolveMoon();
            //Debug.Log("moon");
            revolveMoon();  


        }









    }
}