using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class IHM : MonoBehaviour
{
    public static IHM Instance;

    public float timeDuration = 3f * 60f;

    [SerializeField]
    private bool countDown = true;

    public float elapsedTime;

    [SerializeField]
    private TextMeshProUGUI timer;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (countDown && elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            UpdateTimerDisplay(elapsedTime);
        }
        else if (!countDown && elapsedTime < timeDuration)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay(elapsedTime);
        }
    }

    private void ResetTimer()
    {
        if (countDown)
        {
            elapsedTime = timeDuration;
        }
        else
        {
            elapsedTime = 0;
        }
    }

    private void UpdateTimerDisplay(float time)
    {
        timer.text = ToolBox.SecondsToMinutesAndSeconds(time);
    }
}
