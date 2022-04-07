using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildRender : MonoBehaviour
{
    public Renderer[] renderers;
        
    private void Start()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
    }
}
