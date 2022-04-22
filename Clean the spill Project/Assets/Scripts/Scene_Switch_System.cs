using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Switch_System : MonoBehaviour
{
    
    public GameObject gameObject;
    public int scoreRequired;
    private int scoreValue = Scoreboard.scoreValue;


    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Scoreboard.scoreValue >= scoreRequired && CleaningTimer.timesUp == false)
        {
            gameObject.SetActive(true);
        } else if (Scoreboard.scoreValue < scoreRequired)
        {
            gameObject.SetActive(false);
        }
    }
}
