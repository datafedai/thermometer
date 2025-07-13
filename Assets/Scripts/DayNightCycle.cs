using UnityEngine;
using UnityEngine.InputSystem;

public class DayNightCycle : MonoBehaviour
{

    public GameObject moon; // RMoon

    public GameObject directionalLight; // directional light for day/night cycle

    //private int dayIndex = 0; // Initialize day index, even=day, odd=night
    //private bool dayNightIndex = false; // day:0, night:1

    private bool isDayTime = true;

    //public Quaternion startRotation; // The rotation to start from
    private Quaternion targetRotation;
    private float rotationSpeed = 0.1f;
    private float sunTargetAngle = 90f;




    public string dayOrNight()
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
            rotateLight(90f);
            //tempRef.updateTemp(0f);

            // room temperature stays 20 dgrees Celsius
        }
        else
        {
            Debug.Log("It's night time now.");
            // code to change the day to night time
            // for example, you can change the background color or the light intensity
            //rotateLight(90f);
            rotateLight(2 * 90f);

            // call revolveMoon() on RotationController



            // update room temperature down to 10 degrees Celsius
            //tempRef.updateTemp(-10f);
        }


    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        spaceCount = 0; // initial, day time
        Debug.Log("space count: " + spaceCount);
        Debug.Log("dayNightIndex(): " + dayNightIndex(spaceCount));

*/



        //directionalLight.transform.Rotate(-1f, 0f, 0f);
        //directionalLight.transform.Rotate(-10f, 0f, 0f, Space.World);

        //startRotation = Quaternion.Euler(20, 0, 0); 
        //Debug.Log("start rotaion: " + startRotation); 
        targetRotation = Quaternion.Euler(180 - sunTargetAngle, 0, 0);
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
            RotationController moonRotation = moon.GetComponent<RotationController>();
            moonRotation.hideMoon();


            // rotate directional light
            directionalLight.transform.rotation =
                Quaternion.Slerp(directionalLight.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else // night time
        {
            RotationController moonRotation = moon.GetComponent<RotationController>();
            moonRotation.revolveMoon();
            //Debug.Log("moon");  
        }









    }
}