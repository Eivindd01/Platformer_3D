using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCoin : MonoBehaviour
{
    public static ScoreCoin instance;
    public TextMeshProUGUI coinText;

    private int Score;

    private void Awake()
    {
        instance = this;
    }

    public int score
    {
        get { return Score; }

        set
        {
            Score = value;
            coinText.text = Score.ToString();
        }
    }

}
