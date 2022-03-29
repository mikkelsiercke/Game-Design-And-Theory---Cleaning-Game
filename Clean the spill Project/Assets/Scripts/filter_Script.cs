using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class filter_Script : MonoBehaviour {

public PostProcessVolume volume;
private Vignette _Vignette;

    void Start(){
    volume.profile.TryGetSettings(out _Vignette);
    _Vignette.intensity.value = 0;

    }

    void Update(){
        if(Input.GetKeyDown("space")){
           _Vignette.intensity.value = 1;
        } 
    }
}


