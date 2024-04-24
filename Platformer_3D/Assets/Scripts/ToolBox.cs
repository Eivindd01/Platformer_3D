using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToolBox 
{
    public static string SecondsToMinutesAndSeconds(float seconds)
    {
        int minutes = (int) (seconds / 60f); //converti le f en int
        int secondsLeft = (int) (seconds - (minutes * 60));

        string secondsLeftStr = (secondsLeft < 10)?"0" + secondsLeft.ToString() : secondsLeft.ToString();

        if (minutes > 0)
        {
            return minutes + " min " + secondsLeftStr;
        }
        else
        {
            return secondsLeftStr + " sec ";
        }
    }
}
