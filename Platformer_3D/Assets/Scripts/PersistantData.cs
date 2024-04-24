using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersistantData : MonoBehaviour
{
    public int coins;

    public float timer;

    public int enemyKilled;

    public static PersistantData instance;

    public void GetInfo()
    {
        coins = ScoreCoin.instance.score;
        enemyKilled = EnemiesKillCount.instance.count;
        timer = IHM.Instance.elapsedTime;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void ResetValue()
    {
        timer = 0;
        enemyKilled = 0;
        coins = 0;
    }
}
