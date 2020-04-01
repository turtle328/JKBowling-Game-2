using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//
//  Simple Clock Script / Andre "AEG" Bürger / VIS-Games 2012
//
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------

    //-- set start time 00:00
    public float minutes = 0;
    public float hour = 0;
    
    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    int seconds;
    float msecs;
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;


    //-- animation vars
    int newMinutes = -1;
    int newHour = -1;
    public GameObject sun;


//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Start() 
{
    pointerSeconds = transform.Find("rotation_axis_pointer_seconds").gameObject;
    pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
    pointerHours   = transform.Find("rotation_axis_pointer_hour").gameObject;

    msecs = 0.0f;
    seconds = 0;
}
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Update() 
{
        /*
        //-- calculate time
        msecs += Time.deltaTime * clockSpeed;
        if(msecs >= 1.0f)
        {
            msecs -= 1.0f;
            seconds++;
            if(seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if(minutes > 60)
                {
                    minutes = 0;
                    hour++;
                    if(hour >= 24)
                        hour = 0;
                }
            }
        }
        */

        if (newHour > -1 && !Mathf.Approximately(hour, newHour))
        {
            hour = Mathf.Lerp(hour, newHour, 0.01f);
            if ( Mathf.Abs(hour - newHour) < 0.3 )
            {
                hour = newHour;
            }
        }
        if (newMinutes > -1 && !Mathf.Approximately(minutes, newMinutes))
        {
            minutes = Mathf.Lerp(minutes, newMinutes, 0.01f);
            if (Mathf.Abs(minutes - newMinutes) < 0.3)
            {
                minutes = newMinutes;
            }
        }


        //-- calculate pointer angles
        float rotationSeconds = (360.0f / 60.0f)  * seconds;
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 24.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);


        Vector3 eulers = sun.transform.localEulerAngles;
        
        // 90-degree offset for directional light
        float angle = ((hour / 24) * 360) - 90;
        eulers = new Vector3(angle, 0.0f, 0.0f);
        
        sun.transform.localEulerAngles = eulers;
}


    /// <summary>
    /// Animates the movment of the clock hands into the desired positions.
    /// </summary>
    /// <param name="hour">new value for the hour hand in 24-hour time</param>
    /// <param name="minute">new value for the minute hand</param>
    public void UpdateTime(int hour, int minute)
    {
        this.newMinutes = minute;
        this.newHour = hour;
    }

//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
}
