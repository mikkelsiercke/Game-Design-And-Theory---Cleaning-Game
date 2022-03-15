using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GunScript gunScript;
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = gunScript.charge;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = gunScript.charge;
    }
}
