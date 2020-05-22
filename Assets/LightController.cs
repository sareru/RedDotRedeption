using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
    
{
    public static Light lt;
    // Start is called before the first frame update
    void Start()
    {

        lt = GetComponent<Light>();
        lt.intensity = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setLightIntensity (float intensity)
    {
        lt.intensity = intensity;
    }


}
