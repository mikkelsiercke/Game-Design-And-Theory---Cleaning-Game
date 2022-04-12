using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class filter_Script : MonoBehaviour
{
    public PostProcessVolume volume;
    private Vignette _Vignette;

    public bool filter;
    public float saturation = 5f;

    void Start()
    {
        //Vignette
        volume.profile.TryGetSettings(out _Vignette);

        //volume.profile.TryGetSettings(out colorFilter);

        _Vignette.intensity.value = 0;

        //Filter aktiveret eller ej
        filter = false;
    }

    void Update()
    {
        //If statement der aktiverer filtret
        if (Input.GetKeyDown("space") && filter == false)
        {
            //Sætter Vignetten til 1 samt sætter boolean der kontrollerer filt er til true

            _Vignette.intensity.value = 0.9f;
            filter = true;
            //colorFilter.enable.value = true;
        }
        else if (Input.GetKeyDown("space") && filter == true)
        {
            //Fjerne vignette og sætte boolean til false
            _Vignette.intensity.value = 0;
            filter = false;
            //colorFilter.enable.value = false;
        }
    }
}