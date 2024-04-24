using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesKillCount : MonoBehaviour
{
    public int count;

    public static EnemiesKillCount instance;

    public TextMeshProUGUI killsText;

    private int Kills;

    private void Awake()
    {
        instance = this;
    }

    public int killsScore
    {
        get { return Kills; }

        set
        {
            Kills = value;
            killsText.text = Kills.ToString();
        }
    }

    public static void AddKill() 
    {
        instance.count++;
    }

}
