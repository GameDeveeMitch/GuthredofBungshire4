using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Schedule_Manager : MonoBehaviour
{
    #region Clock Variables
    public int start_Hour;
    public float start_Min;

    public float time_Scale_Modifier;

    [SerializeField] private Text hoursText;
    [SerializeField] private Text minutesText;
    [SerializeField] private Text ampmText;

    private int hours;
    private float minutes;
    private string ampm;

    private float currentMins;
    private float currentHours; 
    private bool timePaused = false;

    private bool day = true;
    #endregion

    #region Schedule Time Variables
    public int breakfast_Start_Hour;
    public float breakfast_Start_Min;

    public int job_Start_Hour;
    public float job_Start_Min;

    public int lunch_Start_Hour;
    public float lunch_Start_Min;

    public int dinner_Start_Hour;
    public float dinner_Start_Min;

    public int bed_Start_Hour;
    public float bed_Start_Min;
    
    public int roll_One_Hour;
    public float roll_One_Min;
    
    public int roll_Two_Hour;
    public float roll_Two_Min;
    
    public int free_One_Hour;
    public float free_One_Min;
    
    public int free_Two_Hour;
    public float free_Two_Min;

    [SerializeField] private Text scheduleText;

    enum Schedule
    {
        BED_TIME,
        ROLL_CALL_ONE,
        ROLL_CALL_TWO,
        BREAKFAST,
        JOB_TIME,
        LUNCH,
        FREE_TIME_ONE,
        FREE_TIME_TWO,
        DINNER
    }

    private Schedule scheduleTime;
    #endregion

    #region Start/Update Methods
    private void Start()
    {
        SetClock();

        scheduleText = GameObject.FindGameObjectWithTag("ScheduleText").GetComponent<Text>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (timePaused == false)
            {
                PauseTime();
            }
            else
            {
                timePaused = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (timePaused == false)
        {
            ClockFunction();
        }

        SetScheduleTime();
    }
    #endregion

    #region Schedule Functionality
    void SetScheduleTime()
    {
        if(hours == breakfast_Start_Hour && minutes >= breakfast_Start_Min && day == true)
        {
            scheduleTime = Schedule.BREAKFAST;
        }
        
        if(hours == job_Start_Hour && minutes >= job_Start_Min && day == false)
        {
            scheduleTime = Schedule.JOB_TIME;
        }
        
        if(hours == lunch_Start_Hour && minutes >= lunch_Start_Min && day == false)
        {
            scheduleTime = Schedule.LUNCH;
        }
        
        if(hours == dinner_Start_Hour && minutes >= dinner_Start_Min && day == false)
        {
            scheduleTime = Schedule.DINNER;
        }
        
        if(hours == bed_Start_Hour && minutes >= bed_Start_Min && day == false)
        {
            scheduleTime = Schedule.BED_TIME;
        }
        
        if(hours == roll_One_Hour && minutes >= roll_One_Min && day == true)
        {
            scheduleTime = Schedule.ROLL_CALL_ONE;
        }
        
        if(hours == roll_Two_Hour && minutes >= roll_Two_Min && day == false)
        {
            scheduleTime = Schedule.ROLL_CALL_TWO;
        }
        
        if(hours == free_One_Hour && minutes >= free_One_Min && day == true)
        {
            scheduleTime = Schedule.FREE_TIME_ONE;
        }
        
        if(hours == free_Two_Hour && minutes >= free_Two_Min && day == false)
        {
            scheduleTime = Schedule.FREE_TIME_TWO;
        }
        SetSchedule();
    }

    public void SetSchedule()
    {
        switch (scheduleTime)
        {
            case Schedule.ROLL_CALL_ONE:
                scheduleText.text = "FIRST ROLL CALL";
                break;
            case Schedule.ROLL_CALL_TWO:
                scheduleText.text = "SECOND ROLL CALL";
                break;
            case Schedule.BREAKFAST:
                scheduleText.text = "BREAKFAST";
                break;
            case Schedule.JOB_TIME:
                scheduleText.text = "JOB TIME";
                break;
            case Schedule.LUNCH:
                scheduleText.text = "LUNCH";
                break;
            case Schedule.FREE_TIME_ONE:
                scheduleText.text = "FIRST FREE TIME";
                break;
            case Schedule.FREE_TIME_TWO:
                scheduleText.text = "SECOND FREE TIME";
                break;
            case Schedule.DINNER:
                scheduleText.text = "DINNER";
                break;
            case Schedule.BED_TIME:
                scheduleText.text = "BED TIME";
                break;
        }   
    }
    #endregion

    #region Clock Functionality
    void SetClock()
    {
        ampm = "AM"; //The day should always start off fresh in the AM

        hoursText = GameObject.FindGameObjectWithTag("HoursText").GetComponent<Text>();
        minutesText = GameObject.FindGameObjectWithTag("MinutesText").GetComponent<Text>();//These are the reference to the UI text elements
        ampmText = GameObject.FindGameObjectWithTag("AMPMText").GetComponent<Text>();

        hours = start_Hour; //Starting time
        minutes = start_Min; 
    }

    public void PauseTime() //Really just sets the timePaused bool to true and stores the current game time in two current time variables
    {
        timePaused = true;
        currentMins = minutes;
        currentHours = hours;
    }

    void ClockFunction()
    {
        if(timePaused == false)
        {
            UpdateTime();
            hoursText.text = hours.ToString();
            if (minutes < 9.5f)
                minutesText.text = ("0" + minutes.ToString("F0"));
            else
                minutesText.text = minutes.ToString("F0");
            if (ampmText != null)
                ampmText.text = ampm;
        }
        else
        {
            if (minutes < 9.5f)
                minutesText.text = ("0" + currentMins.ToString("F0"));
            else
                minutesText.text = currentMins.ToString("F0");
            hoursText.text = currentHours.ToString();
        }
    }

    void UpdateTime()
    {
        minutes += (Time.deltaTime / time_Scale_Modifier);

        if(minutes > 59)
        {
            minutes = 0;
            hours += 1;
        }

        if (hours > 12)
        {
            hours = 1;

            if (day == true)
                ampm = "PM";
            else
            {
                ampm = "AM";
            }

            day = !day;
        }
    }
    #endregion
}
