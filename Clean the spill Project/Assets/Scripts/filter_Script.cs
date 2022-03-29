using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class filter_Script : MonoBehaviour
{
    public PostProcessVolume volume;
    // private Vignette _Vignette;
    private ColorGrading colorFilter;

    void Start()
    {
        //volume.profile.TryGetSettings(out _Vignette);
        volume.profile.TryGetSettings(out colorFilter);
        colorFilter = volume.GetComponent<ColorGrading>();
        // _Vignette.intensity.value = 0;

    }

    void Update()
    {
        if (Input.GetKey("space"))
        {
            //_Vignette.intensity.value = 1;
            colorFilter.active = false;
            print("space");
        }
        else
        {
            colorFilter.active = true;
            print("not space");
        }
    }
}