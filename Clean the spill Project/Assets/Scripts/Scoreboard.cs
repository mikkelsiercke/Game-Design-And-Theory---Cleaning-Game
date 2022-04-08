using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    public static int scoreValue = 0;
    public static int lastScoreValue;
    Text score;
    public AudioSource[] audio;
    public AudioSource scoreIncrease;
    public AudioSource scoreDecrease;

    void Start()
    {
        score = GetComponent<Text>();
        lastScoreValue = scoreValue;

        audio = GetComponents<AudioSource>();
        scoreIncrease = audio[0];
        scoreDecrease = audio[1];
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;

        if(scoreValue > lastScoreValue)
        {
            lastScoreValue = scoreValue;
            scoreIncrease.Play();
            Debug.Log("Score has increased");
        }
        else if(scoreValue < lastScoreValue)
        {
            lastScoreValue = scoreValue;
            scoreDecrease.Play();
            Debug.Log("Score has decreased");
        }

    }
}
