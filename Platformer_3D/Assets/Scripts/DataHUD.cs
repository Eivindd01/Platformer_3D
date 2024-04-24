using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataHUD : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI coinScore;
    [SerializeField]
    public TextMeshProUGUI timer;
    [SerializeField]
    public TextMeshProUGUI kills;

    public void Start()
    {
        coinScore.text = PersistantData.instance.coins.ToString();
        timer.text = PersistantData.instance.timer.ToString();
        kills.text = PersistantData.instance.enemyKilled.ToString();
        
    }

}
