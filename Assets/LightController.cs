using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
    
{
    Light lt;

    // Start is called before the first frame update
    void Start()
    {

        lt = GetComponent<Light>();
        lt.intensity = 0;
        
    }

    public void setLightIntensity (float intensity)
    {
        lt.intensity = intensity;
    }


}
