using UnityEngine;
using UnityEngine.UI;

public class CleaningTimer : MonoBehaviour
{
    public float timeInSeconds;
    public float initialTime;
    public float repeatRateInSeconds = 1f;
    public float startDelayInSeconds;
    public float timeIncrease = 10f;
    public static bool timesUp;


    [Header("")] public Slider slider;

    private int _lastScoreValue = 0;

    private void Start()
    {
        initialTime = timeInSeconds;
        slider.maxValue = timeInSeconds;
        InvokeRepeating(nameof(DecreaseTimer), startDelayInSeconds, repeatRateInSeconds);
    }

    private void Update()
    {
        if (Scoreboard.scoreValue > _lastScoreValue)
        {
            if (!timesUp && timeInSeconds <= initialTime)
            {
                if (timeInSeconds + timeIncrease >= initialTime)
                {
                    timeInSeconds = initialTime;
                }
                else
                {
                    timeInSeconds += timeIncrease;
                }
            }

            _lastScoreValue = Scoreboard.scoreValue;
        }
    }

    private void DecreaseTimer()
    {
        if (timeInSeconds >= 0)
        {
            slider.value = timeInSeconds--;
        }
        else
        {
            timesUp = true;
            print("times up");
        }
    }
}