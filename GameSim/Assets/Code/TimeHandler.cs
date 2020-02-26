using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    #region SINGLETON SETUP
    public static TimeHandler Instance;
    void Awake()
    {
        Instance = this;
    }
    #endregion

    public Text DateText;
    public Text TimeOfDayText;
    private const int SecondsInADay = 86400; //86400 seconds are in 24 hours
    private int _currentSecondsLeft;
    private const int TimeScalar = 4; //A day is 4x faster (so, 24 hours / 4) etc.

    private void Start()
    {
        _currentSecondsLeft = SecondsInADay;
        SetDate();
        SetTime();
    }

    public void SetDate()
    {
        DateText.text = DateTime.Now.Year + " / " + DateTime.Now.Month + " / " + DateTime.Now.Day;
    }

    private void FixedUpdate()
    {
        SetTime();
    }

    public void SetTime()
    {
        _currentSecondsLeft -= 1 * TimeScalar;
        var t = TimeSpan.FromSeconds(_currentSecondsLeft);
        TimeOfDayText.text = t.Hours.ToString();

        if (t.Minutes < 10) TimeOfDayText.text += ":0" + t.Minutes;
        else TimeOfDayText.text += ":" + t.Minutes;

        if (t.Seconds < 10) TimeOfDayText.text += ":0" + t.Seconds;
        else TimeOfDayText.text += ":" + t.Seconds;

        if (t.Hours < 13) TimeOfDayText.text += " PM";
        else TimeOfDayText.text += " AM";
    }
}
