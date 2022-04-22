using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CleaningTimer : MonoBehaviour
{
    public float timeInSeconds;
    public float initialTime;
    public float repeatRateInSeconds = 1f;
    public float startDelayInSeconds;
    public float timeIncrease = 10f;
    public bool timesUp;
    //public float levelScene;
    public static bool timesUp;

    public GameObject GameOver_;

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

        GameOver();
        ToggleGameOver();
        RestartScene();
        ReturnToLevelSelect();

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
    
    private void GameOver()
    {
        if (timesUp == true)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        Cursor.visible = false;
    }
    void ResumeGame ()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        AudioListener.pause = false;
    }

    void ToggleGameOver()
    {
        GameOver_.SetActive(timesUp);
    }

    void RestartScene()
    {
        if(timesUp == true && Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    void ReturnToLevelSelect()
    {
        if(timesUp == true && Input.GetKeyDown("escape"))
        {
            ResumeGame();
            SceneManager.LoadScene(1);
        }
    }
}